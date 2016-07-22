namespace XpressAutoLoader
{
    partial class Configuration
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
			this.components = new System.ComponentModel.Container();
			this.autoSelectChk = new System.Windows.Forms.CheckBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.browseMonitorFolderBtn = new System.Windows.Forms.Button();
			this.xpressDriveCombo = new System.Windows.Forms.ComboBox();
			this.monitorFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.monitorFolderTxt = new System.Windows.Forms.TextBox();
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.autoMonitorChk = new System.Windows.Forms.CheckBox();
			this.autoSanitizeFileChk = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// showMessageCheckBox
			// 
			this.autoSelectChk.AutoSize = true;
			this.autoSelectChk.Checked = true;
			this.autoSelectChk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoSelectChk.Location = new System.Drawing.Point(19, 122);
			this.autoSelectChk.Name = "showMessageCheckBox";
			this.autoSelectChk.Size = new System.Drawing.Size(251, 17);
			this.autoSelectChk.TabIndex = 0;
			this.autoSelectChk.Text = "Auto-Load First Available (if chosen not present)";
			this.autoSelectChk.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveButton.Location = new System.Drawing.Point(177, 195);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Ok";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(96, 195);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// browseMonitorFolderBtn
			// 
			this.browseMonitorFolderBtn.Location = new System.Drawing.Point(353, 33);
			this.browseMonitorFolderBtn.Name = "browseMonitorFolderBtn";
			this.browseMonitorFolderBtn.Size = new System.Drawing.Size(29, 23);
			this.browseMonitorFolderBtn.TabIndex = 3;
			this.browseMonitorFolderBtn.Text = "...";
			this.browseMonitorFolderBtn.UseVisualStyleBackColor = true;
			this.browseMonitorFolderBtn.Click += new System.EventHandler(this.browseMonitorFolderBtn_Click);
			// 
			// xpressDriveCombo
			// 
			this.xpressDriveCombo.FormattingEnabled = true;
			this.xpressDriveCombo.Location = new System.Drawing.Point(131, 61);
			this.xpressDriveCombo.Name = "xpressDriveCombo";
			this.xpressDriveCombo.Size = new System.Drawing.Size(121, 21);
			this.xpressDriveCombo.TabIndex = 4;
			// 
			// monitorFolderTxt
			// 
			this.monitorFolderTxt.Location = new System.Drawing.Point(131, 35);
			this.monitorFolderTxt.Name = "monitorFolderTxt";
			this.monitorFolderTxt.ReadOnly = true;
			this.monitorFolderTxt.Size = new System.Drawing.Size(216, 20);
			this.monitorFolderTxt.TabIndex = 5;
			this.monitorFolderTxt.WordWrap = false;
			// 
			// updateTimer
			// 
			this.updateTimer.Enabled = true;
			this.updateTimer.Interval = 500;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Monitored Folder";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Chosen Xpress Board";
			// 
			// autoMonitorChk
			// 
			this.autoMonitorChk.AutoSize = true;
			this.autoMonitorChk.Checked = true;
			this.autoMonitorChk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoMonitorChk.Location = new System.Drawing.Point(19, 99);
			this.autoMonitorChk.Name = "autoMonitorChk";
			this.autoMonitorChk.Size = new System.Drawing.Size(101, 17);
			this.autoMonitorChk.TabIndex = 9;
			this.autoMonitorChk.Text = "Monitor on Start";
			this.autoMonitorChk.UseVisualStyleBackColor = true;
			// 
			// sanitizeFileBtn
			// 
			this.autoSanitizeFileChk.AutoSize = true;
			this.autoSanitizeFileChk.Location = new System.Drawing.Point(19, 145);
			this.autoSanitizeFileChk.Name = "sanitizeFileBtn";
			this.autoSanitizeFileChk.Size = new System.Drawing.Size(272, 17);
			this.autoSanitizeFileChk.TabIndex = 10;
			this.autoSanitizeFileChk.Text = "Sanitize New Files (e.g. remove (###) from filename)";
			this.autoSanitizeFileChk.UseVisualStyleBackColor = true;
			// 
			// Configuration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 230);
			this.Controls.Add(this.autoSanitizeFileChk);
			this.Controls.Add(this.autoMonitorChk);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.monitorFolderTxt);
			this.Controls.Add(this.xpressDriveCombo);
			this.Controls.Add(this.browseMonitorFolderBtn);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.autoSelectChk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Configuration";
			this.Text = "Configuration";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveSettings);
			this.Shown += new System.EventHandler(this.LoadSettings);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoSelectChk;
        private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button browseMonitorFolderBtn;
		private System.Windows.Forms.ComboBox xpressDriveCombo;
		private System.Windows.Forms.FolderBrowserDialog monitorFolderDialog;
		private System.Windows.Forms.TextBox monitorFolderTxt;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox autoMonitorChk;
		private System.Windows.Forms.CheckBox autoSanitizeFileChk;
    }
}

