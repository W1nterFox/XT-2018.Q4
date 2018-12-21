using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_6.Font_adjustment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentStyles = TextStyles.None;
            while (true)
            {
                Console.WriteLine("Параметры надписи: " + currentStyles);
                Console.WriteLine("Введите: \n");
                
                Console.WriteLine("\t {0}: {1}\n", 1, TextStyles.Bold);
                Console.WriteLine("\t {0}: {1}\n", 2, TextStyles.Italic);
                Console.WriteLine("\t {0}: {1}\n", 3, TextStyles.Underline);
                
                int pickedOption;
                while (!int.TryParse(Console.ReadLine(), out pickedOption))
                {
                    Console.WriteLine("Введено некорректное значение, введите целое положительное число от 1 до 3");
                }

                switch (pickedOption)
                {
                    case 1:
                    {
                        if ((currentStyles & TextStyles.Bold) == 0)
                        {
                            currentStyles += (int)TextStyles.Bold;
                        }
                        else
                        {
                            currentStyles -= (int)TextStyles.Bold;
                        }

                        break;
                    }

                    case 2:
                    {
                        if ((currentStyles & TextStyles.Italic) == 0)
                        {
                            currentStyles += (int)TextStyles.Italic;
                        }
                        else
                        {
                            currentStyles -= (int)TextStyles.Italic;
                        }

                        break;
                    }

                    case 3:
                    {
                        if ((currentStyles & TextStyles.Underline) == 0)
                        {
                            currentStyles += (int)TextStyles.Underline;
                        }
                        else
                        {
                            currentStyles -= (int)TextStyles.Underline;
                        }

                        break;
                    }

                    default:
                        break;
                }                
            }            
        }
    }
}