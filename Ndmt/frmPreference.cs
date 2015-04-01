using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

using Ndmt.Model;
using System.Threading;
using System.Configuration;

namespace Ndmt
{
    public partial class frmPreference : Form
    {
        public frmPreference()
        {
            InitializeComponent();
        }

        private void frmPreference_Load(object sender, EventArgs e)
        {
            // 
            this.tbSerialNum.ReadOnly = true;
            // 避免数据绑定后自动生成DataGridView列
            this.dgvDeviceListManagement.AutoGenerateColumns = false;
            // 数据绑定完成事件处理注册
            this.dgvDeviceListManagement.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvDeviceListManagement_DataBindingComplete);
            // 数据源绑定
            BindingSource deviceList = new BindingSource();
            deviceList.DataSource = KnitterEntity.HistoryKnitter;
            this.dgvDeviceListManagement.DataSource = deviceList;
            // 默认工作目录
            this.tbPath.Text = global::Ndmt.Properties.Settings.Default.DefaultWorkingDirectory;
        }

        #region "Private NicEntity Object"
        private class NicEntity
        {
            private String key;
            private Object value;

            public NicEntity() { }
            public NicEntity(String m_key, Object m_value)
            {
                this.key = m_key;
                this.value = m_value;
            }

            public String Key
            {
                get { return this.key; }
                set { this.key = value; }
            }

            public Object Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPreference_Shown(object sender, EventArgs e)
        {
            reloadNicList();
        }

        /// <summary>
        /// 刷新按钮按键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRefresh_Click(object sender, EventArgs e)
        {
            reloadNicList();
        }


        //http://msdn.microsoft.com/en-us/library/system.net.networkinformation.networkinterface.aspx
        /// <summary>
        /// 重新装载网卡列表
        /// </summary>
        private void reloadNicList()
        {
            // 重新获取网卡列表
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            if (interfaces.Length > 0)
            {
                int index = 0;
                string selectedInterface = global::Ndmt.Properties.Settings.Default.NetworkInterface; 
                // 填充界面数据
                IList<NicEntity> nicList = new List<NicEntity>();
                foreach (NetworkInterface nic in interfaces)
                {
                    if (nic.Description == selectedInterface)
                        index = nicList.Count;
                    nicList.Add(new NicEntity(nic.Description, nic));
                }
                this.cbNIC.DataSource = nicList;
                this.cbNIC.DisplayMember = "Key";
                this.cbNIC.ValueMember = "Value";

                this.cbNIC.SelectedIndex = index;
            }
        }

        /// <summary>
        /// 选择默认网卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbNIC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            global::Ndmt.Properties.Settings.Default.NetworkInterface = this.cbNIC.Text;
            global::Ndmt.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 浏览按键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdlg = new FolderBrowserDialog();
            if (fbdlg.ShowDialog() == DialogResult.OK) 
            {
                this.tbPath.Text = fbdlg.SelectedPath;
                // 写入用户配置文件
                global::Ndmt.Properties.Settings.Default.DefaultWorkingDirectory = fbdlg.SelectedPath;
                global::Ndmt.Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// DataGridView缺乏选择行变化事件，暂替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDeviceListManagement_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = this.dgvDeviceListManagement.CurrentRow;
            if (currentRow != mLastSelectedRow)
            {
                mLastSelectedRow = currentRow;
                if (currentRow != null)
                {
                    this.tbFriendlyName.Text = currentRow.Cells["dgvtbcDeviceListManagementFriendlyName"].Value.ToString();
                    this.tbSerialNum.Text = currentRow.Cells["dgvtbcDeviceListManagementSerialNum"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// 数据绑定完成事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDeviceListManagement_DataBindingComplete(object sender, EventArgs e)
        {
            // 绑定后才进行选择变化事件监听
            this.dgvDeviceListManagement.SelectionChanged += new System.EventHandler(this.dgvDeviceListManagement_SelectionChanged);
        }

        /// <summary>
        /// 设置FriendlyName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDeviceSet_Click(object sender, EventArgs e)
        {
            // 提示信息
            string newFriendlyName = this.tbFriendlyName.Text;
            int index = (this.dgvDeviceListManagement.DataSource as BindingSource).Find(KnitterEntity.SearchByFriendlyNameProperty, newFriendlyName);
            if (index == -1)
            {
                // 获得当前行绑定的数据源
                DataGridViewRow currentRow = this.dgvDeviceListManagement.CurrentRow;
                KnitterEntity ke = currentRow.DataBoundItem as KnitterEntity;
                if (ke.IsOnline && ke.CurrentState == ke.IdleState)
                {
                    if (ke.FriendlyName != newFriendlyName) // 发生变化
                    {
                        // 发送Action: 设置FriendlyName
                        ke.SetFriendlyName(newFriendlyName);
                    }
                }
                else
                {
                    MessageBox.Show("请确保设备已经接入局域网且处于空闲状态");
                }
            }
            else
            {
                MessageBox.Show(String.Format("已存在机台#{0}", newFriendlyName));
            }
        }

        /// <summary>
        /// 移除无用设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDeviceDelete_Click(object sender, EventArgs e)
        {
            // 提示信息

            // 获得当前行绑定的数据源
            DataGridViewRow currentRow = this.dgvDeviceListManagement.CurrentRow;
            KnitterEntity ke = currentRow.DataBoundItem as KnitterEntity;
            // 判断是否可以删除
            if (!ke.IsOnline)
            {
                // 查询数据源对象所在位置
                // int index = (this.Owner as frmKnitterManagement).DeviceBindingSource.Find(KnitterEntity.SearchBySerialNumProperty, ke.SerialNumber);
                int index = currentRow.Index;
                // 数据集中删除记录
                KnitterEntity.HistoryKnitter.RemoveAt(index);
                // 数据集持久化
                KnitterEntity.PersistToHistoryFile();
            }
            else
            {
                MessageBox.Show("请先关闭JC5 Network Driver");
            }
        }

        /// <summary>
        /// FriendlyName输入框验证事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFriendlyName_Validating(object sender, CancelEventArgs e)
        {
            if (!KnitterEntity.ValidFriendlyName(this.tbFriendlyName.Text))
            {
                // FriendlyName不正确，使设置按键失效
                this.bDeviceSet.Enabled = false;
                // 错误提示
                MessageBox.Show(KnitterEntity.FRIENDLY_NAME_INVALID_PROMPT);
                // 取消Validating事件
                e.Cancel = true;
            }
        }

        /// <summary>
        /// FriendlyName输入框验证成功事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFriendlyName_Validated(object sender, EventArgs e)
        {
            this.bDeviceSet.Enabled = true;
        }

        #region Private Members

        private DataGridViewRow mLastSelectedRow;

        #endregion

    }
}
