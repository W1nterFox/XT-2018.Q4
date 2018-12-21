using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1.Rectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            Console.WriteLine(rectangle.CalcSquare());

            try
            {
                rectangle.Width = 3;
                rectangle.Length = 5;
                Console.WriteLine(rectangle.CalcSquare());

                Rectangle rectangle2 = new Rectangle(5, 6);
                Console.WriteLine(rectangle2.CalcSquare());

                Rectangle rectangle3 = new Rectangle(-5, 6);
                Console.WriteLine(rectangle3.CalcSquare());
                rectangle3.Length = -1;
                Console.WriteLine(rectangle3.CalcSquare());
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
