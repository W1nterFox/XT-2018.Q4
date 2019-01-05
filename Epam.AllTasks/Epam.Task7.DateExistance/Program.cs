using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.DateExistance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex reg = new Regex(@"(((0[1-9]|[12][0-9]|31)-(0[13578]|1[0|2]))|((0[1-9]|[12][0-9]|30)-(0[2469]|11)))-(\d{4})");

            string text = "05-01-2018I like to read very much. Reading is my hobby. " +
                          "I have got a lot of books at home. 2018-01-05 I like to read books for children. " +
                          "I like to read 05/01/2018short 30-11-2018 stories 35-01-2018 about animals and fairy tales. " +
                          "My favourite fairy05.01.2018 tale is Cinderella.";

            MatchCollection matches = reg.Matches(text);
            
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("Founded matches:");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Date: {match}");
            }

            Console.WriteLine();
        }
    }
}
