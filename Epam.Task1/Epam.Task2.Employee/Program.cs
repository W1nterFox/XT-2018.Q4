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
                Employee emp1 = new Employee("Ivan", "Ivanov");
                emp1.Position = "Director";
                emp1.WorkExperience = 10;
                Employee emp2 = new Employee("Sidor", "Sidorov", new DateTime(1996, 4, 23));
                emp2.Position = "Deputy Director";
                emp2.WorkExperience = 5;
                Employee emp3 = new Employee("Boris", "Borisov", "Borisovich", new DateTime(1990, 10, 10));
                emp3.Position = "coffee maker";
                emp3.WorkExperience = 1;
                Employee emp4 = new Employee("Petr", "Petrov", "Petrovich");
                emp4.Position = "Warehouse Manager";
                emp4.WorkExperience = 1;
                Employee emp5 = new Employee("Sidor", "Sidorov", new DateTime(1996, 4, 23));
                Employee emp6 = new Employee("Ivan", "Ivanov");
                Employee emp7 = new Employee("Boris", "Borisov", "Borisovich", new DateTime(1990, 10, 10));
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
