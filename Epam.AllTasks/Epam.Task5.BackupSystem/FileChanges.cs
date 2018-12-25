using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class FileChanges
    {
        private static FileSystemWatcher fileWatcher;

        private static FileSystemWatcher dirWatcher;
        
        public static void InitWatchers()
        {
            if (!Directory.Exists(Constants.BackupDirName))
            {
                Directory.CreateDirectory(Constants.BackupDirName);
            }

            if (!Directory.Exists(Constants.SourceDirName))
            {
                Directory.CreateDirectory(Constants.SourceDirName);
            }

            dirWatcher = new FileSystemWatcher(Constants.SourceDirName);

            fileWatcher = new FileSystemWatcher(Constants.SourceDirName, "*.txt");
        }

        public static void BeginToWatch(string sourceDirName, string destSourceDirName)
        {
            InitWatchers();
            FileWatcher();
            DirectoryWatcher();

            Console.WriteLine("0 - Exit");
            while (Console.Read() != '0')
            {
                continue;
            }
        }

        private static void DirectoryWatcher()
        {
            dirWatcher.IncludeSubdirectories = true;
            dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
            dirWatcher.EnableRaisingEvents = true;

            dirWatcher.Deleted += OnDeleted;
            dirWatcher.Created += OnCreated;
            dirWatcher.Renamed += OnRenamed;
        }

        private static void FileWatcher()
        {
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName;

            fileWatcher.Changed += OnChanged;
            fileWatcher.Created += OnCreated;
            fileWatcher.Deleted += OnDeleted;
            fileWatcher.Renamed += OnRenamed;

            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.InternalBufferSize = 1024 * 1024;
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (sender == fileWatcher)
                    {
                        LogingChanges.LogEventInfo(sender, e);
                    }
                    else if (sender == dirWatcher)
                    {
                        LogingChanges.LogEventInfo(sender, e);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void SleepEvent()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    var isDirectory = ElementIsDirectory(e);

                    if (sender == fileWatcher && !isDirectory)
                    {
                        LogingChanges.LogEventInfo(sender, e);
                        string temppath = GetTempPath(e);

                        if (!File.Exists(temppath))
                        {
                            File.Create(temppath).Close();
                        }
                    }
                    else if (sender == dirWatcher)
                    {
                        string temppath = GetTempPath(e);
                        Directory.CreateDirectory(temppath);

                        LogingChanges.LogEventInfo(sender, e);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    var isDirectory = ElementIsDirectory(e);

                    if (sender == fileWatcher && !isDirectory)
                    {
                        LogingChanges.LogEventInfo(sender, e);

                        string temppath = GetTempPath(e);
                        string text = GetDataFromFile(e.FullPath);
                        if (!File.Exists(temppath))
                        {
                            File.Copy(e.FullPath, temppath);
                        }

                        WriteDataToFile(temppath, text);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            while (true)
            {
                try
                {
                    var isDirectory = ElementIsDirectory(e);

                    if (sender == fileWatcher && !isDirectory)
                    {
                        LogingChanges.LogOnRenamedInfo(sender, e);
                    }
                    else if (sender == dirWatcher)
                    {
                        string temppath = GetTempPath(e);
                        Directory.CreateDirectory(temppath);
                        LogingChanges.LogOnRenamedInfo(sender, e);
                    }

                    return;
                }

                catch
                {
                    SleepEvent();
                }
            }
        }

        private static string GetTempPath(FileSystemEventArgs e)
        {
            string line = e.FullPath;
            line = line.Replace(Constants.SourceDirName, Constants.BackupDirName).Replace(Path.GetFileName(e.Name), "");
            string temppath = Path.Combine(line, $"${Constants.DateFormat(DateTime.Now)}${Path.GetFileName(e.Name)}");
            return temppath;
        }

        private static bool ElementIsDirectory(FileSystemEventArgs e)
        {
            return File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory);
        }

        private static string GetDataFromFile(string path)
        {
            string text;
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }

        private static void WriteDataToFile(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(data);
            }
        }
    }
}
