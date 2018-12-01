using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_10._2D_array
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            Random r = new Random();
            int sum = 0;
            Console.WriteLine("Массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(-10, 10);
                    Console.Write("{0,4}({1},{2}), ", array[i, j], i, j);
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Сумма чисел на четных позициях: {0}", sum);
        }
    }
}
