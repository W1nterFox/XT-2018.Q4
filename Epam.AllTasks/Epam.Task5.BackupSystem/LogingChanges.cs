using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class LogingChanges
    {
        public static void LogOnRenamedInfo(object sender, RenamedEventArgs e)
        {
            string typeOfObject;
            if (((FileSystemWatcher)sender).NotifyFilter == NotifyFilters.DirectoryName)
            {
                typeOfObject = "dirWatcher";
            }
            else
            {
                typeOfObject = "fileWatcher";
            }

            using (StreamWriter writer = new StreamWriter(Constants.LogPath, true))
            {
                var now = DateTime.Now;
                writer.WriteLine($"{Constants.DateFormat(DateTime.Now)}|{typeOfObject}|{e.OldFullPath}|{e.ChangeType}|{e.FullPath}");
            }
        }

        public static void LogEventInfo(object sender, FileSystemEventArgs e)
        {
            string typeOfObject;
            if (((FileSystemWatcher)sender).NotifyFilter == NotifyFilters.DirectoryName)
            {
                typeOfObject = "dirWatcher";
            }
            else
            {
                typeOfObject = "fileWatcher";
            }

            using (StreamWriter writer = new StreamWriter(Constants.LogPath, true))
            {
                writer.WriteLine($"{Constants.DateFormat(DateTime.Now)}|{typeOfObject}|{e.FullPath}|{e.ChangeType}");
            }
        }
    }
}
