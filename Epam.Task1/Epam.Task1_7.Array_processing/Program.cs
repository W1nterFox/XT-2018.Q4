using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_7.Array_processing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            Random r = new Random();

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-100, 100);
                Console.Write(array[i] + " ");
            }
            
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Отсортированный массив: ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Минимум: {0}\nМаксимум: {1}\n", array[0], array[array.Length - 1]);
        }
    }
}
