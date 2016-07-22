using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace XpressAutoLoader
{
    public partial class Configuration : Form
    {
		public BindingList<String> drives = new BindingList<string>();
		private void UpdateDrives()
		{
			try { 
				var connected_drives = System.IO.DriveInfo.GetDrives()
					.Where(d => d.IsReady && d.DriveType == System.IO.DriveType.Removable)
					.Where(d => d.VolumeLabel.ToLower().Contains("xpress"))
					// .Select(d => d.Name + " (" + d.VolumeLabel + ")")
					 .Select(d => d.Name);
				foreach (string cDrive in connected_drives.Where(d => !drives.Contains(d)).ToList())
				{
					drives.Add(cDrive);
				}
				foreach (string cDrive in drives.Where(d => !connected_drives.Contains(d)).ToList())
				{
					drives.Remove(cDrive);
				}
			}
			catch
			{
				return;
			}
		}

		public Configuration()
        {
			InitializeComponent();
			UpdateDrives();
			xpressDriveCombo.DataSource = drives;
        }

		public bool autoSelectFirstXpress(bool saveAfterLoad)
		{
			Properties.Settings cfg = Properties.Settings.Default;
			if (!cfg.AutoSelect) { return false; }
			if ( validXpress(cfg)) {
				return true;
			}
			UpdateDrives();
			cfg.SelectedXpress = drives.OrderBy(d => d).FirstOrDefault();
			if(validXpress(cfg) && saveAfterLoad){
				cfg.Save();
				return true;
			}
			return false;
		}

		private static bool validXpress(Properties.Settings cfg)
		{			
			return cfg.SelectedXpress != null && cfg.SelectedXpress != "" && System.IO.Directory.Exists(cfg.SelectedXpress);
		}

		private void LoadSettings(object sender, EventArgs e)
        {
			Properties.Settings cfg = Properties.Settings.Default;
			autoSelectChk.Checked = cfg .AutoSelect;
			xpressDriveCombo.SelectedItem = cfg.SelectedXpress;
			monitorFolderTxt.Text = cfg.WatchedFolder;
			monitorFolderDialog.SelectedPath = cfg.WatchedFolder;
			autoMonitorChk.Checked = cfg.AutoStart;
			autoSanitizeFileChk.Checked = cfg.AutoRenameFile;

        }

		private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
				applySettings();
            }
        }

		private void applySettings()
		{
			Properties.Settings cfg = Properties.Settings.Default;
			if (cfg.AutoSelect != autoSelectChk.Checked) { cfg.AutoSelect = autoSelectChk.Checked; }
			if (cfg.AutoStart != autoMonitorChk.Checked) { cfg.AutoStart = autoMonitorChk.Checked; }
			if (cfg.AutoRenameFile != autoSanitizeFileChk.Checked) { cfg.AutoRenameFile = autoSanitizeFileChk.Checked; }
			if (cfg.SelectedXpress != (string)xpressDriveCombo.SelectedValue) { cfg.SelectedXpress = (string)xpressDriveCombo.SelectedValue; };
			if (cfg.WatchedFolder != (string)monitorFolderTxt.Text) { cfg.WatchedFolder = (string)monitorFolderTxt.Text; };
			cfg.Save();
		}

		private void browseMonitorFolderBtn_Click(object sender, EventArgs e)
		{
			if (monitorFolderDialog.ShowDialog() == DialogResult.OK)
			{
				monitorFolderTxt.Text = monitorFolderDialog.SelectedPath;
			}
		}

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			UpdateDrives();
		}

    }
}