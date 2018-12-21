using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_2.Triangle
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

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
