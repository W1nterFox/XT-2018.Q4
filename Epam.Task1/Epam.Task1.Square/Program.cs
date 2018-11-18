using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawSquare(10);
        }
        static void DrawSquare(int num)
        {
            if (num <= 0) throw new ArgumentException("Value of argument should be more than 0");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i == num / 2 && j == num / 2) Console.Write(" ");
                    else Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
