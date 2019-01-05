using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.HTMLReplacer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string reg = @"<.*?>";

            string text = "<html><h1>I like to read very much.</h1> Reading is my hobby. " +
                          "I have got a lot of books at home<hr/>. <b>2018-01-05</b> I like to read books for children. " +
                          "I like to read 05/01/2018short <div style=\"style1\">30-11-2018 stories 35-01-2018 about animals and fairy tales.</div> " +
                          "My favourite fairy05.01.2018 tale is Cinderella.</html>";
            Console.WriteLine("Text:");
            Console.WriteLine(text);

            text = Regex.Replace(text, reg, "_");
            Console.WriteLine();

            Console.WriteLine("Text without tegs:");
            Console.WriteLine(text);

            Console.WriteLine();
        }
    }
}
