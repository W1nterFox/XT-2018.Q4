using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.NumberArraySum
{
    public static class NumericArrayExtension
    {
        public static byte MySum(this byte[] array)
        {
            byte result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static sbyte MySum(this sbyte[] array)
        {
            sbyte result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static char MySum(this char[] array)
        {
            char result = '\0';
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static int MySum(this int[] array)
        {
            int result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static uint MySum(this uint[] array)
        {
            uint result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static short MySum(this short[] array)
        {
            short result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static ushort MySum(this ushort[] array)
        {
            ushort result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static double MySum(this double[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static long MySum(this long[] array)
        {
            long result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static ulong MySum(this ulong[] array)
        {
            ulong result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }

        public static float MySum(this float[] array)
        {
            float result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }

            return result;
        }
    }
}
