using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

using ManagedUPnP;
using Ndmt.Utils;
using Ndmt.Model.Events;
using UPnPJC5NetworkDriver.Devices;
using UPnPJC5NetworkDriver.Services;
using System.Text.RegularExpressions;
using Starksoft.Net.Ftp;

namespace Ndmt.Model
{
    partial class KnitterEntity
    {
        #region Public Properties

        /// <summary>
        /// 历史设备数据集
        /// </summary>
        public static SearchableBindingList<KnitterEntity> HistoryKnitter//属性
        {
            get { return KnitterEntity.mHistoryKnitter; }
        }
        
        /// <summary>
        /// 历史设备数据集搜索依据
        /// </summary>
        public static PropertyDescriptor SearchBySerialNumProperty
        {
            get { return mSearchBySerialNumProperty; }
        }

        /// <summary>
        /// 历史设备数据集搜索依据
        /// </summary>
        public static PropertyDescriptor SearchByFriendlyNameProperty
        {
            get { return mSearchByFriendlyNameProperty; }
        }

        /// <summary>
        /// 序列号是否以证书中前缀开头
        /// </summary>
        public bool IsLicensed
        {
            get { return this.mIsLicensed; }
        }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline
        {
            get { return (this.JC5NetworkDriverUPnP != null); }
        }

        /// <summary>
        /// 可否进行重启
        /// </summary>
        public bool CanReboot
        {
            get { return !this.isDeviceRestarting && this.IsOnline; }
        }

        /// <summary>
        /// 机台号
        /// </summary>
        public String FriendlyName
        {
            get { return this.mFriendlyName; }
            set
            {
                if (value != this.mFriendlyName)
                {
                    // 保存旧名
                    string oldFriendlyName = this.mFriendlyName;
                    // 更改应用
                    this.mFriendlyName = value;
                    NotifyPropertyChanged("FriendlyName");
                    // 记录新名
                    string newFriendlyName = this.mFriendlyName;
                    // 触发变更机位号事件
                    NotifyFriendlyNameChanged(new FriendlyNameChangedEventArgs(oldFriendlyName, newFriendlyName));
                }
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public String SerialNumber
        {
            get { return this.mSerialNumber; }
            set
            {
                if (value != this.mSerialNumber)
                {
                    this.mSerialNumber = value;
                    NotifyPropertyChanged("SerialNumber");
                }
            }
        }

        /// <summary>
        /// 设备IP地址
        /// </summary>
        public IPAddress DeviceIPAddress
        {
            get { return this.mIPAddr; }
            set
            {
                if (value != this.mIPAddr)
                {
                    this.mIPAddr = value;
                    NotifyPropertyChanged("DeviceIPAddress");
                }
            }
        }

        /// <summary>
        /// 设备MAC地址
        /// </summary>
        public PhysicalAddress DeviceMacAddress
        {
            get
            {
                return this.mMacAddr;
            }
            set
            {
                if (value != this.mMacAddr)
                {
                    this.mMacAddr = value;
                    NotifyPropertyChanged("DeviceMacAddress");
                }
            }
        }

        /// <summary>
        /// UPnP服务上线与下线
        /// </summary>
        public JC5NetworkDriver JC5NetworkDriverUPnP
        {
            get
            {
                return this.mJC5NetworkDriver;
            }
            set
            {
#if (!DEBUG)
                // 若不通过验证则无法使用该设备
                if (IsLicensed)
#endif
                {
                    if (value == null) //下线
                    {
                        NotifyKnitterOffline();
                        // 下线时不通知ReadableCurrentState状态变更，以保留Reset和Restart状态
                        this.mJC5NetworkDriver = value;
                    }
                    else // 上线
                    {
                        this.mJC5NetworkDriver = value;
                        this.isDeviceRestarting = false;
                        NotifyKnitterOnline();  
                    }
                    // 通知ReadableCurrentState属性变更
                    NotifyPropertyChanged("ReadableCurrentState");
                    // 通知
                    NotifyPropertyChanged("CanReboot");
                }
            }
        }

        /// <summary>
        /// 获取综合的当前状态
        /// </summary>
        public string ReadableCurrentState
        {
            get 
            {
#if (!DEBUG)
                if (this.mIsLicensed)
#endif
                {
                    if (this.mJC5NetworkDriver == null && this.isDeviceRestarting == false)
                        return "Offline";
                    else // Reset和Restart状态可以保持
                        return this.mCurrentState.ToString();
                }
#if (!DEBUG)
                else
                {
                    return "Not Licensed";
                }
#endif
            }
        }

        /// <summary>
        /// 设备当前状态
        /// </summary>
        public IKnitterState CurrentState
        {
            get { return this.mCurrentState; }
            set
            {
                if (value != this.mCurrentState)
                {
                    this.mCurrentState = value;
                    NotifyPropertyChanged("ReadableCurrentState");
                }
            }
        }

        public IKnitterState BootingState
        {
            get
            {
                return this.mKnitterBootingState;
            }
        }

        public IKnitterState IdleState
        {
            get
            {
                return this.mKnitterIdleState;
            }
        }

        public IKnitterState FlushingState
        {
            get
            {
                return this.mKnitterFlushingState;
            }
        }

        public IKnitterState LoadingState
        {
            get
            {
                return this.mKnitterLoadingState;
            }
        }

        public IKnitterState ManufacturingState
        {
            get
            {
                return this.mKnitterManufacturingState;
            }
        }

        public IKnitterState CleaningUpState
        {
            get
            {
                return this.mKnitterCleaningUpState;
            }
        }

        #endregion
    }
}
