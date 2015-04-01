using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

using ManagedUPnP;
using Ndmt.Utils;
using Ndmt.Model.Events;
using UPnPJC5NetworkDriver.Devices;
using UPnPJC5NetworkDriver.Services;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;


namespace Ndmt.Model
{
    /// <summary>
    /// 编织机设备实体
    /// </summary>
    public partial class KnitterEntity : INotifyPropertyChanged
    {
        #region Basic 

        /// <summary>
        /// 默认的构造函数
        /// </summary>
        private KnitterEntity() 
        {
            // 初始化状态变量
            this.mKnitterBootingState = new KnitterBootingState(this);
            this.mKnitterIdleState = new KnitterIdleState(this);
            this.mKnitterFlushingState = new KnitterFlushingState(this);
            this.mKnitterLoadingState = new KnitterLoadingState(this);
            this.mKnitterManufacturingState = new KnitterManufacturingState(this);
            this.mKnitterCleaningUpState = new KnitterCleaningUpState(this);
            // 设置当前状态
            this.mCurrentState = this.mKnitterIdleState;

            // 私有字段默认
            this.mIPAddr = IPAddress.None;
            this.mMacAddr = PhysicalAddress.None;
            this.mFriendlyName = String.Empty;

            // 注册内部应对事件处理函数
            
           
            this.Online += new EventHandler<EventArgs>(this.OnlineEventHandler);
            this.Offline += new EventHandler<EventArgs>(this.OfflineEventHandler);
            this.FriendlyNameChanged += new EventHandler<FriendlyNameChangedEventArgs>(this.FriendlyNameChangedEventHandler);

        }

        /// <summary>
        /// 仅供从文件读取历史设备并创建对象使用
        /// </summary>
        /// <param name="friendlyName">设备机位号</param>
        /// <param name="serialNumber">设备序列号</param>
        public KnitterEntity(string friendlyName, string serialNumber)
            : this()
        {
            this.mFriendlyName = friendlyName;
            this.mSerialNumber = serialNumber;
            this.mIsLicensed = ValidSerialNumber(serialNumber);

            // 加入历史列表
            KnitterEntity.mHistoryKnitter.Add(this);//实体的历史列表！
            // ---------------------------------------------------------------------------
            this.mSingleHistoryElement = new XElement("Knitter",
                    new XAttribute("ID", this.mSerialNumber),
                    new XElement("FriendlyName", this.mFriendlyName)); // TODO: 考虑使用CDATA
            // 加入XML存储
            KnitterEntity.mHistoryStorage.Element("HistoryKnitters").Add(this.mSingleHistoryElement);
            //mHistoryStorage xml节点！实体和xml节点绑定！还有一个地方
            //主要看整体结构！画图  还有一个地方没找到！
            //逻辑结构 方法 属性关系画出来 想法理清  小想法支持大想法 概括为几句话
            //knitterControl1是由软件自动生成的
            //每个设备的实例存在于mHistoryKnitter，每个实例的属性（mSingleHistoryElement单独历史节点）XElement存入，
            //添加到mHistoryStorage,此时mHistoryStorage中包括所有（新加入的，老的）设备信息

            this.mShiftEntityTracker = new UnitOfWork(XpoDefault.DataLayer);
            CriteriaOperator criteria = CriteriaOperator.Parse("[FinishTime] is null && [KnitterFriendlyName] = ?", this.FriendlyName);//
            this.mShiftEntityCollection = new XPCollection<ShiftEntity>(this.mShiftEntityTracker, criteria);
            //XPO中查询数据：对于查询，就是指定一定的条件获取一个数据集合。在XPO中，返回结果的集合用XPCollection作统一处理
            //查询符合criteria 标准的ShiftEntity实体
        }                      
        //静态构造函数用于初始化任何静态数据，或用于执行仅需执行一次的特定操作。在创建第一个实例或引用任何静态成员之前，将自动调用静态构造函数。
        static KnitterEntity()
        {
            mSearchBySerialNumProperty = TypeDescriptor.GetProperties(typeof(KnitterEntity)).Find("SerialNumber", false);//返回具有指定序列号的PropertyDescriptor
            mSearchByFriendlyNameProperty = TypeDescriptor.GetProperties(typeof(KnitterEntity)).Find("FriendlyName", false);
            // ---------------------------------------------------------------------------
            mHistoryKnitter = new SearchableBindingList<KnitterEntity>();
            // 出现新设备时
            mHistoryKnitter.AllowNew = true;
            // 通过界面将某设备删除时
            mHistoryKnitter.AllowRemove = true;
            // 正常运行时
            mHistoryKnitter.AllowEdit = true;
            mHistoryKnitter.RemovingItem += KnitterHistoryRemoving;
            // ---------------------------------------------------------------------------
            mHistoryStorage = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),   //不写不行吗？
                new XElement("HistoryKnitters", null)); //首先新建一个空的xml文档，再将历史数据存进去
            // 加载历史设备数据

            LoadHistoryFromFile();
        }

        /// <summary>
        /// 加载历史设备数据
        /// </summary>
        private static void LoadHistoryFromFile()
        {
            if (File.Exists(HISTORY_FILE_NAME))//@"history.db"
            {
                XDocument raw = XDocument.Load(HISTORY_FILE_NAME);
                foreach (XElement ke in raw.Element("HistoryKnitters").Descendants("Knitter"))
                {
                    new KnitterEntity(ke.Element("FriendlyName").Value, ke.Attribute("ID").Value);//ID号即序列号
                    //
                }
            }
        }

        /// <summary>
        /// 历史设备写回文件
        /// </summary>
        public static void PersistToHistoryFile()
        {
            mHistoryStorage.Save(HISTORY_FILE_NAME, SaveOptions.None);
        }

        /// <summary>
        /// UDN提取序列号
        /// </summary>
        /// <param name="udn">UPnP设备的Unique Device Name</param>
        /// <returns></returns>
        public static string UDNToSerialNumber(string udn)
        {
            return Regex.Match(udn, UDN_TO_SERIAL_NUMBER).Groups["SerialNumber"].ToString();//?
            // 参数:
        //   input:
        //     要搜索匹配项的字符串。
        //
        //   pattern:
        //     要匹配的正则表达式模式。
        //
        // 返回结果:
        //     一个对象，包含有关匹配项的信息。
        }

        /// <summary>
        /// 验证所给的SerialNumber是否是在证书中?
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private static bool ValidSerialNumber(string serialNumber)
        {
            if (LicenseMonitor.CurrentLicense.IsValidLicenseAvailable)
                return serialNumber.StartsWith(LicenseMonitor.CurrentLicense[LicenseMonitor.Properties.SNPrefix]);
            else 
                return false;
        }

        /// <summary>
        /// 验证即将设置的FriendlyName是否合法
        /// </summary>
        /// <param name="friendlyName"></param>
        /// <returns></returns>
        public static bool ValidFriendlyName(string friendlyName)
        {
            return (friendlyName != null) && (!Regex.IsMatch(friendlyName, FRIENDLY_NAME_VALIDATOR));//不空 不包括<，>，&，""，''
        }
        #endregion

        #region Device Event Handler

        /// <summary>
        /// 响应KnitterControl状态变量JC5WorkingStatus变更通知
        /// </summary>
        /// <param name="sender">KnitterControl</param>
        /// <param name="e">状态变更事件变量</param>
        public void OnJC5WorkingStateChanged(object sender, StateVariableChangedEventArgs<KnitterControl1.JC5WorkingStatusEnum> e)
        {
            switch (e.StateVarValue)
            {
                case KnitterControl1.JC5WorkingStatusEnum._0:
                    OnReady(sender, e);
                    break;
                case KnitterControl1.JC5WorkingStatusEnum._1:
                    OnButtonNextPressed(sender, e);
                    break;
                case KnitterControl1.JC5WorkingStatusEnum._2:
                    OnButtonFinishPressed(sender, e);
                    break;
                case KnitterControl1.JC5WorkingStatusEnum._Unknown:
                    break;
            }
        }

        /// <summary>
        /// JC5 Network Driver的状态变量JC5WorkingStatus变为0时，或启动完成后UPnP发现该设备
        /// </summary>
        public void OnReady(object sender, EventArgs e)
        {
            // 进入空闲状态
            CurrentState.Ready();
            // 初始化
            IdleInit();
        }

        /// <summary>
        /// JC5 Network Driver的状态变量JC5WorkingStatus变为1时
        /// </summary>
        public void OnButtonNextPressed(object sender, EventArgs e)
        {
            // 若Next信号早于上线初始化完成则等待
            this.mCanNextButtonHandlerProceed.WaitOne();
            // 创建任务
            CreateFlushAndLoadTask();
            // 任务启动，处于WaitToRun状态
            this.mWorkerThread.Start();
        }

        /// <summary>
        /// JC5 Network Driver的状态变量JC5WorkingStatus变为2时
        /// </summary>
        public void OnButtonFinishPressed(object sender, EventArgs e)
        {
            // 若Finish信号发生时之前任务未完成则等待
            this.mCanFinishButtonHandlerProceed.WaitOne();
            // 记录结束时间 CurrentState = Manufacturing -> CleaningUp
            CurrentState.LogEventTime();
            // 通知设备进入空闲状态，但不进行状态流转
            NotifyOrderFinished();
        }

        /// <summary>
        /// 响应KnitterControl状态变量FriendlyName变更通知
        /// </summary>
        /// <param name="sender">KnitterControl</param>
        /// <param name="e">状态变更事件变量</param>
        public void OnFriendlyNameChanged(object sender, StateVariableChangedEventArgs<String> e)
        {
            this.FriendlyName = e.StateVarValue;
        }

        /// <summary>
        /// 响应KnitterControl状态变量CanMountExStorage变更通知
        /// </summary>
        /// <param name="sender">KnitterControl</param>
        /// <param name="e"></param>
        public void OnCanMountExStorageChanged(object sender, StateVariableChangedEventArgs<Boolean> e)
        {
            if (e.StateVarValue == true)//若设备状态改变
                this.mCanMountSignal.Set();
            else
                this.mCanMountSignal.Reset();
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion

        #region Public Event

        /// <summary>
        /// 设备机台名更改事件
        /// </summary>
        public event EventHandler<FriendlyNameChangedEventArgs> FriendlyNameChanged;

        private void NotifyFriendlyNameChanged(FriendlyNameChangedEventArgs e)
        {
            LogHelper.LogHere("NotifyFriendlyNameChanged", e.OldFriendlyName, e.NewFriendlyName);
            if (FriendlyNameChanged != null)
                FriendlyNameChanged(this, e);
        }

        /// <summary>
        /// 上线事件
        /// </summary>
        public event EventHandler<EventArgs> Online;

        private void NotifyKnitterOnline()
        {
            if (Online != null)
                Online(this, EventArgs.Empty);
        }

        /// <summary>
        /// 下线事件
        /// </summary>
        public event EventHandler<EventArgs> Offline;

        private void NotifyKnitterOffline()
        {
            if (Offline != null)
                Offline(this, EventArgs.Empty);
            //EventArgs是事件的集合,this表示把当前实例做为一个参数传入，
            //EventArgs.empty表示传入一个空的事件源。EventArgs是一个枚举类型的，其中一个值empty表示空
        }

        /// <summary>
        /// 订单数据刷新事件
        /// </summary>
        public event EventHandler<EventArgs> ShiftDSNeedsRefresh;

        private void RefreashShiftDS()//这个函数用到了吗?
        {
            if (ShiftDSNeedsRefresh != null)
                ShiftDSNeedsRefresh(this, EventArgs.Empty);
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 实体自身响应上线事件
        /// </summary>
        /// <param name="sender">KnitterEntity实例</param>
        /// <param name="e"></param>
        private void OnlineEventHandler(object sender, EventArgs e)
        {
            Parallel.Invoke(//并行执行两个，所有的任务都是并发的，不保证先后次序
                () =>
                {
                    // 获得IP地址
                    this.DeviceIPAddress = this.mJC5NetworkDriver.RootHostAddresses.First();
                    // 获取MAC地址
                    this.DeviceMacAddress = GetRemoteMacAddress();

                },// close first Action
                () =>
                {
                    // 注册JC5WorkingState状态变更事件处理
                    this.JC5NetworkDriverUPnP.KnitterControl1Service.JC5WorkingStatusChanged +=
                         new StateVariableChangedEventHandler<KnitterControl1.JC5WorkingStatusEnum>(this.OnJC5WorkingStateChanged);
                    // 注册FriendlyName状态变更事件处理
                    this.JC5NetworkDriverUPnP.KnitterControl1Service.FriendlyNameChanged +=
                        new StateVariableChangedEventHandler<string>(this.OnFriendlyNameChanged);
                    // 注册CanMountExStorage状态变更事件处理
                    this.JC5NetworkDriverUPnP.KnitterControl1Service.CanMountExStorageChanged +=
                        new StateVariableChangedEventHandler<bool>(this.OnCanMountExStorageChanged);
                });
            
        }

        /// <summary>
        /// 实体自身响应下线事件
        /// </summary>
        /// <param name="sender">KnitterEntity实例</param>
        /// <param name="e"></param>
        private void OfflineEventHandler(object sender, EventArgs e)
        {
            this.DeviceIPAddress = IPAddress.None;
            this.DeviceMacAddress = PhysicalAddress.None;
            CancelCurrentTask(); 
        }

        /// <summary>
        /// 实体自身响应FriendlyName变更事件
        /// </summary>
        /// <param name="sender">KnitterEntity实例</param>
        /// <param name="e"></param>
        private void FriendlyNameChangedEventHandler(object sender, EventArgs e)//机位号什么时候会改变，阻止线程后？
        {
            this.mCanNextButtonHandlerProceed.Reset();//
            // 修改XML结点信息
            this.mSingleHistoryElement.Element("FriendlyName").Value = this.mFriendlyName;
            // 保存结果
            PersistToHistoryFile();
            // 重置筛选准则
            //is null类似于查询语句，？被this.firnendlyname取代
            this.mShiftEntityCollection.Criteria = CriteriaOperator.Parse("[FinishTime] is null && [KnitterFriendlyName] = ?", this.FriendlyName);
            this.mCanNextButtonHandlerProceed.Set();//设置它为有信号状态,用它的有信号状态来表示一个线程的结束
        }

        /// <summary>
        /// 实体自身响应删除设备事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private static void KnitterHistoryRemoving(object sender, SearchableBindingList<KnitterEntity>.RemoveItemEventArgs ev)
        {
            // XML结点删除
            ev.RemovedItem.mSingleHistoryElement.Remove();
            // 保存结果
            PersistToHistoryFile();
        }

        #endregion

        /// <summary>
        /// 创建装载任务
        /// </summary>
        private void CreateFlushAndLoadTask()
        {
            // 生成新的取消标记
            this.mTokenSrc = new System.Threading.CancellationTokenSource();
            CancellationToken token = this.mTokenSrc.Token;
            // Define the cancellation token.

            // 调用mToken.Cancel()时的委托函数
            token.Register(() =>
            {
                try
                {
                    ResetToIdle();//>重置机台 #{0} 空闲状态(IDLE)//reset没实现 没有恢复出厂设置  
                }
                catch (TransportException transex)
                {
                    TransportExceptionLogDispatcher(transex);
                    this.mJC5NetworkDriver = null;
                }
            });
            
            // 带停止标记的工作线程初始化
            this.mWorkerThread = new Task(() =>
            {
                try
                {
                    // ---------------------------------------------------------------------------
                    token.ThrowIfCancellationRequested();//
                    // 加载最新订单
                    LoadCurrentShift();
                    // 记录开始时间 CurrentState = Idle -> Idle
                    CurrentState.LogEventTime();
                    // ---------------------------------------------------------------------------
                    token.ThrowIfCancellationRequested();
                    // 挂载USB设备 CurrentState = Idle -> Flushing
                    CurrentState.MountExStorage();
                    // ---------------------------------------------------------------------------
                    // 等待挂载成功信号
                    if (this.mCanMountSignal.WaitOne(WAIT_SIGNAL_OVERTIME_SECONDS * 1000) == false)//如果6秒内收不到信号
                        throw new TransportException(TransportException.WaitForCanMountSignalOvertime, "WaitForCanMountSignal", TransportException.TransportErrorCode.USB_BUSY);
                    
                    token.ThrowIfCancellationRequested();
                    // 清空FTP中图案并装载 CurrentState = Flushing -> Loading
                    CurrentState.FlushAndLoadPatternEP();
                    // ---------------------------------------------------------------------------
                    token.ThrowIfCancellationRequested();
                    // 卸载USB设备 CurrentState = Loading -> Manufacturing
                    CurrentState.UnmountExStorage();
                    // 发送Finish可执行信号
                    this.mCanFinishButtonHandlerProceed.Set();
                }
                // Cancel Token 触发异常
                catch (OperationCanceledException err)
                {
                    LogHelper.LogHere("CancelTokenRecieved", err.Message);
                }
                // 订单异常
                catch (ShiftProceedingException shiftex)
                {
                    ShiftProceedingExceptionLogDispatcher(shiftex);
                    CancelCurrentTask();
                }
                // 传输异常
                catch (TransportException transex)
                {
                    TransportExceptionLogDispatcher(transex);
                    CancelCurrentTask();
                }
            }, token,TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// 统一TransportException日志处理
        /// </summary>
        /// <param name="transex"></param>
        private void TransportExceptionLogDispatcher(TransportException transex)
        {
            switch (transex.Code)
            {
                case TransportException.TransportErrorCode.USB_BUSY:
                    LogHelper.LogHere("ExStorageMountError", this.FriendlyName, transex.Message);
                    break;
                case TransportException.TransportErrorCode.DATABASE_LINK_ERROR:
                    LogHelper.LogHere("DatabaseLinkError");
                    break;
                default:
                    LogHelper.LogHere("DefaultTransportError", this.FriendlyName);
                    break;
            }
        }

        #region Exception Logging
        /// <summary>
        /// 统一ShiftProceedingException日志处理
        /// </summary>
        /// <param name="shiftex"></param>
        private void ShiftProceedingExceptionLogDispatcher(ShiftProceedingException shiftex)
        {
            if (shiftex.Source == "LoadPatternEP")
            {
                ShiftEntity currentShift = this.mCurrentShiftEntity;
                LogHelper.LogHere("PatternDocumentNotFound", this.FriendlyName, currentShift[ShiftEntity.Properties.ShiftID],
                                                                                currentShift[ShiftEntity.Properties.PatternName],
                                                                                currentShift[ShiftEntity.Properties.DocumentName]);
            }
            else if (shiftex.Source == "LoadCurrentShift")
            {
                LogHelper.LogHere("ShiftOfDeviceNotFound", this.FriendlyName);
            }
        }

        #endregion
        /// <summary>
        /// 获得远程MAC地址
        /// </summary>
        /// <returns></returns>
        private PhysicalAddress GetRemoteMacAddress()
        {
            try
            {
                string localIPAddr = this.mJC5NetworkDriver.AdapterIPAddresses.First().ToString();
                // 远程IP地址
                string remoteIPAddr = this.DeviceIPAddress.ToString();
                // ARP方式获得远程MAC地址。。。
                return PhysicalAddress.Parse(NetworkUtils.GetRemoteMacAddress(localIPAddr, remoteIPAddr).ToUpper());
            }
            catch (Exception err)
            {
                LogHelper.LogHere("GeneralException", err.Message);//返回错误信息
            }
            return PhysicalAddress.None;
        }

        #region Private Locals

        // 工作线程
        private Task mWorkerThread;
        private CancellationTokenSource mTokenSrc;

        // 格式定义
        private const string HISTORY_FILE_NAME = @"history.db";

        private const string UDN_TO_SERIAL_NUMBER = @"uuid:Upnp-JC5-NetworkDriver-1_0-(?<SerialNumber>\d{10})";//为什么要写这么复杂?UND获得设备信息用UDN，他指的就是序列号
        private const string FRIENDLY_NAME_VALIDATOR = @"<|>|&|""|''";
        private const string SHIFT_PATTERN_FILE_NAME = @"{0}\\{1}";
        public const string FRIENDLY_NAME_INVALID_PROMPT = @"请不要包含<,>,&,"",''字符";
        public const int SERIAL_NUMBER_WIDTH = 10;
        private const int WAIT_SIGNAL_OVERTIME_SECONDS = 60;

        // 属性内部存储
        private string mFriendlyName;
        private string mSerialNumber;
        private bool mIsLicensed;
        private IPAddress mIPAddr;
        private PhysicalAddress mMacAddr;
        private static PropertyDescriptor mSearchBySerialNumProperty;
        private static PropertyDescriptor mSearchByFriendlyNameProperty;
        private static SearchableBindingList<KnitterEntity> mHistoryKnitter;
        private static XDocument mHistoryStorage;
        private XElement mSingleHistoryElement;
        private ShiftEntity mCurrentShiftEntity;
        private bool isDeviceRestarting = false;

        private UnitOfWork mShiftEntityTracker;
        private XPCollection<ShiftEntity> mShiftEntityCollection;

        // 多线程等待
        //若要将初始状态设置为非终止，则为 false
        /// <summary>
        /// 等待位置：调用FlushAndLoadPatternEP()前
        /// 切换位置：收到CanMountExStorage状态变量 ---> 执行OnCanMountExStorageChanged()事件处理时
        /// 默认值：需要等待
        /// </summary>
        private AutoResetEvent mCanMountSignal = new AutoResetEvent(false);
         // false,将初始状态设置为非终止。
        /// <summary>
        /// 等待位置：收到JC5WorkingStatus状态变量为1 ---> 执行OnButtonNextPressed()事件处理时
        /// 切换位置：收到JC5WorkingStatus状态变量为0 ---> 执行OnReady()事件处理 ---> 执行IdleInit()时
        /// 默认值：需要等待
        /// </summary>
        private AutoResetEvent mCanNextButtonHandlerProceed = new AutoResetEvent(false);

        /// <summary>
        /// 等待位置：收到JC5WorkingStatus状态变量为2 ---> 执行OnButtonFinishPressed()事件处理时
        /// 切换位置：NextButton处理线程mWorkerThread执行结束时
        /// 默认值：需要等待
        /// </summary>
        private AutoResetEvent mCanFinishButtonHandlerProceed = new AutoResetEvent(false);

        // 状态切换
        private IKnitterState mCurrentState;
        private IKnitterState mKnitterBootingState;
        private IKnitterState mKnitterIdleState;
        private IKnitterState mKnitterFlushingState;
        private IKnitterState mKnitterLoadingState;
        private IKnitterState mKnitterManufacturingState;
        private IKnitterState mKnitterCleaningUpState;

        // UPnP实例
        private JC5NetworkDriver mJC5NetworkDriver;

        private const string mFtpUsername = "admin";
        private const string mFtpPassword = "admin";

        #endregion
    }
}
