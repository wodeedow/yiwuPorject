namespace Ndmt
{
    partial class frmDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevice));
            this.tcDeviceManagement = new System.Windows.Forms.TabControl();
            this.tpDeviceCommand = new System.Windows.Forms.TabPage();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.bReset = new System.Windows.Forms.Button();
            this.bRecovery = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.tlpAdmin = new System.Windows.Forms.TableLayoutPanel();
            this.bUpgrade = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.rtbVersion = new System.Windows.Forms.RichTextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.tbBrowse = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.tcDeviceManagement.SuspendLayout();
            this.tpDeviceCommand.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.tlpAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDeviceManagement
            // 
            this.tcDeviceManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDeviceManagement.Controls.Add(this.tpDeviceCommand);
            this.tcDeviceManagement.Location = new System.Drawing.Point(0, -1);
            this.tcDeviceManagement.Name = "tcDeviceManagement";
            this.tcDeviceManagement.SelectedIndex = 0;
            this.tcDeviceManagement.Size = new System.Drawing.Size(464, 464);
            this.tcDeviceManagement.TabIndex = 0;
            // 
            // tpDeviceCommand
            // 
            this.tpDeviceCommand.Controls.Add(this.gbUser);
            this.tpDeviceCommand.Controls.Add(this.gbAdmin);
            this.tpDeviceCommand.Location = new System.Drawing.Point(4, 22);
            this.tpDeviceCommand.Name = "tpDeviceCommand";
            this.tpDeviceCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeviceCommand.Size = new System.Drawing.Size(456, 438);
            this.tpDeviceCommand.TabIndex = 1;
            this.tpDeviceCommand.Text = "设备操作";
            this.tpDeviceCommand.UseVisualStyleBackColor = true;
            // 
            // gbUser
            // 
            this.gbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUser.AutoSize = true;
            this.gbUser.Controls.Add(this.bReset);
            this.gbUser.Controls.Add(this.bRecovery);
            this.gbUser.Location = new System.Drawing.Point(-4, 0);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(460, 68);
            this.gbUser.TabIndex = 2;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "普通用户权限";
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(70, 24);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(90, 24);
            this.bReset.TabIndex = 3;
            this.bReset.Text = "设备重启";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bRecovery
            // 
            this.bRecovery.Location = new System.Drawing.Point(300, 24);
            this.bRecovery.Name = "bRecovery";
            this.bRecovery.Size = new System.Drawing.Size(90, 24);
            this.bRecovery.TabIndex = 4;
            this.bRecovery.Text = "恢复出厂设置";
            this.bRecovery.UseVisualStyleBackColor = true;
            this.bRecovery.Click += new System.EventHandler(this.bRecovery_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAdmin.Controls.Add(this.tlpAdmin);
            this.gbAdmin.Location = new System.Drawing.Point(-4, 69);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(460, 373);
            this.gbAdmin.TabIndex = 1;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "管理员权限";
            // 
            // tlpAdmin
            // 
            this.tlpAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAdmin.ColumnCount = 3;
            this.tlpAdmin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAdmin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAdmin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAdmin.Controls.Add(this.bUpgrade, 2, 6);
            this.tlpAdmin.Controls.Add(this.tbPassword, 1, 6);
            this.tlpAdmin.Controls.Add(this.tbAccount, 1, 5);
            this.tlpAdmin.Controls.Add(this.rtbVersion, 0, 1);
            this.tlpAdmin.Controls.Add(this.lbPassword, 0, 6);
            this.tlpAdmin.Controls.Add(this.lbVersion, 1, 0);
            this.tlpAdmin.Controls.Add(this.tbBrowse, 0, 2);
            this.tlpAdmin.Controls.Add(this.bBrowse, 2, 2);
            this.tlpAdmin.Controls.Add(this.rtbInfo, 0, 4);
            this.tlpAdmin.Controls.Add(this.lbInfo, 1, 3);
            this.tlpAdmin.Controls.Add(this.lbAccount, 0, 5);
            this.tlpAdmin.Location = new System.Drawing.Point(4, 17);
            this.tlpAdmin.Name = "tlpAdmin";
            this.tlpAdmin.RowCount = 7;
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpAdmin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpAdmin.Size = new System.Drawing.Size(453, 352);
            this.tlpAdmin.TabIndex = 12;
            // 
            // bUpgrade
            // 
            this.bUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpgrade.Location = new System.Drawing.Point(375, 326);
            this.bUpgrade.Name = "bUpgrade";
            this.bUpgrade.Size = new System.Drawing.Size(75, 23);
            this.bUpgrade.TabIndex = 7;
            this.bUpgrade.Text = "升级";
            this.bUpgrade.UseVisualStyleBackColor = true;
            this.bUpgrade.Click += new System.EventHandler(this.bUpgrade_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(116, 328);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(220, 21);
            this.tbPassword.TabIndex = 8;
            // 
            // tbAccount
            // 
            this.tbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccount.Location = new System.Drawing.Point(116, 296);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(220, 21);
            this.tbAccount.TabIndex = 11;
            // 
            // rtbVersion
            // 
            this.rtbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAdmin.SetColumnSpan(this.rtbVersion, 3);
            this.rtbVersion.Location = new System.Drawing.Point(3, 35);
            this.rtbVersion.Name = "rtbVersion";
            this.rtbVersion.Size = new System.Drawing.Size(447, 90);
            this.rtbVersion.TabIndex = 6;
            this.rtbVersion.Text = "";
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(45, 332);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(65, 12);
            this.lbPassword.TabIndex = 10;
            this.lbPassword.Text = "管理员密码";
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(116, 20);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(220, 12);
            this.lbVersion.TabIndex = 5;
            this.lbVersion.Text = "当前版本信息";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBrowse
            // 
            this.tbBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAdmin.SetColumnSpan(this.tbBrowse, 2);
            this.tbBrowse.Location = new System.Drawing.Point(3, 131);
            this.tbBrowse.Name = "tbBrowse";
            this.tbBrowse.Size = new System.Drawing.Size(333, 21);
            this.tbBrowse.TabIndex = 0;
            // 
            // bBrowse
            // 
            this.bBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowse.Location = new System.Drawing.Point(375, 131);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 23);
            this.bBrowse.TabIndex = 1;
            this.bBrowse.Text = "选择文件";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAdmin.SetColumnSpan(this.rtbInfo, 3);
            this.rtbInfo.Location = new System.Drawing.Point(3, 195);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(447, 90);
            this.rtbInfo.TabIndex = 3;
            this.rtbInfo.Text = "";
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(116, 180);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(220, 12);
            this.lbInfo.TabIndex = 4;
            this.lbInfo.Text = "文件信息";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAccount
            // 
            this.lbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccount.AutoSize = true;
            this.lbAccount.Location = new System.Drawing.Point(45, 300);
            this.lbAccount.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(65, 12);
            this.lbAccount.TabIndex = 9;
            this.lbAccount.Text = "管理员账号";
            // 
            // frmDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(464, 462);
            this.Controls.Add(this.tcDeviceManagement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 500);
            this.Name = "frmDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备管理";
            this.Load += new System.EventHandler(this.frmDevice_Load);
            this.tcDeviceManagement.ResumeLayout(false);
            this.tpDeviceCommand.ResumeLayout(false);
            this.tpDeviceCommand.PerformLayout();
            this.gbUser.ResumeLayout(false);
            this.gbAdmin.ResumeLayout(false);
            this.tlpAdmin.ResumeLayout(false);
            this.tlpAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDeviceManagement;
        private System.Windows.Forms.TabPage tpDeviceCommand;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button bRecovery;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button bUpgrade;
        private System.Windows.Forms.RichTextBox rtbVersion;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.TextBox tbBrowse;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.TableLayoutPanel tlpAdmin;
    }
}