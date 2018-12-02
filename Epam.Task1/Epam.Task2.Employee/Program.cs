using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Employee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Employee emp1 = new Employee("Иван", "Иванов");
                emp1.Position = "Директор";
                emp1.WorkExperience = 10;
                Employee emp2 = new Employee("Сидор", "Сидоров", new DateTime(1996, 4, 23));
                emp2.Position = "ЗамДир";
                emp2.WorkExperience = 5;
                Employee emp3 = new Employee("Борис", "Борисов", "Борисович", new DateTime(1990, 10, 10));
                emp3.Position = "Приносит кофе";
                emp3.WorkExperience = 1;
                Employee emp4 = new Employee("Петр", "Петров", "Петрович");
                emp4.Position = "ЗавСкладо#м";
                emp4.WorkExperience = 1;
                Employee emp5 = new Employee("Сидор", "Сидоров", new DateTime(1996, 4, 23));
                Employee emp6 = new Employee("Иван", "Иванов");
                Employee emp7 = new Employee("Борис", "Борисов", "Борисович", new DateTime(1990, 10, 10));
                var employees = new List<Employee>
                {
                    emp1, emp2, emp3, emp4, emp5, emp6, emp7
                };

                foreach (var employee in employees)
                {
                    employee.PrintInfo();
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
