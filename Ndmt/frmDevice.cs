using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ndmt.Model;

namespace Ndmt
{
    public partial class frmDevice: Form
    {
        private KnitterEntity mKnitterDevice;

        public frmDevice()
        {
            InitializeComponent();
        }

        public frmDevice(KnitterEntity ke) : this()
        {
            this.mKnitterDevice = ke;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDevice_Load(object sender, EventArgs e)
        {
            this.bReset.DataBindings.Add(new Binding("Enabled", this.mKnitterDevice, "CanReboot"));
            this.bRecovery.Enabled = false;
            this.bUpgrade.Enabled = false;
            this.bBrowse.Enabled = false;
        }

        #region 设备操作
        /// <summary>
        /// 重新启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bReset_Click(object sender, EventArgs e)
        {
            if (this.mKnitterDevice.IsOnline)
            {
                if (MessageBox.Show("重启需要一段时间，是否重启？", "确认重启",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // UPnP调用Action
                    this.mKnitterDevice.Restart();
                }
            }
        }

        /// <summary>
        /// 恢复出厂设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRecovery_Click(object sender, EventArgs e)
        {
            if (this.mKnitterDevice.IsOnline)
            {
                if (MessageBox.Show("确认恢复出厂设置？",
                    "确认恢复出厂设置",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // UPnP调用Action
                    this.mKnitterDevice.Reset();
                }
            }
        }

        /// <summary>
        /// 升级固件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bUpgrade_Click(object sender, EventArgs e)
        {
            /*
            if (MessageBox.Show("确认升级固件？",
                "确认升级固件",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // UPnP调用Action
            }
            */
            MessageBox.Show("该功能暂未开放");
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBrowse_Click(object sender, EventArgs e)
        {

        }




    }
}
