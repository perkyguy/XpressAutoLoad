# Xpress IDE + Eval Board Auto-Loader
The Xpress IDE is great especially when using it in conjunction with the Xpress Evaluation board. It's super simple to just drag-and-drop the HEX files over to the Xpress drive. However, if you like to use the burn-and-learn methodology for your embedded software development then doing this for the 384932598748 HEX files you generate can be a little grating (let alone when they get renamed to "MyProject (####).hex" and pollute your folder). 

This is a tool, written in C#, which will monitor a folder for new HEX files, and then transfer them to an MPLab Xpress Evaluation board you have connected to your computer. It can remove the "(####)" portion tacked on also, so you just keep the latest file you've downloaded (at least this is the format Chrome does).


# Installation
None really, either build or run the generated binary. It will run and place an icon in your system tray.

So far this is only for Windows -- sorry Mac+Linux users :/ If I get the time, and if anyone actually wants it, I can try to re-write it in something that is a little more friendly with the other OS flavors.

# Configuration
Once your run the file
- Right click on the icon in your system tray
- Click configure
 
A little window will pop up showing a few different options
- Monitored Folder
  This is the folder which will be monitored for new HEX files
- Chosen Xpress Board
  This is the board which you want to copy the file over to
  Note: This should auto-populate every 500ms, so if you plug a new one in, it should be catch it
- Monitor on start
  Next time you start this up, do you want to start monitoring?
- Auto-Load First Available (if chosen not present)
  If your chosen board disappears, but you have another (switched USB ports or something, have more than one board...stuff like that), do you want to switch your default over to another?
- Sanitize New Files (e.g. remove(####) from filename)
  Do you want to try and clean up the files and leave only the latest, removing all of the "MyProject (###).hex" files?

# Use
Download/Copy new Hex files into your monitored folder. You should get pop-ups saying if things worked or failed.

If you want to start/stop monitoring at any time, you can either
- Double-Click the tray icon to toggle your monitoring mode
- Right-Click on the tray icon and select "start"/"pause"
- Right-Click and click exit


# Other things
This is not an official Microchip Technology Inc. tool, just something I wrote to assist with my own embedded development work

If you have suggestions/problems with this, throw in some issues and I'll try to fix them as soon as possible

Thanks and let me know what you think!
