using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.About;

using Ndmt.Utils;

namespace Ndmt
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            BindDataSource();
        }

        private void BindDataSource()
        {
            GetLicenseInfo();
            GetModuleInfo();
        }

        /// <summary>
        /// 证书状态
        /// </summary>
        private void GetLicenseInfo()
        {
            this.tbHardwareID.DataBindings.Add(new Binding("Text", License.Status.HardwareID, ""));
            this.tbLicenseStatus.DataBindings.Add(new Binding("Text", License.Status.Licensed, ""));
            this.rtbLicenseInfo.Text += LicenseMonitor.CurrentLicense[LicenseMonitor.Properties.Company] + "\n";
            this.rtbLicenseInfo.Text += LicenseMonitor.CurrentLicense[LicenseMonitor.Properties.SNPrefix] + "\n";
            this.rtbLicenseInfo.Text += License.Status.License_HardwareID + "\n";
        }


        /// <summary>
        /// 程序模块
        /// </summary>
        private void GetModuleInfo()
        {
            DirectoryInfo currentFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
            List<string> files = new List<string>();
            foreach (FileInfo file in currentFolder.GetFiles())
            {
                string fileName = file.Name;
                string suffix = fileName.Substring(fileName.LastIndexOf(".") + 1);
                if (".dll|.exe".IndexOf(fileName.Substring(fileName.LastIndexOf(".") + 1)) > -1)
                    files.Add(fileName);
            }
            this.rtbModuleInfo.Text = String.Join(",\n", files);
        }
    }
}
