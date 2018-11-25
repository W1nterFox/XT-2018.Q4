using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1.Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            Console.WriteLine(rectangle.CalcSquare());

            rectangle.aSide = 3;
            rectangle.bSide = 5;
            Console.WriteLine(rectangle.CalcSquare());

            Rectangle rectangle2 = new Rectangle(5, 6);
            Console.WriteLine(rectangle2.CalcSquare());

            Rectangle rectangle3 = new Rectangle(-5, 6);
            Console.WriteLine(rectangle3.CalcSquare());
            rectangle3.bSide = -1;
            Console.WriteLine(rectangle3.CalcSquare());
        }
    }
}
