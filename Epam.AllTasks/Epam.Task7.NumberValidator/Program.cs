using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.NumberValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex commonNotation = new Regex(@"^(-|\+)?\d+(\.\d+)?$");
            Regex scienceNotation = new Regex(@"^(-|\+)?\d+\.\d+e(-|\+)?\d+$");

            Console.WriteLine("Please, type the string");
            string text = Console.ReadLine();
            Console.WriteLine();

            if (!string.IsNullOrEmpty(text))
            {
                MatchCollection matchesCommonNumber = commonNotation.Matches(text);
                MatchCollection matchesScienceNumber = scienceNotation.Matches(text);

                if (matchesCommonNumber.Count != 0)
                {
                    Console.WriteLine($"{text} is common number");
                }
                else
                if (matchesScienceNumber.Count != 0)
                {
                    Console.WriteLine($"{text} is science number");
                }
                else
                {
                    Console.WriteLine($"{text} isn't number");
                }
            }
            else
            {
                Console.WriteLine("You did not type the string");
            }
        }
    }
}
