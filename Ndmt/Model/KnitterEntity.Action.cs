using System;
using System.IO;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using Starksoft.Net.Ftp;
using ManagedUPnP;

namespace Ndmt.Model
{
    /// <summary>
    /// 本部分为动作实现
    /// </summary>
    partial class KnitterEntity
    {
        #region JC5 Network Driver Functions

        /// <summary>
        /// 发送Action:Restart使JC5 Network Driver重新启动
        /// Exception: TransportException
        /// </summary>
        public void Restart() 
        {
            LogHelper.LogHere("Restart", this.SerialNumber);
            try
            {
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction("Restart");
                this.isDeviceRestarting = true;
                // 状态变更
                CurrentState.Restart();
                this.JC5NetworkDriverUPnP = null;
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "Restart");
            }
        }

        /// <summary>
        /// 发送Action:Reset使JC5 Network Driver恢复出厂设置
        /// </summary>
        public void Reset()
        {
            LogHelper.LogHere("Reset", this.SerialNumber);
            try
            {
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction("Reset");
                this.isDeviceRestarting = true;
                // 状态变更
                CurrentState.Reset();
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "Reset");
            }
        }

        /// <summary>
        /// 发送Action:MountExStorage使JC5 Network Driver获得对USB设备的控制
        /// </summary>
        public void MountExStorage()
        {
            bool resExStorageMounted = false;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction<bool>("MountExternalStorage", out resExStorageMounted);
                    if (resExStorageMounted == true)
                        break;
                    int waitSeconds = 1000 + 250 * i;
                    LogHelper.LogHere("RestartMountInSeconds", (i + 1).ToString(), waitSeconds.ToString());
                    System.Threading.Thread.Sleep(waitSeconds);
                }
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "MountExStorage");
            }
            // 多次尝试后仍然未成功
            if (resExStorageMounted == false)
                throw new TransportException(TransportException.MultipleLinkAttemptFailed, "MountExStorage",TransportException.TransportErrorCode.USB_BUSY);
            else
                LogHelper.LogHere("MountExStorage", this.SerialNumber);
        }

        /// <summary>
        /// 发送Action:UnmountExStorage使JC5 Network Driver解除对USB设备的控制
        /// </summary>
        public void UnmountExStorage()
        {
            bool resExStorageMounted = true;
            try
            {
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction<bool>("UnmountExternalStorage", out resExStorageMounted);
                LogHelper.LogHere("UnmountExStorage", this.SerialNumber);
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "UnmountExStorage");
            }
        }

        /// <summary>
        /// 装载当前最新订单
        /// </summary>
        public void LoadCurrentShift()
        {
            // 封装最新订单为ShiftEntity
            mShiftEntityCollection.Reload();
            try
            {
                // 有订单记录
                if (mShiftEntityCollection.Count > 0)
                    this.mCurrentShiftEntity = mShiftEntityCollection[0] as ShiftEntity;
                else
                    throw new ShiftProceedingException(ShiftProceedingException.ErrorString, "LoadCurrentShift");
            }
            catch (SqlExecutionErrorException sqlex)
            {
                throw new TransportException(sqlex, "LoadCurrentShift");
            }
        }

        /// <summary>
        /// 清空FTP中所有文件
        /// </summary>
        public void FlushPatternEP()
        {
            LogHelper.LogHere("FlushPatternEP", this.SerialNumber);
            try
            {
                using (FtpClient ftp = new FtpClient(this.mIPAddr.ToString(), 21))
                {
                    // open a connection to the ftp server with a username and password
                    ftp.Open(mFtpUsername, mFtpPassword);

                    // 清空FTP中所有文件
                    FtpItemCollection fileList = ftp.GetDirList();

                    foreach (FtpItem file in fileList)
                    {
                        if (file.ItemType == FtpItemType.File)
                            ftp.DeleteFile(file.Name);
                    }

                    // close the ftp connection
                    ftp.Close();
                }
            }
            catch (FtpException ftpex)
            {
                throw new TransportException(ftpex, "FlushPatternEP");
            }
        }

        /// <summary>
        /// 通过FTP发送图案文件
        /// </summary>
        public void LoadPatternEP()
        {
            LogHelper.LogHere("LoadPatternEP", this.SerialNumber);
            try
            {
                using (FtpClient ftp = new FtpClient(this.mIPAddr.ToString(), 21))
                {
                    ftp.Open(mFtpUsername, mFtpPassword);

                    // 获取文件
                    string fileName = this.mCurrentShiftEntity[ShiftEntity.Properties.DocumentName].ToString();
                    string path = global::Ndmt.Properties.Settings.Default.DefaultWorkingDirectory;
                    string fullName = System.IO.Path.Combine(path, fileName);
                    if (File.Exists(fullName))
                    {
                        // 放入当前订单中指定位置的文件
                        ftp.PutFile(fullName, fileName, FileAction.Create);
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                    ftp.Close();
                }
            }
            catch (FileNotFoundException filex)
            {
                throw new ShiftProceedingException(filex, "LoadPatternEP");
            }
            catch (FtpException ftpex)
            {
                throw new TransportException(ftpex, "LoadPatternEP");
            }
        }

        /// <summary>
        /// 异步记录时间
        /// </summary>
        public void LogEventTime(ShiftEntity.Properties prop)
        {
            LogHelper.LogHere("LogEventTime",this.SerialNumber,(prop == ShiftEntity.Properties.StartTime)? "开始":"完成");
            this.mCurrentShiftEntity[prop] = DateTime.Now;
            this.mShiftEntityTracker.CommitChanges();
        }

        /// <summary>
        /// 发送Action:Notify报告完毕
        /// </summary>
        public void NotifyOrderFinished()
        {
            try
            {
                ShiftEntity current = this.mCurrentShiftEntity;
                LogHelper.LogHere("NotifyOrderFinished", current[ShiftEntity.Properties.StartTime].ToString(),
                                                        current[ShiftEntity.Properties.ShiftID],
                                                        current[ShiftEntity.Properties.PatternName],
                                                         this.FriendlyName);
                string resJC5WorkingStatus;
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction<string>("Notify", out resJC5WorkingStatus);
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "NotifyOrderFinished");
            }
        }

        /// <summary>
        /// 发送Action:Notify使设备重置为Idle状态
        /// </summary>
        public void ResetToIdle()
        {
            LogHelper.LogHere("ResetToIdle",this.FriendlyName);
            try
            {
                string resJC5WorkingStatus;
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction<string>("Notify", out resJC5WorkingStatus);
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "ResetToIdle");
            }
        }

        /// <summary>
        /// 取消当前订单
        /// </summary>
        public void CancelCurrentTask()
        {
            if (this.mWorkerThread != null              
                && this.mTokenSrc!= null 
                && !this.mWorkerThread.IsCanceled
                )
                this.mTokenSrc.Cancel();
        }

        /// <summary>
        /// 发送Action:设置FriendlyName
        /// </summary>
        /// <param name="newFriendlyName"></param>
        public void SetFriendlyName(string newFriendlyName)
        {
            LogHelper.LogHere("SetFriendlyName", this.SerialNumber);
            try
            {
                this.JC5NetworkDriverUPnP.KnitterControl1Service.InvokeAction("SetFriendlyName", newFriendlyName);
            }
            catch (UPnPException upnpex)
            {
                throw new TransportException(upnpex, "SetFriendlyName");
            }
        }

        /// <summary>
        /// 设备变量初始化
        /// </summary>
        public void IdleInit()
        {
            try
            {
                // 尝试销毁
                this.mTokenSrc.Dispose();
                this.mWorkerThread.Dispose();
            }
            // 第一次执行时因没有这些数据而出现异常
            catch { }
            finally
            {
                this.mTokenSrc = null;
                this.mWorkerThread = null;
            }
            // Proceed: Cannot -> Can 
            this.mCanNextButtonHandlerProceed.Set();
            // Proceed: Can -> Cannot
            this.mCanFinishButtonHandlerProceed.Reset();
            // Proceed: Can -> Cannot
            this.mCanMountSignal.Reset();
        }

        #endregion

    }
}
