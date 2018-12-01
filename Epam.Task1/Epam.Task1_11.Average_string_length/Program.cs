using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task1_11.Average_string_length
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetterOrDigit(str[i]) || char.IsWhiteSpace(str[i]))
                {
                    sb.Append(str[i]);
                }
            }

            string res = sb.ToString();
            double averageLength = res.Split(new char[] { ' ' }).Average(i => i.Length);
            Console.WriteLine();
            Console.WriteLine("Строка: {0}. \nСредняя длина слова: {1:#.###}", res, averageLength);
        }
    }
}
