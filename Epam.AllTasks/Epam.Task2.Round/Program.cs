using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Round
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Point point;
            Round round;
            try
            {
                point = new Point(5, 5);
                round = new Round(point, 1);
                round.PrintInfo();
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
