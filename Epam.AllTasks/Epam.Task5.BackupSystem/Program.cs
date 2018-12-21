using System;
using System.Collections.Generic;
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
            BackupSystem backupSystem = new BackupSystem();
            backupSystem.InitMonitoring();

            string startMonitoring = "Start monitoring";
            string stopMonitoring = "Stop monitoring";
            string currentMode = startMonitoring;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose menu element:");
                Console.WriteLine("1 - {0}", currentMode);
                Console.WriteLine("2 - Rollback changes");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");

                int pickedElemMenu;
                while (!int.TryParse(Console.ReadLine(), out pickedElemMenu))
                {
                    Console.WriteLine("Incorrect value: valid values are 0 - 2");
                }
                

                switch (pickedElemMenu)
                {
                    case 0:
                        {
                            
                            Environment.Exit(0);
                            break;
                        }

                    case 1:
                        {
                            if (currentMode == startMonitoring)
                            {
                                backupSystem.StartMonitoring();
                                currentMode = stopMonitoring;
                            }
                            else
                            {
                                backupSystem.StopMonitoring();
                                currentMode = startMonitoring;
                            }
                            
                            break;
                        }

                    case 2:
                        {
                            
                            break;
                        }
                        
                    default:
                        {
                            Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                            break;
                        }
                }
            }
        }
    }
}
