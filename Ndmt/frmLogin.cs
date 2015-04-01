using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ndmt
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private const string BLANK_STRING = @"";
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bClear_Click(object sender, EventArgs e)
        {
            this.tbAccount.Text = BLANK_STRING;
            this.tbPassword.Text = BLANK_STRING;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bLogin_Click(object sender, EventArgs e)
        {
            /*
             * 自定义，不可复制Textbox
             * public const int WM_PASTE = 0x0302;//粘貼消息 
             * protected override void WndProc(ref Message m) 
             * {
             *      if(m.Msg != WM_PASTE)base.WndProc (ref m);
             * }
             */
            
            // 验证身份
            bool success = true;
            if (success)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名密码错误", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
