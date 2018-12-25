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
        public static void Start(DateTime dateAndTime, string destinationDirName, string sourceDirName)
        {
            ClearTrackingFolder(destinationDirName);
            List<StructureEventElement> logItems = new List<StructureEventElement>();
            using (StreamReader logFile = new StreamReader(Constants.LogPath))
            {
                string line;
                while ((line = logFile.ReadLine()) != null)
                {
                    try
                    {
                        var logitem = StructureEventElement.ParseLog(line);

                        if (logitem.TimeOfChanges > dateAndTime)
                        {
                            continue;
                        }
                        else
                        {
                            logItems.Add(logitem);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            try
            {
                foreach (var item in logItems)
                {
                    switch (item.TypeOfChanges)
                    {
                        case "Changed":
                            {
                                if (File.Exists(item.PathFile))
                                {
                                    File.Delete(item.PathFile);
                                }
                                string temppath = FileChanges.GetTempPath(item.PathFile, item.TimeOfChanges);
                                File.Copy(temppath, item.PathFile);
                                break;
                            }
                        case "Created":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    string temppath = FileChanges.GetTempPath(item.PathFile, item.TimeOfChanges);
                                    File.Copy(temppath, item.PathFile);
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    Directory.CreateDirectory(item.PathFile);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                        case "Deleted":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    File.Delete(item.PathFile);
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    Directory.Delete(item.PathFile, true);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                        case "Renamed":
                            {
                                if (item.TypeOfObject.Equals("fileWatcher"))
                                {
                                    string text = GetDataFromFile(item.OldPathToFile);
                                    File.Delete(item.OldPathToFile);
                                    File.Create(item.PathFile).Close();
                                    WriteDataToFile(item.PathFile, text);
                                    break;
                                }
                                else if (item.TypeOfObject.Equals("dirWatcher"))
                                {
                                    DirectoryCopy(item.OldPathToFile, Constants.BufDirName, true);
                                    Directory.Delete(item.OldPathToFile, true);
                                    Directory.CreateDirectory(item.PathFile);
                                    DirectoryCopy(Constants.BufDirName, item.PathFile, true);
                                    ClearTrackingFolder(Constants.BufDirName);
                                    break;
                                }
                                else throw new ArgumentException();
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                
                file.CopyTo(temppath, false);
            }
            
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
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
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(data);
                fs.Write(info, 0, info.Length);
            }
        }

        //private static string GetTempPath(StructureEventElement item)
        //{
        //    string line = item.PathFile;
            
        //    line = line.Replace(Constants.SourceDirName, Constants.BackupDirName).Replace(Path.GetFileName(item.PathFile), "");
        //    string temppath = Path.Combine(line, $"${StructureEventElement.DateFromLogToString(item.TimeOfChanges)}${Path.GetFileName(item.PathFile)}");
        //    return temppath;
        //}

        private static void ClearTrackingFolder(string trackingFolderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(trackingFolderPath);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
            foreach (DirectoryInfo subdir in dirInfos)
            {
                Directory.Delete(subdir.FullName, true);
            }
        }
    }
}
