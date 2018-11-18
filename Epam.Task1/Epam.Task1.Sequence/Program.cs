using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSequenceNums(10));
        }
        static string GetSequenceNums(int num)
        {
            if (num <= 0) throw new ArgumentException("Value of argument should be more than 0");
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= num; i++)
            {
                sb.Append(i);
                if (i != num) sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}
