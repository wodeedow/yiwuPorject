namespace Ndmt
{
    partial class frmKnitterManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKnitterManagement));
            this.tsmiSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiRefreshScheduling = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiControl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeviceManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiRescan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContactUs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tlpKnitterManagement = new System.Windows.Forms.TableLayoutPanel();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.tcKnitterManagement = new System.Windows.Forms.TabControl();
            this.tpDevice = new System.Windows.Forms.TabPage();
            this.tlpDevice = new System.Windows.Forms.TableLayoutPanel();
            this.pDeviceList = new System.Windows.Forms.Panel();
            this.lbDeviceList1 = new System.Windows.Forms.Label();
            this.flpDeviceList = new System.Windows.Forms.FlowLayoutPanel();
            this.gcDeviceList = new DevExpress.XtraGrid.GridControl();
            this.dgvDeviceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgvtbcDeviceListFriendlyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvtbcDeviceListSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvtbcDeviceListIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvtbcDeviceListMACAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvtbcDeviceListDeviceState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpScheduling = new System.Windows.Forms.TabPage();
            this.gcScheduling = new DevExpress.XtraGrid.GridControl();
            this.gvScheduling = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colddh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coljt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colwdh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkssj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coljssj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colllsj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.bLogSaveAs = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.ckbInquiryByDate = new System.Windows.Forms.CheckBox();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.bLogInquiry = new System.Windows.Forms.Button();
            this.UPnP = new ManagedUPnP.Components.UPnPDiscovery();
            this.bgwReloadShift = new System.ComponentModel.BackgroundWorker();
            this.bgwLog4netListener = new System.ComponentModel.BackgroundWorker();
            this.msMenu.SuspendLayout();
            this.tlpKnitterManagement.SuspendLayout();
            this.tcKnitterManagement.SuspendLayout();
            this.tpDevice.SuspendLayout();
            this.tlpDevice.SuspendLayout();
            this.pDeviceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceList)).BeginInit();
            this.tpScheduling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcScheduling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScheduling)).BeginInit();
            this.tpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UPnP)).BeginInit();
            this.SuspendLayout();
            // 
            // tsmiSystem
            // 
            this.tsmiSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiRefreshScheduling,
            this.tsmiLog,
            this.tsmiExit});
            this.tsmiSystem.Name = "tsmiSystem";
            this.tsmiSystem.Size = new System.Drawing.Size(44, 21);
            this.tsmiSystem.Text = "系统";
            // 
            // tmsiRefreshScheduling
            // 
            this.tmsiRefreshScheduling.Name = "tmsiRefreshScheduling";
            this.tmsiRefreshScheduling.Size = new System.Drawing.Size(136, 22);
            this.tmsiRefreshScheduling.Text = "刷新排班表";
            this.tmsiRefreshScheduling.Click += new System.EventHandler(this.tmsiRefreshScheduling_Click);
            // 
            // tsmiLog
            // 
            this.tsmiLog.Name = "tsmiLog";
            this.tsmiLog.Size = new System.Drawing.Size(136, 22);
            this.tsmiLog.Text = "导出日志";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(136, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiControl
            // 
            this.tsmiControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeviceManagement,
            this.tmsiRescan});
            this.tsmiControl.Name = "tsmiControl";
            this.tsmiControl.Size = new System.Drawing.Size(44, 21);
            this.tsmiControl.Text = "控制";
            // 
            // tsmiDeviceManagement
            // 
            this.tsmiDeviceManagement.Name = "tsmiDeviceManagement";
            this.tsmiDeviceManagement.Size = new System.Drawing.Size(148, 22);
            this.tsmiDeviceManagement.Text = "设备管理...";
            this.tsmiDeviceManagement.Click += new System.EventHandler(this.tsmiDeviceManagement_Click);
            // 
            // tmsiRescan
            // 
            this.tmsiRescan.Name = "tmsiRescan";
            this.tmsiRescan.Size = new System.Drawing.Size(148, 22);
            this.tmsiRescan.Text = "重新搜索设备";
            this.tmsiRescan.Click += new System.EventHandler(this.tmsiRescan_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPreference});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(44, 21);
            this.tsmiSettings.Text = "设置";
            // 
            // tsmiPreference
            // 
            this.tsmiPreference.Name = "tsmiPreference";
            this.tsmiPreference.Size = new System.Drawing.Size(109, 22);
            this.tsmiPreference.Text = "选项...";
            this.tsmiPreference.Click += new System.EventHandler(this.tsmiPreference_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiContactUs,
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 21);
            this.tsmiHelp.Text = "帮助";
            // 
            // tsmiContactUs
            // 
            this.tsmiContactUs.Name = "tsmiContactUs";
            this.tsmiContactUs.Size = new System.Drawing.Size(124, 22);
            this.tsmiContactUs.Text = "联系我们";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(124, 22);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSystem,
            this.tsmiControl,
            this.tsmiSettings,
            this.tsmiHelp});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(784, 25);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(784, 484);
            // 
            // tlpKnitterManagement
            // 
            this.tlpKnitterManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpKnitterManagement.ColumnCount = 1;
            this.tlpKnitterManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKnitterManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKnitterManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKnitterManagement.Controls.Add(this.rtbConsole, 0, 1);
            this.tlpKnitterManagement.Controls.Add(this.tcKnitterManagement, 0, 0);
            this.tlpKnitterManagement.Location = new System.Drawing.Point(0, 28);
            this.tlpKnitterManagement.Name = "tlpKnitterManagement";
            this.tlpKnitterManagement.RowCount = 2;
            this.tlpKnitterManagement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpKnitterManagement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpKnitterManagement.Size = new System.Drawing.Size(784, 533);
            this.tlpKnitterManagement.TabIndex = 2;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.Location = new System.Drawing.Point(3, 376);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(778, 154);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // tcKnitterManagement
            // 
            this.tcKnitterManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcKnitterManagement.Controls.Add(this.tpDevice);
            this.tcKnitterManagement.Controls.Add(this.tpScheduling);
            this.tcKnitterManagement.Controls.Add(this.tpLog);
            this.tcKnitterManagement.Location = new System.Drawing.Point(3, 3);
            this.tcKnitterManagement.Name = "tcKnitterManagement";
            this.tcKnitterManagement.SelectedIndex = 0;
            this.tcKnitterManagement.Size = new System.Drawing.Size(778, 367);
            this.tcKnitterManagement.TabIndex = 1;
            // 
            // tpDevice
            // 
            this.tpDevice.Controls.Add(this.tlpDevice);
            this.tpDevice.Location = new System.Drawing.Point(4, 22);
            this.tpDevice.Margin = new System.Windows.Forms.Padding(0);
            this.tpDevice.Name = "tpDevice";
            this.tpDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tpDevice.Size = new System.Drawing.Size(770, 341);
            this.tpDevice.TabIndex = 0;
            this.tpDevice.Text = "设备";
            this.tpDevice.UseVisualStyleBackColor = true;
            // 
            // tlpDevice
            // 
            this.tlpDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDevice.ColumnCount = 2;
            this.tlpDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDevice.Controls.Add(this.pDeviceList, 0, 0);
            this.tlpDevice.Controls.Add(this.gcDeviceList, 1, 0);
            this.tlpDevice.Location = new System.Drawing.Point(5, 3);
            this.tlpDevice.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDevice.Name = "tlpDevice";
            this.tlpDevice.RowCount = 1;
            this.tlpDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tlpDevice.Size = new System.Drawing.Size(762, 335);
            this.tlpDevice.TabIndex = 0;
            // 
            // pDeviceList
            // 
            this.pDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDeviceList.AutoScroll = true;
            this.pDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDeviceList.Controls.Add(this.lbDeviceList1);
            this.pDeviceList.Controls.Add(this.flpDeviceList);
            this.pDeviceList.Location = new System.Drawing.Point(0, 0);
            this.pDeviceList.Margin = new System.Windows.Forms.Padding(0);
            this.pDeviceList.Name = "pDeviceList";
            this.pDeviceList.Size = new System.Drawing.Size(60, 335);
            this.pDeviceList.TabIndex = 7;
            // 
            // lbDeviceList1
            // 
            this.lbDeviceList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDeviceList1.AutoSize = true;
            this.lbDeviceList1.Location = new System.Drawing.Point(3, 0);
            this.lbDeviceList1.Margin = new System.Windows.Forms.Padding(10);
            this.lbDeviceList1.Name = "lbDeviceList1";
            this.lbDeviceList1.Size = new System.Drawing.Size(53, 12);
            this.lbDeviceList1.TabIndex = 11;
            this.lbDeviceList1.Text = "设备列表";
            this.lbDeviceList1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpDeviceList
            // 
            this.flpDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDeviceList.AutoScroll = true;
            this.flpDeviceList.AutoScrollMinSize = new System.Drawing.Size(20, 50);
            this.flpDeviceList.AutoSize = true;
            this.flpDeviceList.Location = new System.Drawing.Point(3, 15);
            this.flpDeviceList.MaximumSize = new System.Drawing.Size(50, 0);
            this.flpDeviceList.MinimumSize = new System.Drawing.Size(50, 300);
            this.flpDeviceList.Name = "flpDeviceList";
            this.flpDeviceList.Size = new System.Drawing.Size(50, 300);
            this.flpDeviceList.TabIndex = 3;
            // 
            // gcDeviceList
            // 
            this.gcDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDeviceList.Location = new System.Drawing.Point(63, 3);
            this.gcDeviceList.MainView = this.dgvDeviceList;
            this.gcDeviceList.Name = "gcDeviceList";
            this.gcDeviceList.Size = new System.Drawing.Size(696, 329);
            this.gcDeviceList.TabIndex = 8;
            this.gcDeviceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDeviceList});
            // 
            // dgvDeviceList
            // 
            this.dgvDeviceList.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvDeviceList.Appearance.Empty.Options.UseBackColor = true;
            this.dgvDeviceList.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvDeviceList.Appearance.EvenRow.Options.UseBackColor = true;
            this.dgvDeviceList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.dgvDeviceList.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgvDeviceList.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.dgvDeviceList.Appearance.OddRow.Options.UseBackColor = true;
            this.dgvDeviceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dgvtbcDeviceListFriendlyName,
            this.dgvtbcDeviceListSerialNumber,
            this.dgvtbcDeviceListIPAddress,
            this.dgvtbcDeviceListMACAddress,
            this.dgvtbcDeviceListDeviceState});
            this.dgvDeviceList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.dgvDeviceList.GridControl = this.gcDeviceList;
            this.dgvDeviceList.Name = "dgvDeviceList";
            this.dgvDeviceList.OptionsBehavior.Editable = false;
            this.dgvDeviceList.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.dgvDeviceList.OptionsBehavior.ReadOnly = true;
            this.dgvDeviceList.OptionsCustomization.AllowFilter = false;
            this.dgvDeviceList.OptionsCustomization.AllowGroup = false;
            this.dgvDeviceList.OptionsDetail.EnableMasterViewMode = false;
            this.dgvDeviceList.OptionsDetail.ShowDetailTabs = false;
            this.dgvDeviceList.OptionsDetail.SmartDetailExpand = false;
            this.dgvDeviceList.OptionsMenu.EnableColumnMenu = false;
            this.dgvDeviceList.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvDeviceList.OptionsView.EnableAppearanceOddRow = true;
            this.dgvDeviceList.OptionsView.ShowGroupPanel = false;
            // 
            // dgvtbcDeviceListFriendlyName
            // 
            this.dgvtbcDeviceListFriendlyName.Caption = "机位号";
            this.dgvtbcDeviceListFriendlyName.FieldName = "FriendlyName";
            this.dgvtbcDeviceListFriendlyName.Name = "dgvtbcDeviceListFriendlyName";
            this.dgvtbcDeviceListFriendlyName.OptionsColumn.AllowEdit = false;
            this.dgvtbcDeviceListFriendlyName.OptionsColumn.AllowFocus = false;
            this.dgvtbcDeviceListFriendlyName.Visible = true;
            this.dgvtbcDeviceListFriendlyName.VisibleIndex = 0;
            // 
            // dgvtbcDeviceListSerialNumber
            // 
            this.dgvtbcDeviceListSerialNumber.Caption = "序列号";
            this.dgvtbcDeviceListSerialNumber.FieldName = "SerialNumber";
            this.dgvtbcDeviceListSerialNumber.Name = "dgvtbcDeviceListSerialNumber";
            this.dgvtbcDeviceListSerialNumber.OptionsColumn.AllowEdit = false;
            this.dgvtbcDeviceListSerialNumber.OptionsColumn.AllowFocus = false;
            this.dgvtbcDeviceListSerialNumber.Visible = true;
            this.dgvtbcDeviceListSerialNumber.VisibleIndex = 1;
            // 
            // dgvtbcDeviceListIPAddress
            // 
            this.dgvtbcDeviceListIPAddress.Caption = "IP地址";
            this.dgvtbcDeviceListIPAddress.FieldName = "DeviceIPAddress";
            this.dgvtbcDeviceListIPAddress.Name = "dgvtbcDeviceListIPAddress";
            this.dgvtbcDeviceListIPAddress.OptionsColumn.AllowEdit = false;
            this.dgvtbcDeviceListIPAddress.OptionsColumn.AllowFocus = false;
            this.dgvtbcDeviceListIPAddress.Visible = true;
            this.dgvtbcDeviceListIPAddress.VisibleIndex = 2;
            // 
            // dgvtbcDeviceListMACAddress
            // 
            this.dgvtbcDeviceListMACAddress.Caption = "MAC地址";
            this.dgvtbcDeviceListMACAddress.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dgvtbcDeviceListMACAddress.FieldName = "DeviceMacAddress";
            this.dgvtbcDeviceListMACAddress.Name = "dgvtbcDeviceListMACAddress";
            this.dgvtbcDeviceListMACAddress.OptionsColumn.AllowEdit = false;
            this.dgvtbcDeviceListMACAddress.OptionsColumn.AllowFocus = false;
            this.dgvtbcDeviceListMACAddress.Visible = true;
            this.dgvtbcDeviceListMACAddress.VisibleIndex = 3;
            // 
            // dgvtbcDeviceListDeviceState
            // 
            this.dgvtbcDeviceListDeviceState.Caption = "设备状态";
            this.dgvtbcDeviceListDeviceState.FieldName = "ReadableCurrentState";
            this.dgvtbcDeviceListDeviceState.Name = "dgvtbcDeviceListDeviceState";
            this.dgvtbcDeviceListDeviceState.OptionsColumn.AllowEdit = false;
            this.dgvtbcDeviceListDeviceState.OptionsColumn.AllowFocus = false;
            this.dgvtbcDeviceListDeviceState.Visible = true;
            this.dgvtbcDeviceListDeviceState.VisibleIndex = 4;
            // 
            // tpScheduling
            // 
            this.tpScheduling.Controls.Add(this.gcScheduling);
            this.tpScheduling.Location = new System.Drawing.Point(4, 22);
            this.tpScheduling.Name = "tpScheduling";
            this.tpScheduling.Padding = new System.Windows.Forms.Padding(3);
            this.tpScheduling.Size = new System.Drawing.Size(770, 341);
            this.tpScheduling.TabIndex = 1;
            this.tpScheduling.Text = "排班表";
            this.tpScheduling.UseVisualStyleBackColor = true;
            // 
            // gcScheduling
            // 
            this.gcScheduling.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcScheduling.Location = new System.Drawing.Point(3, 3);
            this.gcScheduling.MainView = this.gvScheduling;
            this.gcScheduling.Name = "gcScheduling";
            this.gcScheduling.Size = new System.Drawing.Size(767, 341);
            this.gcScheduling.TabIndex = 14;
            this.gcScheduling.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvScheduling});
            // 
            // gvScheduling
            // 
            this.gvScheduling.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gvScheduling.Appearance.Empty.Options.UseBackColor = true;
            this.gvScheduling.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gvScheduling.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvScheduling.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvScheduling.Appearance.OddRow.Options.UseBackColor = true;
            this.gvScheduling.AppearancePrint.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvScheduling.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.gvScheduling.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colddh,
            this.coljt,
            this.colwdh,
            this.colbh,
            this.coldh,
            this.colkssj,
            this.coljssj,
            this.colllsj});
            this.gvScheduling.GridControl = this.gcScheduling;
            this.gvScheduling.Name = "gvScheduling";
            this.gvScheduling.OptionsBehavior.Editable = false;
            this.gvScheduling.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvScheduling.OptionsBehavior.ReadOnly = true;
            this.gvScheduling.OptionsCustomization.AllowGroup = false;
            this.gvScheduling.OptionsFind.AlwaysVisible = true;
            this.gvScheduling.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gvScheduling.OptionsMenu.EnableColumnMenu = false;
            this.gvScheduling.OptionsView.EnableAppearanceOddRow = true;
            this.gvScheduling.OptionsView.ShowAutoFilterRow = true;
            this.gvScheduling.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvScheduling.OptionsView.ShowGroupPanel = false;
            this.gvScheduling.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colddh, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colddh
            // 
            this.colddh.Caption = "订单号";
            this.colddh.FieldName = "ShiftID";
            this.colddh.Name = "colddh";
            this.colddh.Visible = true;
            this.colddh.VisibleIndex = 0;
            this.colddh.Width = 94;
            // 
            // coljt
            // 
            this.coljt.Caption = "机位号";
            this.coljt.FieldName = "KnitterFriendlyName";
            this.coljt.Name = "coljt";
            this.coljt.Visible = true;
            this.coljt.VisibleIndex = 1;
            this.coljt.Width = 71;
            // 
            // colwdh
            // 
            this.colwdh.Caption = "文档号";
            this.colwdh.FieldName = "PatternName";
            this.colwdh.Name = "colwdh";
            this.colwdh.Visible = true;
            this.colwdh.VisibleIndex = 2;
            this.colwdh.Width = 97;
            // 
            // colbh
            // 
            this.colbh.Caption = "版号";
            this.colbh.FieldName = "DocumentName";
            this.colbh.Name = "colbh";
            this.colbh.Visible = true;
            this.colbh.VisibleIndex = 3;
            this.colbh.Width = 93;
            // 
            // coldh
            // 
            this.coldh.Caption = "代号";
            this.coldh.FieldName = "SizeName";
            this.coldh.Name = "coldh";
            this.coldh.Visible = true;
            this.coldh.VisibleIndex = 4;
            this.coldh.Width = 78;
            // 
            // colkssj
            // 
            this.colkssj.Caption = "开始时间";
            this.colkssj.DisplayFormat.FormatString = "g";
            this.colkssj.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colkssj.FieldName = "StartTime";
            this.colkssj.Name = "colkssj";
            this.colkssj.Visible = true;
            this.colkssj.VisibleIndex = 5;
            this.colkssj.Width = 131;
            // 
            // coljssj
            // 
            this.coljssj.Caption = "结束时间";
            this.coljssj.DisplayFormat.FormatString = "g";
            this.coljssj.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coljssj.FieldName = "FinishTime";
            this.coljssj.Name = "coljssj";
            this.coljssj.Visible = true;
            this.coljssj.VisibleIndex = 6;
            this.coljssj.Width = 123;
            // 
            // colllsj
            // 
            this.colllsj.Caption = "理论时间";
            this.colllsj.FieldName = "FinishTimeExpected";
            this.colllsj.Name = "colllsj";
            this.colllsj.Visible = true;
            this.colllsj.VisibleIndex = 7;
            this.colllsj.Width = 65;
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.bLogSaveAs);
            this.tpLog.Controls.Add(this.rtbLog);
            this.tpLog.Controls.Add(this.ckbInquiryByDate);
            this.tpLog.Controls.Add(this.lbFromDate);
            this.tpLog.Controls.Add(this.dtpFromDate);
            this.tpLog.Controls.Add(this.lbToDate);
            this.tpLog.Controls.Add(this.dtpToDate);
            this.tpLog.Controls.Add(this.bLogInquiry);
            this.tpLog.Location = new System.Drawing.Point(4, 22);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpLog.Size = new System.Drawing.Size(770, 341);
            this.tpLog.TabIndex = 2;
            this.tpLog.Text = "日志";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // bLogSaveAs
            // 
            this.bLogSaveAs.Location = new System.Drawing.Point(677, 5);
            this.bLogSaveAs.Name = "bLogSaveAs";
            this.bLogSaveAs.Size = new System.Drawing.Size(75, 23);
            this.bLogSaveAs.TabIndex = 18;
            this.bLogSaveAs.Text = "日志导出";
            this.bLogSaveAs.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLog.Location = new System.Drawing.Point(0, 39);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(770, 306);
            this.rtbLog.TabIndex = 17;
            this.rtbLog.Text = "";
            // 
            // ckbInquiryByDate
            // 
            this.ckbInquiryByDate.AutoSize = true;
            this.ckbInquiryByDate.Location = new System.Drawing.Point(6, 9);
            this.ckbInquiryByDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.ckbInquiryByDate.Name = "ckbInquiryByDate";
            this.ckbInquiryByDate.Size = new System.Drawing.Size(84, 16);
            this.ckbInquiryByDate.TabIndex = 11;
            this.ckbInquiryByDate.Text = "按时间查询";
            this.ckbInquiryByDate.UseVisualStyleBackColor = true;
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Location = new System.Drawing.Point(96, 10);
            this.lbFromDate.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(17, 12);
            this.lbFromDate.TabIndex = 14;
            this.lbFromDate.Text = "从";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(119, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 21);
            this.dtpFromDate.TabIndex = 12;
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Location = new System.Drawing.Point(325, 10);
            this.lbToDate.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(17, 12);
            this.lbToDate.TabIndex = 15;
            this.lbToDate.Text = "到";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(348, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 21);
            this.dtpToDate.TabIndex = 13;
            // 
            // bLogInquiry
            // 
            this.bLogInquiry.Location = new System.Drawing.Point(579, 5);
            this.bLogInquiry.Name = "bLogInquiry";
            this.bLogInquiry.Size = new System.Drawing.Size(75, 23);
            this.bLogInquiry.TabIndex = 16;
            this.bLogInquiry.Text = "查询";
            this.bLogInquiry.UseVisualStyleBackColor = true;
            this.bLogInquiry.Click += new System.EventHandler(this.bLogInquiry_Click);
            // 
            // UPnP
            // 
            this.UPnP.DeviceAdded += new ManagedUPnP.DeviceAddedEventHandler(this.UPnP_DeviceAdded);
            this.UPnP.DeviceRemoved += new ManagedUPnP.DeviceRemovedEventHandler(this.UPnP_DeviceRemoved);
            // 
            // bgwReloadShift
            // 
            this.bgwReloadShift.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwReloadShift_DoWork);
            this.bgwReloadShift.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwReloadShift_RunWorkerCompleted);
            // 
            // bgwLog4netListener
            // 
            this.bgwLog4netListener.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLog4netListener_DoWork);
            // 
            // frmKnitterManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tlpKnitterManagement);
            this.Controls.Add(this.msMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmKnitterManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "史陶比尔纺织机网络监控软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKnitterManagement_FormClosing);
            this.Load += new System.EventHandler(this.frmKnitterManagement_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tlpKnitterManagement.ResumeLayout(false);
            this.tcKnitterManagement.ResumeLayout(false);
            this.tpDevice.ResumeLayout(false);
            this.tlpDevice.ResumeLayout(false);
            this.pDeviceList.ResumeLayout(false);
            this.pDeviceList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeviceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceList)).EndInit();
            this.tpScheduling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcScheduling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScheduling)).EndInit();
            this.tpLog.ResumeLayout(false);
            this.tpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UPnP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmiLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiControl;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeviceManagement;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreference;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiContactUs;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TableLayoutPanel tlpKnitterManagement;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TabControl tcKnitterManagement;
        private System.Windows.Forms.TabPage tpDevice;
        private System.Windows.Forms.TabPage tpScheduling;
        private System.Windows.Forms.TabPage tpLog;
        private System.Windows.Forms.CheckBox ckbInquiryByDate;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button bLogInquiry;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TableLayoutPanel tlpDevice;
        private System.Windows.Forms.Button bLogSaveAs;
        private ManagedUPnP.Components.UPnPDiscovery UPnP;
        private System.ComponentModel.BackgroundWorker bgwReloadShift;
        private DevExpress.XtraGrid.GridControl gcScheduling;
        private DevExpress.XtraGrid.Views.Grid.GridView gvScheduling;
        private DevExpress.XtraGrid.Columns.GridColumn colddh;
        private DevExpress.XtraGrid.Columns.GridColumn coljt;
        private DevExpress.XtraGrid.Columns.GridColumn colwdh;
        private DevExpress.XtraGrid.Columns.GridColumn colbh;
        private DevExpress.XtraGrid.Columns.GridColumn coldh;
        private DevExpress.XtraGrid.Columns.GridColumn colkssj;
        private DevExpress.XtraGrid.Columns.GridColumn coljssj;
        private DevExpress.XtraGrid.Columns.GridColumn colllsj;
        private System.Windows.Forms.ToolStripMenuItem tmsiRefreshScheduling;
        private System.Windows.Forms.Panel pDeviceList;
        private System.Windows.Forms.FlowLayoutPanel flpDeviceList;
        private System.Windows.Forms.Label lbDeviceList1;
        private DevExpress.XtraGrid.GridControl gcDeviceList;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDeviceList;
        private DevExpress.XtraGrid.Columns.GridColumn dgvtbcDeviceListFriendlyName;
        private DevExpress.XtraGrid.Columns.GridColumn dgvtbcDeviceListSerialNumber;
        private DevExpress.XtraGrid.Columns.GridColumn dgvtbcDeviceListIPAddress;
        private DevExpress.XtraGrid.Columns.GridColumn dgvtbcDeviceListMACAddress;
        private DevExpress.XtraGrid.Columns.GridColumn dgvtbcDeviceListDeviceState;
        private System.ComponentModel.BackgroundWorker bgwLog4netListener;
        private System.Windows.Forms.ToolStripMenuItem tmsiRescan;

    }
}