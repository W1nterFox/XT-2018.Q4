using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle;
            try
            {
                triangle = new Triangle(5, 5, 9);
                triangle.PrintInfo();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.ActualValue);
            }
        }
    }
}
