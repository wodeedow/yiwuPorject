using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Net;
#if DEBUG
using System.Threading;
using System.Threading.Tasks;
#endif

using DevExpress.XtraSplashScreen;
using DevExpress.Data;
using DevExpress.XtraEditors;

using Ndmt.Model;
using Ndmt.Model.Events;
using Ndmt.Utils;
using UPnPJC5NetworkDriver.Devices;
using UPnPJC5NetworkDriver.Services;
using ManagedUPnP;
using log4net.Core;
using log4net.Appender;
using log4net.Repository.Hierarchy;

using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace Ndmt
{
    public partial class frmKnitterManagement : Form
    {
        public frmKnitterManagement()
        {
            InitializeComponent();
            //LogHelper.Init();
            LicenseMonitor.Init();
            // 记录本窗体程序实例
            instance = this;
            if (!LicenseMonitor.CurrentLicense.IsValidLicenseAvailable)
                this.Text += String.Format(" {0}", LicenseMonitor.TRIAL_VERSION_STRING);//为什么有没有！效果一样
           
        }

        /// <summary>
        /// Occurs when the form loads.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void frmKnitterManagement_Load(object sender, EventArgs e)
        {
            // 调用SplashScreenManager来显示ssLoginForm(或ssLoginImage) Open a Splash Screen
            SplashScreenManager.ShowForm(this, typeof(ssLoginForm), true, true);
            try
            {
                // The splash screen will be opened in a separate thread. To interact with it, use the SendCommand method.
                //public void SendCommand(Enum cmd, object arg);
                //摘要: Sends a command to the currently active splash form.
                //参数: cmd: An enumeration value that identifies the command to be sent to the currently active splash form.
                //arg: The command's parameter.
               
                SplashScreenManager.Default.SendCommand(ssLoginForm.SplashScreenCommand.SetLabelControl, "设备数据加载中...");//ssLoginForm.cs
                // 设备数据源绑定
                BindDeviceDatasourceFromObject();
                // 创建设备快捷方式
                CreateDeviceShortcutWithKnitterEntityBond();
                
                SplashScreenManager.Default.SendCommand(ssLoginForm.SplashScreenCommand.SetLabelControl, "订单数据加载中...");
                // 订单数据加载,(排班表里的详细信息)
                BindShiftDatasourceFromDatabase();

                SplashScreenManager.Default.SendCommand(ssLoginForm.SplashScreenCommand.SetLabelControl, "界面加载中...");
                // 绑定日志到rtbConsole, rtbLog
                BindComponentToConsoleDatasource();
                BindComponentToLogDatasource();
                // 开启日志监听
                StartLog4NetListening();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                LogHelper.LogHere("GeneralException",err.StackTrace);
            }

            // 检查Windows防火墙
            SplashScreenManager.Default.SendCommand(ssLoginForm.SplashScreenCommand.SetLabelControl, "检查防火墙中...");
            ManagedUPnP.WindowsFirewall.CheckUPnPFirewallRules(null);

            // 关闭显示的软件启动界面
            SplashScreenManager.CloseForm();

            // 开启GUI线程安全的UPnP搜索
            this.UPnP.SearchURI = JC5NetworkDriver.DeviceType;//?
            this.UPnP.Active = true;
            LogHelper.LogHere("StartUPnPListening");
        }

        /// <summary>
        /// 设备数据源绑定
        /// XtraGrid: dgvDeviceList
        ///   +--- DataSource ----->  RealTimeSource: mDeviceBindingSource
        ///                                 +--- DataSource -----> Object: KnitterEntity.History 
        /// 
        /// </summary>
        private void BindDeviceDatasourceFromObject()
        {
            Debug.Assert(this.dgvDeviceList.DataSource == null);
            this.mDeviceBindingSource.DataSource = KnitterEntity.HistoryKnitter;
            //获得历史设备数据,将List中的数据作为数据源
            this.mRealTimeDeviceBindingSource.DataSource = this.mDeviceBindingSource.DataSource;//获得历史的设备数据,为什么必须两部？
            //RealTimeSource实现数据实时绑定
            KnitterEntity.HistoryKnitter.RemovingItem +=
               new EventHandler<SearchableBindingList<KnitterEntity>.RemoveItemEventArgs>(this.KnitterHistoryRemoving);//纠结
            this.gcDeviceList.DataSource = this.mRealTimeDeviceBindingSource.DataSource;
           LogHelper.LogHere("BindDeviceDatasourceFromObject");
            this.dgvDeviceList.OptionsView.WaitAnimationOptions = WaitAnimationOptions.Indicator;
        }

        /// <summary>
        /// 订单数据源绑定
        /// XtraGrid: gvScheduling
        ///     +--- DataSource ----->  XPInstantFeedbackSource: mShiftBindingSource
        ///                                     +--- FixFilterString -----> CriteriaOperator: criteria
        /// </summary>
        private void BindShiftDatasourceFromDatabase()
        {
            //http://documentation.devexpress.com/#XPO/clsDevExpressXpoXPInstantFeedbackSourcetopic
            // Create a filter that selects records where [FinishTime] is null
            CriteriaOperator criteria = CriteriaOperator.Parse("[FinishTime] is null");//这句筛选还没有结束的订单
            // Initialize an XPInstantFeedbackSource data source ，supplying data from the ShiftEntity 
            //DisplayableProperties = String.Join(";", enumString.ToArray<string>());从Shift类中找到符合criteria标准的表中的内容作为数据源
            this.mShiftBindingSource = new XPInstantFeedbackSource(typeof(ShiftEntity), ShiftEntity.DisplayableProperties, criteria);
            this.gcScheduling.DataSource = this.mShiftBindingSource;
            this.gvScheduling.OptionsView.WaitAnimationOptions = WaitAnimationOptions.Panel;
           // MessageBox.Show(ShiftEntity.DisplayableProperties);
        }

        /// <summary>
        /// 创建设备快捷方式，显示在设备列表下方的设备图
        /// Click Button --> Raise Button.Click --> Handle by DeviceButton_Click
        ///  --> Raise DeviceShortcutClickEvent --> Handle by DeviceShortcut_Click
        /// </summary>
        private void CreateDeviceShortcutWithKnitterEntityBond()// 
        {
           LogHelper.LogHere("CreateDeviceShortcutWithKnitterEntityBond");
            // 注册统一设备快捷方式单击响应函数
            this.DeviceShortcutClickEvent += this.DeviceShortcut_Click;
            // 根据序列号建立索引
            this.mDeviceButtons = new Dictionary<string, System.Windows.Forms.Button>();//初始化Dictionary<>
            foreach (KnitterEntity ke in KnitterEntity.HistoryKnitter)//属性   将快捷方式加入到左侧控件中
            {
                System.Windows.Forms.Button deviceShortcut = InitDeviceButton(ke.SerialNumber);//?
                this.flpDeviceList.Controls.Add(deviceShortcut);
                this.mDeviceButtons.Add(ke.SerialNumber, deviceShortcut);
            }
        }

        /// <summary>
        /// rtbConsole日志数据绑定
        /// </summary>
        private void BindComponentToConsoleDatasource()
        {
            LogHelper.LogHere("BindComponentToConsoleDatasource");
            BindingSource consoleBindingSource = new BindingSource();
            consoleBindingSource.DataSource = this.mConsoleDatasource;
            this.mConsoleDatasource.ToStringDelegateImpl += (item =>
            {
                LoggingEvent ev = item as LoggingEvent;
                return String.Format(LogHelper.MAConversionPattern, ev.TimeStamp, ev.ThreadName, ev.Level, ev.RenderedMessage);
            });
            this.rtbConsole.DataBindings.Clear();
            this.rtbConsole.DataBindings.Add("Text", consoleBindingSource, "Joint", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// rtbLog日志数据绑定
        /// </summary>
        private void BindComponentToLogDatasource()
        {
            LogHelper.LogHere("BindComponentToLogDatasource");
            BindingSource logBindingSource = new BindingSource();
            logBindingSource.DataSource = this.mLogDatasource;
            this.mLogDatasource.ToStringDelegateImpl += (item =>           //ToStringDelegateImpl是一个委托链
            {
                LoggingEvent ev = item as LoggingEvent;
                return String.Format(LogHelper.MAConversionPattern, ev.TimeStamp, ev.ThreadName, ev.Level, ev.RenderedMessage);
            });
            this.rtbLog.DataBindings.Clear();
            this.rtbLog.DataBindings.Add("Text", logBindingSource, "Joint", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// 开始日志监听
        /// </summary>
        private void StartLog4NetListening()
        {
            LogHelper.LogHere("StartLog4NetListening");
            this.bgwLog4netListener.RunWorkerAsync();
#if DEBUG
            /*
            Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        LogHelper.LogHere("TestString");
                        System.Threading.Thread.Sleep(1000);
                    }
                }, this.mCancelTokenSource.Token);
             */
#endif
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmKnitterManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: 
#if !DEBUG
            if (MessageBox.Show("确定要退出程序吗？", "确认退出",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
#endif
            {
                this.UPnP.Active = false;
            }
#if !DEBUG
            else 
            {
                e.Cancel = true;
            }
#endif
        }

        /// <summary>
        /// UPnP Device Added event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UPnP_DeviceAdded(object sender, ManagedUPnP.DeviceAddedEventArgs e)
        {
            LogHelper.LogHere("UPnPDeviceOnline", e.Device.SerialNumber);
            //public virtual int Find(PropertyDescriptor prop, object key);
            // 查询数据集中具有相同序列号的实体
            //   prop: 要搜索的 System.ComponentModel.PropertyDescriptor。
            //   key:要匹配的 prop 值。
            int index = this.mDeviceBindingSource.Find(KnitterEntity.SearchBySerialNumProperty,e.Device.SerialNumber);
            if (index == -1)  //-1为找不到历史设备
            {
                KnitterEntity ke = new KnitterEntity(e.Device.FriendlyName, e.Device.SerialNumber);
                // 历史设备数据集中添加数据
                index = KnitterEntity.HistoryKnitter.Count - 1;//Count从1
                // 数据持久化
                KnitterEntity.PersistToHistoryFile();
                // 在左侧快捷方式中加入设备按钮
                System.Windows.Forms.Button deviceShortcut = InitDeviceButton(ke.SerialNumber);
                deviceShortcut.Click += new EventHandler(this.DeviceButton_Click);
                this.flpDeviceList.Controls.Add(deviceShortcut);
                // 按钮建立索引
                this.mDeviceButtons.Add(ke.SerialNumber, deviceShortcut);
            }
            // 填充实例
            KnitterEntity.HistoryKnitter[index].JC5NetworkDriverUPnP =
                    new JC5NetworkDriver(e.Device, DeviceCheckFlags.DeviceType);
            this.mDeviceButtons[e.Device.SerialNumber].Image = global::Ndmt.Properties.Resources._JC5online;
        }

        /// <summary>
        /// UPnP Device Deleted event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UPnP_DeviceRemoved(object sender, ManagedUPnP.DeviceRemovedEventArgs e)
        {
            String serialNumber = KnitterEntity.UDNToSerialNumber(e.UDN);
            LogHelper.LogHere("UPnPDeviceOffline", serialNumber);
            // 查询数据集中具有相同序列号的实体
            int index = this.mDeviceBindingSource.Find(KnitterEntity.SearchBySerialNumProperty, serialNumber);
            if (index != -1)//如果找不到
            {
                KnitterEntity ke = KnitterEntity.HistoryKnitter[index];
                ke.JC5NetworkDriverUPnP = null;
                this.mDeviceButtons[ke.SerialNumber].Image = global::Ndmt.Properties.Resources._JC5offline;
            }
        }

        /// <summary>
        /// 通过所选日期范围筛选日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bLogInquiry_Click(object sender, EventArgs e)
        {
            if (this.ckbInquiryByDate.Checked)
            {
                DateTime fromDate = this.dtpFromDate.Value;
                DateTime toDate = this.dtpToDate.Value;
                this.mLogDatasource.FilterDelegateImpl = (queue =>
                {
                    return from item in queue
                           where (item.TimeStamp.CompareTo(fromDate) >= 0 && item.TimeStamp.CompareTo(toDate) <= 0)
                           select item;//LINQ
                });
            }
            else
            {
                this.mLogDatasource.FilterDelegateImpl = null;
            }
        }

        #region MenuStrip Implentations

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 设备管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDeviceManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("缺少指明具体设备"+ License.Status.HardwareID);
            this.Text += License.Status.Licensed;
        }

        /// <summary>
        /// 设置选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPreference_Click(object sender, EventArgs e)
        {
            frmPreference preferenceDlg = new frmPreference();
            preferenceDlg.ShowDialog(this);
        }

        /// <summary>
        /// 重载排班表
        /// </summary>m,
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 重载排班表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastExcelFileName == null)
            {
                OpenFileDialog opfdlg = new OpenFileDialog();
                if (opfdlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else lastExcelFileName = opfdlg.FileName;
            }
            this.bgwReloadShift.RunWorkerAsync();
        }

        /// <summary>
        /// 刷新排班表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmsiRefreshScheduling_Click(object sender, EventArgs e)
        {
            RefreshShiftDS(sender, e);
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshShiftDS(object sender, EventArgs e)
        {
            this.mShiftBindingSource.Refresh();
            //LogHelper.LogHere("RefillShiftDataset");
        }

        /// <summary>
        /// 重新开始扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmsiRescan_Click(object sender, EventArgs e)
        {
            this.UPnP.Active = false;
            this.UPnP.Active = true;
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout dlgAbout = new frmAbout();
            dlgAbout.Show();
        }

        #endregion

        /// <summary>
        /// 设备删除事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KnitterHistoryRemoving(object sender, SearchableBindingList<KnitterEntity>.RemoveItemEventArgs e)//?没用到
        {
            KnitterEntity ke = e.RemovedItem as KnitterEntity;//as:与强制类型转换是一样的,但是永远不会抛出异常,即如果转换不成功,会返回null
            LogHelper.LogHere("RemoveDeviceShortcutFromUI", ke.SerialNumber);
            // 从界面上删除快捷方式
            Button deviceShortcut = this.mDeviceButtons[ke.SerialNumber];//得到快捷方式的序列号
            this.flpDeviceList.Controls.Remove(deviceShortcut);
            // 从索引中删除快捷方式
            this.mDeviceButtons.Remove(ke.SerialNumber);//移除元素的键
        }

        #region Private Event

        /// <summary>
        /// 设备快捷方式按键的默认单击事件，触发DeviceShortcutClickEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceButton_Click(object sender, EventArgs e)
        {
            // 从Button的Name中属性获得序列号
            string name = (sender as System.Windows.Forms.Button).Name;
            string serialNumber = name.Substring(name.Length - KnitterEntity.SERIAL_NUMBER_WIDTH);//括号中为此实例中子字符串的起始字符位置？
            //InitDeviceButton()函数中 deviceButton.Name = String.Format(DEVICE_BUTTON_NAME, serialNumber); 在Name属性中保存序列号
            
            LogHelper.LogHere("DeviceShortcutButtonClicked", serialNumber);
            // 通过序列号检索KnitterEntity的索引
            int index = this.mDeviceBindingSource.Find(KnitterEntity.SearchBySerialNumProperty, serialNumber);
            KnitterEntity ke = KnitterEntity.HistoryKnitter[index];
            //TODO: 正式发布时检查
            //if (ke.IsOnline && DeviceShortcutClickEvent != null)
            if (DeviceShortcutClickEvent != null)
            {
                DeviceShortcutClickEventArgs dscea = new DeviceShortcutClickEventArgs(ke);
                DeviceShortcutClickEvent(this, dscea);
            }

        }

        /// <summary>
        /// 设备快捷方式按钮按键事件响应处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceShortcut_Click(object sender, DeviceShortcutClickEventArgs e)
        {
            LogHelper.LogHere("EnterDeviceShortcutEvent", e.KnitterEntityBound.SerialNumber);
            frmDevice deviceDlg = new frmDevice(e.KnitterEntityBound);
            deviceDlg.ShowDialog(this);
        }

        /// <summary>
        /// 设备快捷方式按钮按键事件参数
        /// </summary>
        private class DeviceShortcutClickEventArgs : EventArgs  //基于EventArgs类的自定义类，包含mKnitterEntity信息
        {
            private KnitterEntity mKnitterEntity;
           // http://msdn.microsoft.com/zh-cn/library/w369ty8x(v=vs.90).aspx
            internal DeviceShortcutClickEventArgs(KnitterEntity ke)
                : base()
            {
                this.mKnitterEntity = ke;
            }

            public KnitterEntity KnitterEntityBound
            {
                get { return this.mKnitterEntity; }
            }
        }

        /// <summary>
        /// 设备快捷方式按钮按键事件响应
        /// </summary>
        /// 使用的是泛型,不需要自定义委托。将事件类型指定为 EventHandler<...>，在尖括号内放置自己的类的名称。
        // Declare the event using EventHandler<T>
        private event EventHandler<DeviceShortcutClickEventArgs> DeviceShortcutClickEvent;//利用委托来声明事件

        #endregion

        #region BackgroundWorker Implentations


        private void bgwLog4netListener_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Tasks.Parallel.Invoke(
                    () =>//Invoke方法参数是一系列的委托，{方法}通过 () =>绑定到委托
                    {
                        LoggingEvent[] events = consoleAppender.GetEvents();
                        if (events != null && events.Length > 0)
                        {
                            consoleAppender.Clear();
                            this.Invoke((System.Action)delegate
                            {
                                foreach (LoggingEvent ev in events)
                                {
                                    this.mConsoleDatasource.Enqueue(ev);
                                }
                                this.rtbConsole.Select(this.rtbConsole.Text.Length, 0);
                                this.rtbConsole.ScrollToCaret();
                            });
                        }
                    },
                    //delegate()
                    //{
                    //    LoggingEvent[] events = consoleAppender.GetEvents();
                    //    if (events != null && events.Length > 0)
                    //    {
                    //        consoleAppender.Clear();
                    //        this.Invoke((System.Action)delegate
                    //        {
                    //            foreach (LoggingEvent ev in events)
                    //            {
                    //                this.mConsoleDatasource.Enqueue(ev);
                    //            }
                    //            this.rtbConsole.Select(this.rtbConsole.Text.Length, 0);
                    //            this.rtbConsole.ScrollToCaret();
                    //        });
                    //    }
                    //},
                    () =>
                    {
                        LoggingEvent[] events = logAppender.GetEvents();
                        if (events != null && events.Length > 0)
                        {
                            logAppender.Clear();
                            this.Invoke((System.Action)delegate
                            {
                                foreach (LoggingEvent ev in events)
                                {
                                    this.mLogDatasource.Enqueue(ev);
                                }
                            });
                        }
                    });
                System.Threading.Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 重载排班表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReloadShift_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelHelper.ReloadSampleShift(lastExcelFileName);
        }

        /// <summary>
        /// 重载排班表完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReloadShift_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LogHelper.LogHere("SampleShiftReloadFinished");
        }

        #endregion

        /// <summary>
        /// 设备快捷方式索引
        /// </summary>
        private Dictionary<string,System.Windows.Forms.Button> mDeviceButtons;

        private const string DEVICE_BUTTON_NAME = "bDevice{0}";//为什么还要加上bDevice
        
        /// <summary>
        /// 获得设备快捷方式按键                                              
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private System.Windows.Forms.Button InitDeviceButton(string serialNumber)//根据设备序列号初始化设备快捷键
        {
            LogHelper.LogHere("DeviceShortcutButtonCreated", serialNumber);
            System.Windows.Forms.Button deviceButton = new System.Windows.Forms.Button();
            deviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            deviceButton.Image = global::Ndmt.Properties.Resources._JC5offline;
            deviceButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            deviceButton.Name = String.Format(DEVICE_BUTTON_NAME, serialNumber); // 在Name属性中保存序列号
            deviceButton.Size = new System.Drawing.Size(48, 48);
            deviceButton.UseVisualStyleBackColor = true;
            // 按钮单击事件
            deviceButton.Click += new EventHandler(this.DeviceButton_Click);

            return deviceButton;
        }

        #region Private Members

        // 日志记录
        private MemoryAppender consoleAppender = LogHelper.RegisteredConsoleAppender;
        private MemoryAppender logAppender = LogHelper.RegisteredLogAppender;
        private string lastExcelFileName = null;
        // 设备列表绑定源
        private BindingSource mDeviceBindingSource = new BindingSource();
        private RealTimeSource mRealTimeDeviceBindingSource = new RealTimeSource();
        private XPInstantFeedbackSource mShiftBindingSource;

        // 日志数据源
        private FixedLengthQueue<LoggingEvent> mConsoleDatasource = new FixedLengthQueue<LoggingEvent>(500);
        private FixedLengthQueue<LoggingEvent> mLogDatasource = new FixedLengthQueue<LoggingEvent>(500);

        // 主程序对象实例
        private static frmKnitterManagement instance = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// 获得窗体对象实例
        /// </summary>
        public static frmKnitterManagement Instance
        {
            get { return instance; }
        }

        #endregion

        private void msMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // 两个实体集， 三个数据源！！
    }
}
