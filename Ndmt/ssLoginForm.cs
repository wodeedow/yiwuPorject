using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Ndmt
{
    public partial class ssLoginForm : SplashScreen
    {
        public ssLoginForm()
        {
            InitializeComponent();
        }

        #region Overrides

        /// <summary>
        /// 供外部调用，以便执行不同功能
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="arg"></param>
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);//调用父类的带参数的构造函数
            // 获得指令对象
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            switch (command)
            {
                // 设置进度条显示
                case SplashScreenCommand.SetProgressBarControl:
                    // 需要先将原窗口中的原marqueeProgressBarControl控件换成ProgressBarControl控件
                    // this.pbcStatus.Position = Int32.Parse(arg);
                    break;
                // 设置进度文本显示
                case SplashScreenCommand.SetLabelControl:
                    this.lcStatus.Text = arg.ToString();
                    break;
                // 其他指令预留
                case SplashScreenCommand.OtherCommand:
                    break;
                default:
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 定义指令集，供外部调用，以便执行不同功能
        /// </summary>
        public enum SplashScreenCommand
        {
            // 设置进度条显示
            SetProgressBarControl,
            // 设置进度文本显示
            SetLabelControl,
            // 其他指令预留
            OtherCommand
        }
    }
}