using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
                Console.WriteLine("{0} - {1}", i, IsSimpleNum(i));
        }
        static bool IsSimpleNum(int num)
        {
            for (int i = 2; i <= num/2; i++)
            {
                if (num % 2 == 0) return false;
            }
            return true;
        }
    }
}
