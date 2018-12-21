using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.Round;

namespace Epam.Task2.Ring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Ring ring1 = new Ring(1, 5);
                Ring ring2 = new Ring(2, 5, new Point(2, 5));
                Console.WriteLine("Area: {0}{1}Length: {2}{1}Coordinate: {3},{4}", ring1.Area, Environment.NewLine, ring1.Length, ring1.X, ring1.Y);
                Console.WriteLine("Area: {0}{1}Length: {2}{1}Coordinate: {3},{4}", ring2.Area, Environment.NewLine, ring2.Length, ring2.X, ring2.Y);
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
