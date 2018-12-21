using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.NumberArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arrayOfInt = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfInt.MySum());

            uint[] arrayOfUint = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfUint.MySum());

            short[] arrayOfShort = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfShort.MySum());

            ushort[] arrayOfUshort = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfUshort.MySum());

            byte[] arrayOfByte = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfByte.MySum());

            sbyte[] arrayOfSbyte = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfSbyte.MySum());

            long[] arrayOfLong = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfLong.MySum());

            ulong[] arrayOfUlong = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfUlong.MySum());

            double[] arrayOfDouble = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfDouble.MySum());

            float[] arrayOfFloat = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayOfFloat.MySum());

            char[] arrayOfChar = { 'a', 'b', 'c', 'd', 'e' };
            Console.WriteLine((int)arrayOfChar.MySum());
        }
    }
}