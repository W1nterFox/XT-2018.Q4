using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("{0} - {1}", i, IsSimpleNum(i));
            }
        }

        private static bool IsSimpleNum(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentException("Value of argument should be more than 0");
            }

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % 2 == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
