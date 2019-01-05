using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.TimeCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex reg = new Regex(@"\b([01]?[0-9]|2[0-3]):([0-5][0-9])\b");

            string text = "I 17:55 like 27:55 to 7:75 read very much. Reading is my hobby. " +
                          "I 7:05 have 07:05 got 07:75 a 27:75 lot 27:05 of 7:00 books at home. ";

            MatchCollection matches = reg.Matches(text);

            Console.WriteLine($"{matches.Count} date's matches found in:");
            Console.WriteLine();
            Console.WriteLine(text);

            Console.WriteLine();
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

            Console.WriteLine();
        }
    }
}
