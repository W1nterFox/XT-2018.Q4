using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1 - Watch the folder");
            Console.WriteLine("2 - Backup folder");
            Console.WriteLine();
            Console.WriteLine("0 - Exit");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                {
                    //Console.WriteLine("Input path to directory for watching:");
                    //Constants.SourceDirName = PickDirectory();

                    Console.WriteLine();
                    Console.WriteLine("Watching...");
                    FileChanges.BeginToWatch(Constants.SourceDirName, Constants.BackupDirName);
                    
                    break;
                }

                case "2":
                {
                    try
                    {
                        //Console.WriteLine("Input path to watching directory:");
                        //Constants.SourceDirName = PickDirectory();

                        DateTime dateTime = ReadDateFromConsole();

                        BackupSystem.Start(dateTime, Constants.SourceDirName, Constants.BackupDirName);
                        break;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                        break;
                    }
                }

                case "0":
                {
                    Environment.Exit(0);
                    break;
                }

                default:
                {
                    Console.WriteLine("Valid values are 0, 1 and 2");
                    break;
                }
            }
        }

        public static string PickDirectory()
        {
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Sorry, your directory doesn`t exist.");
                Console.WriteLine("Try again please or type '0' for close program:");
                path = Console.ReadLine();
                {
                    if (path == "0")
                    {
                        Environment.Exit(0);
                    }
                }
            }

            return path;
            
        }

        public static DateTime ReadDateFromConsole()
        {
            try
            {
                Console.WriteLine("Please, input date and time:");

                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Month: ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Day: ");
                int day = int.Parse(Console.ReadLine());
                
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                
                Console.Write("Minutes: ");
                int mins = int.Parse(Console.ReadLine());
                
                Console.Write("Seconds (optional): ");
                int seconds = 0;
                int.TryParse(Console.ReadLine(), out seconds);

                return new DateTime(year, month, day, hours, mins, seconds);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.InnerException);
                throw;
            }
            

            
        }
    }
}
