using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_12.Char_doubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string str2 = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char ch in str1)
            {
                if (str2.Contains(ch))
                {
                    sb.Append(ch);
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(ch);
                }
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
