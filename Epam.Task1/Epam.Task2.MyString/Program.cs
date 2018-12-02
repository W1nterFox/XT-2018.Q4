using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.MyString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////Тут тестил методы. 
            ////В задании не написано, что нужно написать программу, которая демонстрировала бы использование класса MyString, поэтому тут немного
            MyString myString = new MyString(new char[] { 'H', 'e', 'l', 'l', 'o' });
            MyString myString1 = "Hello";
            MyString myString2 = "Hello";
            Console.WriteLine(myString1.Insert("abc", 5));
            Console.WriteLine(myString1.Insert("abc", 3));
            Console.WriteLine(myString1.Insert("abc", 2));
            Console.WriteLine(myString1.Insert("abc", 1));
            Console.WriteLine(myString1.Insert("abc", 0));
            Console.WriteLine(myString1.Insert("abcccccccccccccccccccccccc", 4));
            Console.WriteLine(myString1.Insert(string.Empty, 4));
        }
    }
}
