using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_3.AnotherTriangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите желаемую высоту трегуольника: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Введено некорректное значение, введите целое положительное число");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n - i; j++)
                {
                    Console.Write(" ");
                }

                int countStarsInRow = (2 * i) + 1;
                for (int j = 0; j < countStarsInRow; j++)
                {
                    Console.Write("*");
                }
                
                Console.WriteLine();
            }
        }
    }
}
