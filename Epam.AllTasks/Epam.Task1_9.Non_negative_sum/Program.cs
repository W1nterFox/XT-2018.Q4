using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_9.Non_negative_sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            Random r = new Random();

            Console.WriteLine("Массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-10, 10);
                Console.Write(array[i] + " ");
            }

            int sum = array.Sum(x => { return x > 0 ? x : 0; });
            Console.WriteLine("\nСумма положительных элементов массива: {0}", sum);
        }
    }
}
