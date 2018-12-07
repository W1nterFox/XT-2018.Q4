using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var users = new List<User>
            {
                new User("Иван", "Иванов"),
                new User("Петр", "Петров", "Петрович"),
                new User("Сидор", "Сидоров", new DateTime(1996, 4, 23)),
                new User("Борис", "Борисов", "Борисович", new DateTime(1990, 10, 10))
            };

                foreach (var user in users)
                {
                    user.PrintInfo();
                    Console.WriteLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }         
        }
    }
}
