using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_8.No_positive
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32[,,] array = new Int32[3,3,3];
            Random r = new Random();
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i,j,k] = r.Next(-100, 100);
                        Console.Write("{0,4}({1},{2},{3}), ", array[i, j, k], i, j, k);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Измененный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                        Console.Write("{0,4}({1},{2},{3}), ", array[i, j, k], i, j, k);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }


        }
    }
}
