using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.CustomSortDemo
{
    public class CustomSortDemoDemonstration
    {
        public void CustomSortDemoDemonstrate()
        {
            string[] strings =
            {
                "Holla",
                "Hello",
                "Epam",
                "VeryLongWord",
                "Task"
            };

            Console.WriteLine("Initial array of strings:");
            this.PrintStrings(strings);
            Console.WriteLine();

            this.CustomSort<string>(strings, this.CompareStrings);
            this.PrintStrings(strings);
        }
        
        public void PrintStrings(string[] array)
        {
            foreach (var str in array)
            {
                Console.WriteLine(str);
            }
        }

        public int CompareStrings(string first, string second)
        {
            if (ReferenceEquals(first, second))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(first) || string.IsNullOrWhiteSpace(first))
            {
                return -1;
            }

            if (string.IsNullOrEmpty(second) || string.IsNullOrWhiteSpace(second))
            {
                return 1;
            }

            int minLengthOfWord;

            if (first.Length < second.Length)
            {
                minLengthOfWord = first.Length;
            }
            else
            {
                minLengthOfWord = second.Length;
            }

            for (int i = 0; i < minLengthOfWord; i++)
            {
                if (first[i] < second[i])
                {
                    return -1;
                }

                if (first[i] > second[i])
                {
                    return 1;
                }
            }

            if (first.Length > second.Length)
            {
                return 1;
            }
            else if (first.Length < second.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
        private void CustomSort<T>(T[] array, Func<T, T, int> methodCompare)
        {
            ////Shell sorting
            int step = array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < array.Length; i++)
                {
                    T value = array[i];
                    for (j = i - step; (j >= 0) && (methodCompare(array[j], value) == 1); j -= step)
                    {
                        array[j + step] = array[j];
                    }

                    array[j + step] = value;
                }

                step /= 2;
            }
        }
    }
}
