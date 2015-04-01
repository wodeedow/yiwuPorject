namespace Ndmt
{
    partial class frmPreference
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreference));
            this.tcPreference = new System.Windows.Forms.TabControl();
            this.tpSystemSettings = new System.Windows.Forms.TabPage();
            this.tlpSystemSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.lbNIC = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.cbNIC = new System.Windows.Forms.ComboBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.tpDeviceListManagement = new System.Windows.Forms.TabPage();
            this.tlpDeviceListManagement = new System.Windows.Forms.TableLayoutPanel();
            this.bDeviceSet = new System.Windows.Forms.Button();
            this.bDeviceDelete = new System.Windows.Forms.Button();
            this.dgvDeviceListManagement = new System.Windows.Forms.DataGridView();
            this.dgvtbcDeviceListManagementFriendlyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcDeviceListManagementSerialNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbFriendlyName = new System.Windows.Forms.Label();
            this.lbSerialNum = new System.Windows.Forms.Label();
            this.tbFriendlyName = new System.Windows.Forms.TextBox();
            this.tbSerialNum = new System.Windows.Forms.TextBox();
            this.tcPreference.SuspendLayout();
            this.tpSystemSettings.SuspendLayout();
            this.tlpSystemSettings.SuspendLayout();
            this.tpDeviceListManagement.SuspendLayout();
            this.tlpDeviceListManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceListManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPreference
            // 
            this.tcPreference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPreference.Controls.Add(this.tpSystemSettings);
            this.tcPreference.Controls.Add(this.tpDeviceListManagement);
            this.tcPreference.Location = new System.Drawing.Point(0, 0);
            this.tcPreference.Name = "tcPreference";
            this.tcPreference.SelectedIndex = 0;
            this.tcPreference.ShowToolTips = true;
            this.tcPreference.Size = new System.Drawing.Size(486, 464);
            this.tcPreference.TabIndex = 6;
            // 
            // tpSystemSettings
            // 
            this.tpSystemSettings.Controls.Add(this.tlpSystemSettings);
            this.tpSystemSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSystemSettings.Name = "tpSystemSettings";
            this.tpSystemSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSystemSettings.Size = new System.Drawing.Size(478, 438);
            this.tpSystemSettings.TabIndex = 0;
            this.tpSystemSettings.Text = "系统设置";
            this.tpSystemSettings.UseVisualStyleBackColor = true;
            // 
            // tlpSystemSettings
            // 
            this.tlpSystemSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSystemSettings.ColumnCount = 2;
            this.tlpSystemSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSystemSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSystemSettings.Controls.Add(this.tbPath, 0, 3);
            this.tlpSystemSettings.Controls.Add(this.bBrowse, 1, 2);
            this.tlpSystemSettings.Controls.Add(this.lbNIC, 0, 0);
            this.tlpSystemSettings.Controls.Add(this.bRefresh, 1, 0);
            this.tlpSystemSettings.Controls.Add(this.cbNIC, 0, 1);
            this.tlpSystemSettings.Controls.Add(this.lbPath, 0, 2);
            this.tlpSystemSettings.Location = new System.Drawing.Point(0, 0);
            this.tlpSystemSettings.Name = "tlpSystemSettings";
            this.tlpSystemSettings.RowCount = 4;
            this.tlpSystemSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSystemSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSystemSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSystemSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSystemSettings.Size = new System.Drawing.Size(478, 438);
            this.tlpSystemSettings.TabIndex = 6;
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSystemSettings.SetColumnSpan(this.tbPath, 2);
            this.tbPath.Location = new System.Drawing.Point(3, 372);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(472, 21);
            this.tbPath.TabIndex = 3;
            // 
            // bBrowse
            // 
            this.bBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bBrowse.Location = new System.Drawing.Point(400, 261);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 23);
            this.bBrowse.TabIndex = 5;
            this.bBrowse.Text = "浏览...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // lbNIC
            // 
            this.lbNIC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNIC.AutoSize = true;
            this.lbNIC.Location = new System.Drawing.Point(3, 48);
            this.lbNIC.Name = "lbNIC";
            this.lbNIC.Size = new System.Drawing.Size(53, 12);
            this.lbNIC.TabIndex = 0;
            this.lbNIC.Text = "网卡设置";
            // 
            // bRefresh
            // 
            this.bRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bRefresh.Location = new System.Drawing.Point(400, 43);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 4;
            this.bRefresh.Text = "刷新";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // cbNIC
            // 
            this.cbNIC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSystemSettings.SetColumnSpan(this.cbNIC, 2);
            this.cbNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNIC.FormattingEnabled = true;
            this.cbNIC.Location = new System.Drawing.Point(3, 153);
            this.cbNIC.Name = "cbNIC";
            this.cbNIC.Size = new System.Drawing.Size(472, 20);
            this.cbNIC.TabIndex = 1;
            this.cbNIC.SelectionChangeCommitted += new System.EventHandler(this.cbNIC_SelectionChangeCommitted);
            // 
            // lbPath
            // 
            this.lbPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(3, 266);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(101, 12);
            this.lbPath.TabIndex = 2;
            this.lbPath.Text = "默认工作路径设置";
            // 
            // tpDeviceListManagement
            // 
            this.tpDeviceListManagement.Controls.Add(this.tlpDeviceListManagement);
            this.tpDeviceListManagement.Location = new System.Drawing.Point(4, 22);
            this.tpDeviceListManagement.Name = "tpDeviceListManagement";
            this.tpDeviceListManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeviceListManagement.Size = new System.Drawing.Size(478, 438);
            this.tpDeviceListManagement.TabIndex = 1;
            this.tpDeviceListManagement.Text = "设备列表";
            this.tpDeviceListManagement.UseVisualStyleBackColor = true;
            // 
            // tlpDeviceListManagement
            // 
            this.tlpDeviceListManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDeviceListManagement.ColumnCount = 4;
            this.tlpDeviceListManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tlpDeviceListManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tlpDeviceListManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpDeviceListManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpDeviceListManagement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDeviceListManagement.Controls.Add(this.bDeviceSet, 2, 1);
            this.tlpDeviceListManagement.Controls.Add(this.bDeviceDelete, 3, 1);
            this.tlpDeviceListManagement.Controls.Add(this.dgvDeviceListManagement, 0, 2);
            this.tlpDeviceListManagement.Controls.Add(this.lbFriendlyName, 0, 0);
            this.tlpDeviceListManagement.Controls.Add(this.lbSerialNum, 1, 0);
            this.tlpDeviceListManagement.Controls.Add(this.tbFriendlyName, 0, 1);
            this.tlpDeviceListManagement.Controls.Add(this.tbSerialNum, 1, 1);
            this.tlpDeviceListManagement.Location = new System.Drawing.Point(0, 0);
            this.tlpDeviceListManagement.Name = "tlpDeviceListManagement";
            this.tlpDeviceListManagement.RowCount = 3;
            this.tlpDeviceListManagement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDeviceListManagement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDeviceListManagement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDeviceListManagement.Size = new System.Drawing.Size(475, 438);
            this.tlpDeviceListManagement.TabIndex = 0;
            // 
            // bDeviceSet
            // 
            this.bDeviceSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeviceSet.Location = new System.Drawing.Point(371, 18);
            this.bDeviceSet.Name = "bDeviceSet";
            this.bDeviceSet.Size = new System.Drawing.Size(46, 19);
            this.bDeviceSet.TabIndex = 5;
            this.bDeviceSet.Text = "设置";
            this.bDeviceSet.UseVisualStyleBackColor = true;
            this.bDeviceSet.Click += new System.EventHandler(this.bDeviceSet_Click);
            // 
            // bDeviceDelete
            // 
            this.bDeviceDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeviceDelete.CausesValidation = false;
            this.bDeviceDelete.Location = new System.Drawing.Point(423, 18);
            this.bDeviceDelete.Name = "bDeviceDelete";
            this.bDeviceDelete.Size = new System.Drawing.Size(49, 19);
            this.bDeviceDelete.TabIndex = 6;
            this.bDeviceDelete.Text = "移除";
            this.bDeviceDelete.UseVisualStyleBackColor = true;
            this.bDeviceDelete.Click += new System.EventHandler(this.bDeviceDelete_Click);
            // 
            // dgvDeviceListManagement
            // 
            this.dgvDeviceListManagement.AllowUserToAddRows = false;
            this.dgvDeviceListManagement.AllowUserToDeleteRows = false;
            this.dgvDeviceListManagement.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeviceListManagement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeviceListManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeviceListManagement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeviceListManagement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDeviceListManagement.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeviceListManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDeviceListManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceListManagement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcDeviceListManagementFriendlyName,
            this.dgvtbcDeviceListManagementSerialNum});
            this.tlpDeviceListManagement.SetColumnSpan(this.dgvDeviceListManagement, 4);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeviceListManagement.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeviceListManagement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDeviceListManagement.Location = new System.Drawing.Point(3, 43);
            this.dgvDeviceListManagement.MultiSelect = false;
            this.dgvDeviceListManagement.Name = "dgvDeviceListManagement";
            this.dgvDeviceListManagement.RowHeadersWidth = 32;
            this.dgvDeviceListManagement.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDeviceListManagement.RowTemplate.Height = 23;
            this.dgvDeviceListManagement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceListManagement.Size = new System.Drawing.Size(469, 392);
            this.dgvDeviceListManagement.TabIndex = 7;
            // 
            // dgvtbcDeviceListManagementFriendlyName
            // 
            this.dgvtbcDeviceListManagementFriendlyName.DataPropertyName = "FriendlyName";
            this.dgvtbcDeviceListManagementFriendlyName.HeaderText = "机位号";
            this.dgvtbcDeviceListManagementFriendlyName.Name = "dgvtbcDeviceListManagementFriendlyName";
            this.dgvtbcDeviceListManagementFriendlyName.ReadOnly = true;
            // 
            // dgvtbcDeviceListManagementSerialNum
            // 
            this.dgvtbcDeviceListManagementSerialNum.DataPropertyName = "SerialNumber";
            this.dgvtbcDeviceListManagementSerialNum.HeaderText = "序列号";
            this.dgvtbcDeviceListManagementSerialNum.Name = "dgvtbcDeviceListManagementSerialNum";
            this.dgvtbcDeviceListManagementSerialNum.ReadOnly = true;
            // 
            // lbFriendlyName
            // 
            this.lbFriendlyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFriendlyName.AutoSize = true;
            this.lbFriendlyName.Location = new System.Drawing.Point(3, 0);
            this.lbFriendlyName.Name = "lbFriendlyName";
            this.lbFriendlyName.Size = new System.Drawing.Size(178, 15);
            this.lbFriendlyName.TabIndex = 1;
            this.lbFriendlyName.Text = "机位号";
            this.lbFriendlyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSerialNum
            // 
            this.lbSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSerialNum.AutoSize = true;
            this.lbSerialNum.Location = new System.Drawing.Point(187, 0);
            this.lbSerialNum.Name = "lbSerialNum";
            this.lbSerialNum.Size = new System.Drawing.Size(178, 15);
            this.lbSerialNum.TabIndex = 0;
            this.lbSerialNum.Text = "序列号";
            this.lbSerialNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFriendlyName
            // 
            this.tbFriendlyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFriendlyName.Location = new System.Drawing.Point(3, 18);
            this.tbFriendlyName.Name = "tbFriendlyName";
            this.tbFriendlyName.Size = new System.Drawing.Size(178, 21);
            this.tbFriendlyName.TabIndex = 3;
            this.tbFriendlyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFriendlyName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFriendlyName_Validating);
            this.tbFriendlyName.Validated += new System.EventHandler(this.tbFriendlyName_Validated);
            // 
            // tbSerialNum
            // 
            this.tbSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSerialNum.Location = new System.Drawing.Point(187, 18);
            this.tbSerialNum.Name = "tbSerialNum";
            this.tbSerialNum.Size = new System.Drawing.Size(178, 21);
            this.tbSerialNum.TabIndex = 2;
            this.tbSerialNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.tcPreference);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmPreference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.frmPreference_Load);
            this.Shown += new System.EventHandler(this.frmPreference_Shown);
            this.tcPreference.ResumeLayout(false);
            this.tpSystemSettings.ResumeLayout(false);
            this.tlpSystemSettings.ResumeLayout(false);
            this.tlpSystemSettings.PerformLayout();
            this.tpDeviceListManagement.ResumeLayout(false);
            this.tlpDeviceListManagement.ResumeLayout(false);
            this.tlpDeviceListManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceListManagement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPreference;
        private System.Windows.Forms.TabPage tpSystemSettings;
        private System.Windows.Forms.TableLayoutPanel tlpSystemSettings;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Label lbNIC;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.ComboBox cbNIC;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TabPage tpDeviceListManagement;
        private System.Windows.Forms.TableLayoutPanel tlpDeviceListManagement;
        private System.Windows.Forms.Label lbSerialNum;
        private System.Windows.Forms.Label lbFriendlyName;
        private System.Windows.Forms.TextBox tbSerialNum;
        private System.Windows.Forms.TextBox tbFriendlyName;
        private System.Windows.Forms.Button bDeviceSet;
        private System.Windows.Forms.Button bDeviceDelete;
        private System.Windows.Forms.DataGridView dgvDeviceListManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcDeviceListManagementFriendlyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcDeviceListManagementSerialNum;
    }
}