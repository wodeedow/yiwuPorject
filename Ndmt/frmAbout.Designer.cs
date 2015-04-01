namespace Ndmt
{
    partial class frmAbout
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
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbLicense = new System.Windows.Forms.Label();
            this.rtbLicenseInfo = new System.Windows.Forms.RichTextBox();
            this.lbModuleInfo = new System.Windows.Forms.Label();
            this.rtbModuleInfo = new System.Windows.Forms.RichTextBox();
            this.lbHardwareID = new System.Windows.Forms.Label();
            this.tbHardwareID = new System.Windows.Forms.TextBox();
            this.lbLicenseStatus = new System.Windows.Forms.Label();
            this.tbLicenseStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProductName.Location = new System.Drawing.Point(12, 47);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(208, 12);
            this.lbProductName.TabIndex = 0;
            this.lbProductName.Text = "JC5 Network Driver Management";
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Location = new System.Drawing.Point(12, 61);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(275, 12);
            this.lbCopyright.TabIndex = 1;
            this.lbCopyright.Text = "Copyright (c) 2011-2014. All rights reserved.";
            // 
            // lbLicense
            // 
            this.lbLicense.AutoSize = true;
            this.lbLicense.Location = new System.Drawing.Point(12, 141);
            this.lbLicense.Name = "lbLicense";
            this.lbLicense.Size = new System.Drawing.Size(113, 12);
            this.lbLicense.TabIndex = 2;
            this.lbLicense.Text = "本产品使用权属于：";
            // 
            // rtbLicenseInfo
            // 
            this.rtbLicenseInfo.Location = new System.Drawing.Point(14, 157);
            this.rtbLicenseInfo.Name = "rtbLicenseInfo";
            this.rtbLicenseInfo.ReadOnly = true;
            this.rtbLicenseInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbLicenseInfo.Size = new System.Drawing.Size(363, 80);
            this.rtbLicenseInfo.TabIndex = 3;
            this.rtbLicenseInfo.Text = "";
            // 
            // lbModuleInfo
            // 
            this.lbModuleInfo.AutoSize = true;
            this.lbModuleInfo.Location = new System.Drawing.Point(12, 255);
            this.lbModuleInfo.Name = "lbModuleInfo";
            this.lbModuleInfo.Size = new System.Drawing.Size(65, 12);
            this.lbModuleInfo.TabIndex = 4;
            this.lbModuleInfo.Text = "模块信息：";
            // 
            // rtbModuleInfo
            // 
            this.rtbModuleInfo.Location = new System.Drawing.Point(14, 271);
            this.rtbModuleInfo.Name = "rtbModuleInfo";
            this.rtbModuleInfo.ReadOnly = true;
            this.rtbModuleInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbModuleInfo.Size = new System.Drawing.Size(363, 79);
            this.rtbModuleInfo.TabIndex = 5;
            this.rtbModuleInfo.Text = "";
            // 
            // lbHardwareID
            // 
            this.lbHardwareID.AutoSize = true;
            this.lbHardwareID.Location = new System.Drawing.Point(12, 84);
            this.lbHardwareID.Name = "lbHardwareID";
            this.lbHardwareID.Size = new System.Drawing.Size(53, 12);
            this.lbHardwareID.TabIndex = 6;
            this.lbHardwareID.Text = "本机ID：";
            // 
            // tbHardwareID
            // 
            this.tbHardwareID.Location = new System.Drawing.Point(100, 81);
            this.tbHardwareID.Name = "tbHardwareID";
            this.tbHardwareID.ReadOnly = true;
            this.tbHardwareID.Size = new System.Drawing.Size(277, 21);
            this.tbHardwareID.TabIndex = 7;
            this.tbHardwareID.Text = "####-####-####-####-####";
            this.tbHardwareID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbLicenseStatus
            // 
            this.lbLicenseStatus.AutoSize = true;
            this.lbLicenseStatus.Location = new System.Drawing.Point(13, 111);
            this.lbLicenseStatus.Name = "lbLicenseStatus";
            this.lbLicenseStatus.Size = new System.Drawing.Size(65, 12);
            this.lbLicenseStatus.TabIndex = 8;
            this.lbLicenseStatus.Text = "注册状态：";
            // 
            // tbLicenseStatus
            // 
            this.tbLicenseStatus.Location = new System.Drawing.Point(100, 109);
            this.tbLicenseStatus.Name = "tbLicenseStatus";
            this.tbLicenseStatus.ReadOnly = true;
            this.tbLicenseStatus.Size = new System.Drawing.Size(277, 21);
            this.tbLicenseStatus.TabIndex = 9;
            this.tbLicenseStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 392);
            this.Controls.Add(this.tbLicenseStatus);
            this.Controls.Add(this.lbLicenseStatus);
            this.Controls.Add(this.tbHardwareID);
            this.Controls.Add(this.lbHardwareID);
            this.Controls.Add(this.rtbModuleInfo);
            this.Controls.Add(this.lbModuleInfo);
            this.Controls.Add(this.rtbLicenseInfo);
            this.Controls.Add(this.lbLicense);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.lbProductName);
            this.Name = "About";
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbLicense;
        private System.Windows.Forms.RichTextBox rtbLicenseInfo;
        private System.Windows.Forms.Label lbModuleInfo;
        private System.Windows.Forms.RichTextBox rtbModuleInfo;
        private System.Windows.Forms.Label lbHardwareID;
        private System.Windows.Forms.TextBox tbHardwareID;
        private System.Windows.Forms.Label lbLicenseStatus;
        private System.Windows.Forms.TextBox tbLicenseStatus;
    }
}