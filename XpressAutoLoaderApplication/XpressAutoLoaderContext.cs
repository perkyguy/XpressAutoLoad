using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;
using System.ComponentModel;

/* 
 * Things I need to add...
 * Config:
 *	Context menu: 
 *	General:
 *		- Alert when selected Board disconnected (Error?)
 *			- Unless autoselect
*/
namespace XpressAutoLoader
{
    public class XpressAutoLoaderContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
		Configuration configWindow = new Configuration();
		MenuItem pauseWatcherMenuItem;
		MenuItem startWatcherMenuItem;
		
			private System.Threading.Timer watchFolderTimer;
		private FileSystemWatcher watcher;
		private bool watcherRunning;

        public XpressAutoLoaderContext()
        {
			MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
			pauseWatcherMenuItem = new MenuItem("Pause", new EventHandler(pauseWatcherEvent));
			startWatcherMenuItem = new MenuItem("Start", new EventHandler(startWatcherEvent));
			
			Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(settingsListener);

			notifyIcon.DoubleClick += new EventHandler(changeWatcherState);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {startWatcherMenuItem, pauseWatcherMenuItem, configMenuItem, exitMenuItem });
			notifyIcon.Text = "MPLab Xpress Auto-Loader";
            notifyIcon.Visible = true;

			clearWatcher();
			setWatcherState(Properties.Settings.Default.AutoStart);
			configWindow.autoSelectFirstXpress(true);
        }

		public void setWatcherState(bool run)
		{
			Console.WriteLine("Turn the key? {0}", run);
			if(run){
				startWatcher();
			}
			else
			{
				clearWatcher();
			}
		}

		public void clearWatcher()
		{
			Console.WriteLine("Burning watcher down!");
			
			destroyWatcher();
			destroyWatcherTimer();

			updateIcon();
			pauseWatcherMenuItem.Enabled = false;
			startWatcherMenuItem.Enabled = true;
		}

		public void startWatcher()
		{
			if (!checkConfigWatchedFolderExists()) { return; }
			destroyWatcher();
			Console.WriteLine("Starting up the watcher!");
			watcherRunning = true;
			watcher = new FileSystemWatcher();
			watcher.Path = Properties.Settings.Default.WatchedFolder;
			watcher.Filter = "*.hex";
			watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
			watcher.Changed += new FileSystemEventHandler(watcher_Changed);
			watcher.EnableRaisingEvents = true;

			updateIcon();
			pauseWatcherMenuItem.Enabled = true;
			startWatcherMenuItem.Enabled = false;
		}

		private void updateIcon()
		{
			notifyIcon.Icon = watcherRunning ? Properties.Resources.AppRun : Properties.Resources.AppPause;
			notifyIcon.Visible = true;
		}

		private void pauseWatcherEvent(object sender, EventArgs e){
			setWatcherState(false);
		}

		
		private void startWatcherEvent(object sender, EventArgs e){
			setWatcherState(true);
		}


		private void changeWatcherState(object sender, EventArgs e)
		{
			Console.WriteLine("Changing State from {0}, {1}", watcherRunning, !watcherRunning);
			setWatcherState(!watcherRunning);
		}

		private void destroyWatcher()
		{
			if (watcher == null) { return; }
			watcher.Dispose();
			watcherRunning = false;
		}

		private bool checkConfigWatchedFolderExists()
		{
			return Directory.Exists(Properties.Settings.Default.WatchedFolder);
		}

		private bool checkConfigXpressExists()
		{
			return Directory.Exists(Properties.Settings.Default.SelectedXpress);
		}
		
		private void checkFolder(object e)
		{
			FileSystemEventArgs eFromWatcher = (FileSystemEventArgs)e;
			if (e == null) { clearWatcher(); return; }
			if (!File.Exists(eFromWatcher.FullPath)){ return ; }
			if (IsFileReady(eFromWatcher.FullPath))
			{
				
				destroyWatcherTimer();
				if(!checkConfigXpressExists()){
					if (!Properties.Settings.Default.AutoSelect || !configWindow.autoSelectFirstXpress(true))
					{
						xpressGoneError();
						return;
					}
				}
				string cleanName = cleanFilename(eFromWatcher);
				if(hexCopy(eFromWatcher, cleanName)){
					hexRename(eFromWatcher, cleanName);
				}
			}
		}

		private void xpressGoneError()
		{
			notifyIcon.BalloonTipTitle = "Board Missing";
			notifyIcon.BalloonTipText = "Your Xpress board doesn't exist. Check your configuration is correct.";
			notifyIcon.ShowBalloonTip(10000);
		}

		private void hexRename(FileSystemEventArgs eFromWatcher, string cleanName)
		{
			if (!Properties.Settings.Default.AutoRenameFile) { return; }
			if (eFromWatcher.Name.Equals(cleanName)) { return; }
			try
			{
				string cleanFullPath = eFromWatcher.FullPath.Replace(eFromWatcher.Name, cleanName);
				if (File.Exists(cleanFullPath))
				{
					File.Delete(cleanFullPath);
				}
				File.Move(eFromWatcher.FullPath, cleanFullPath);
				notifyIcon.BalloonTipText += Environment.NewLine + "The filename was sanitized";
				notifyIcon.ShowBalloonTip(5000);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				notifyIcon.BalloonTipText += Environment.NewLine + "Something went wrong with renaming the file, you'll have a bunch of the files now...sorry :/";
				notifyIcon.ShowBalloonTip(5000);
			}
		}


		private bool hexCopy(FileSystemEventArgs eFromWatcher, string cleanName)
		{
			try
			{
				File.Copy(eFromWatcher.FullPath, Properties.Settings.Default.SelectedXpress + cleanName, true);
				notifyIcon.BalloonTipTitle = "Found Hex!";
				notifyIcon.BalloonTipText = "Found " + cleanName + Environment.NewLine;
				notifyIcon.BalloonTipText += "Found in " + Properties.Settings.Default.WatchedFolder + Environment.NewLine;
				notifyIcon.BalloonTipText += "Copying to " + Properties.Settings.Default.SelectedXpress;
				notifyIcon.ShowBalloonTip(5000);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				notifyIcon.BalloonTipTitle = "Copy Error";
				notifyIcon.BalloonTipText = "Something went wrong with copying the file over, you gotta do it by hand...guess this tool is useless right now?";
				notifyIcon.ShowBalloonTip(5000);
				return false;
			}
		}

		private void destroyWatcherTimer()
		{
			if (watchFolderTimer != null) { watchFolderTimer.Dispose(); }
		}

		private void watcher_Changed(object sender, FileSystemEventArgs e)
		{
			if (watchFolderTimer != null) { watchFolderTimer.Dispose(); }
			watchFolderTimer = new System.Threading.Timer(checkFolder, e, 0, 500);
		}

        private void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
			if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Application.Exit();
        }

		private static bool IsFileReady(String sFilename)
		{
			// If the file can be opened for exclusive access it means that the file
			// is no longer locked by another process.
			try
			{
				using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
				{
					return inputStream.Length > 0;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		private static string cleanFilename(FileSystemEventArgs eFromWatcher)
		{
			Regex rgx = new Regex("(\\w+)(\\s+\\(\\d+\\))?\\.hex");
			string cleanName = rgx.Replace(eFromWatcher.Name, "$1.hex");
			return cleanName;
		}

		private void settingsListener(object sender, PropertyChangedEventArgs e)
		{
			Console.WriteLine("Settings updated! Changed {0}", e.PropertyName);
			
			startWatcher();	
		}

    }
}
