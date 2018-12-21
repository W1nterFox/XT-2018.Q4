using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class BackupSystem
    {
        private readonly FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"\ForWatching\";
        private string pathDir = @"D:\ForWatching\";
        private string pathDirBackups = @"D:\Backups\";

        public void InitMonitoring()
        {
            ////Тут нужно будет сделать выбор папки для слежения пользователем
            fileSystemWatcher.Path = pathDir;
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fileSystemWatcher.Filter = "*.txt";
            fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
        }

        public void StartMonitoring()
        {
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void StopMonitoring()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            this.SaveChangedDirectory();
        }

        private void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)
        {
            this.SaveChangedDirectory();
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.SaveChangedDirectory();
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            this.SaveChangedDirectory();
        }

        private void SaveChangedDirectory()
        {
            string targetDirName = this.GenerateDirectoryName();
            foreach (var file in Directory.GetFiles(pathDir))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.EndsWith(".txt"))
                {  
                    File.Delete(Path.Combine(targetDirName, fileName));
                }
            }

            Directory.CreateDirectory(targetDirName);
            
            foreach (var file in Directory.GetFiles(pathDir))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.EndsWith(".txt"))
                {
                    try
                    {
                        File.Copy(file, Path.Combine(targetDirName, fileName), true);
                    }
                    catch (Exception)
                    {

                    }
                }
            }  
        }

        private string GenerateDirectoryName()
        {
            string currentTimeWithoutMinutes = DateTime.Now.ToString("yyyy-MM-dd HH.");
            string currentMinutes = DateTime.Now.ToString("mm");
            int currentMinutesInt = int.Parse(currentMinutes);
            int minutesRoundedBy5 = currentMinutesInt / 5 * 5;

            string resultPath = currentTimeWithoutMinutes + minutesRoundedBy5;
            return Path.Combine(pathDirBackups, resultPath);
        }
    }
}
