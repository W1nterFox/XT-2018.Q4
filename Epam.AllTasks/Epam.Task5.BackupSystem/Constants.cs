using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class Constants
    {
        public static string LogPath { get; } = @".\log.txt";
        public static string SourceDirName { get; set; } = @".\ForWatching";
        public static string BackupDirName { get; } = @".\Backups";
        public static string DateTimeFormat { get; } = "yyyy.MM.dd HH.mm.ss";

        public static string DateFormat(DateTime item)
        {
            return item.ToString(DateTimeFormat);
        }
    }
}
