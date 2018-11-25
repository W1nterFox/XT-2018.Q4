using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_4.X_Mas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите желаемую высоту ёлочки: ");
            int n;
            while (!Int32.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Введено некорректное значение, введите целое положительное число");
            }

            for (int i = 1; i < n+1; i++)
            {
                CreateBlock(i, n);
            }
        }
        public static void CreateBlock(int highOfBlock, int countLevel)
        {
            for (int i = 0; i < highOfBlock; i++)
            {
                for (int j = 1; j < countLevel - i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
