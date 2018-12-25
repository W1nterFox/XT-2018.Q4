using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class StructureEventElement
    {
        public StructureEventElement(string dateAndTime, string typeOfObject, string path, string typeOfChanges)
        {
            this.TimeOfChanges = ParseDate(dateAndTime);
            this.TypeOfChanges = typeOfChanges;
            this.PathFile = path;
            this.TypeOfObject = typeOfObject;
        }

        public StructureEventElement(string dateAndTime, string typeOfObject, string newPath, string typeOfChanges, string oldPath)
            : this(dateAndTime, typeOfObject, newPath, typeOfChanges)
        {
            this.OldPathToFile = oldPath;
        }

        public DateTime TimeOfChanges { get; set; }

        public string TypeOfChanges { get; set; }

        public string PathFile { get; set; }

        public string OldPathToFile { get; set; }

        public string TypeOfObject { get; set; }

        public static StructureEventElement ParseLog(string line)
        {
            string[] array = line.Split('|');

            string timeOfChanges = array[0];
            string typeOfObject = array[1];
            string typeOfChanges = array[3];

            if (array[3] == "Created" || array[3] == "Deleted" || array[3] == "Changed")
            {
                string path = array[2];
                return new StructureEventElement(timeOfChanges, typeOfObject, path, typeOfChanges);
            }
            else if (array[3] == "Renamed")
            {
                string oldPath = array[2];
                string newPath = array[4];
                return new StructureEventElement(timeOfChanges, typeOfObject, newPath, typeOfChanges, oldPath);
            }
            else
            {
                throw new ArgumentException("Change type error");
            }
        }

        public static string DateFromLogToString(DateTime date)
        {
            return Constants.DateFormat(date);
        }

        private static DateTime ParseDate(string dateAndTime)
        {
            try
            {
                DateTime newDate = DateTime.ParseExact(dateAndTime, Constants.DateTimeFormat, CultureInfo.CurrentCulture);
                return newDate;
            }
            catch
            {
                throw new ArgumentException("DateParse error");
            }
        }
    }
}
