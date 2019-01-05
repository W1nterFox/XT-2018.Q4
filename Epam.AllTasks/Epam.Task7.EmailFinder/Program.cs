using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.EmailFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex reg = new Regex(@"([^\W_]([\w-\.]*)[^\W_]|([^\W_]))@([^\W_]+\.)+\w{2,6}");

            string text = "aleks23041.-_996@gmail.com<h1>I like to read very much. aleks2304199_6@gmail.com Reading is my hobby. " +
                          "I have got a lot of books at home _aleks23041996@gmail.com. aleks23041996@gmail.com.yandexxxx.blabla.com " +
                          "I like to read books for children. aleks23041996@gm_ail.com" +
                          "I like to read short stories  about animals and fairy tales. " +
                          "My favourite fairy tale aleks23041996@gmail.com.yandexxxx is Cinderella.";

            MatchCollection matches = reg.Matches(text);
            Console.WriteLine("Text:");
            Console.WriteLine(text);

            Console.WriteLine();

            Console.WriteLine("E-mails: ");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

            Console.WriteLine();
        }
    }
}
