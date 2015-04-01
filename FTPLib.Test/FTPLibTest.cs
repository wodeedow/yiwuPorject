using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FTPLib;
using Starksoft.Net.Ftp;

namespace FTPLib.Test
{
    public partial class frmFTP : Form
    {
        public frmFTP()
        {
            InitializeComponent();
        }

        private void btBrowser_Click(object sender, EventArgs e)
        {
            this.openFileDialog.RestoreDirectory = true;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbFilename.Text = this.openFileDialog.FileName;
            }
            else
            {
                this.tbFilename.Text = @"";
            }

        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            string addr = this.tbAddr.Text;
            string username = this.tbUserName.Text;
            string password = this.tbPassword.Text;
            try
            {
                // create a new ftpclient object with the host and port number to use
                FtpClient ftp = new FtpClient(addr, 21);

                // registered an event hook for the transfer complete event so we get an update when the transfer is over
                ftp.TransferComplete += new EventHandler<TransferCompleteEventArgs>(ftp_TransferComplete);

                // open a connection to the ftp server with a username and password
                ftp.Open(username, password);

                // put a local file and store it remotely as the supplied file location and name 
                ftp.PutFile(this.tbFilename.Text, this.openFileDialog.SafeFileName, FileAction.Create);
                 
                // close the ftp connection
                ftp.Close();
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ftp_TransferComplete(object sender, TransferCompleteEventArgs e)
        {
            MessageBox.Show(e.BytesTransferred.ToString() + " bytes transferred in " + e.ElapsedTime.Seconds.ToString() + " seconds");
        }
    }
}
