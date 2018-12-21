using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task4.ToIntOrNotToInt
{
    public static class MyParseToInt
    {
        private static char[] delimeters = new char[] { 'E', 'e' };

        public static bool MyParse(this string str)
        {
            char[] chars = str.ToCharArray();
            if (chars.Count(n => char.IsDigit(n)) == 0)
            {
                return false;
            }

            foreach (var ch in chars)
            {
                if (char.IsDigit(ch) || ch == ',' || ch == 'E' || ch == 'e' || ch == '+' || ch == '-')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            if (chars.Contains('E') || chars.Contains('e'))
            {
                return CheckExpIsInt(chars);
            }
            else if (chars.Count(n => n == ',') > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckExpIsInt(char[] chars)
        {
            if (!CheckIsCorrectExponentionalNumber(chars))
            {
                return false;
            }

            double resultNumber;
            try
            {
                string[] strings = (new string(chars)).Split(delimeters);

                double number = GetNumber(strings[0]);
                double exponent = StringToDouble(strings[1]);

                resultNumber = number * Math.Pow(10, exponent);
                if (resultNumber > -1 && resultNumber < 1 && resultNumber != 0)
                {
                    return false;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
            
            return true;
        }
        
        private static double GetNumber(string str)
        {
            char[] chars = str.ToCharArray();
            StringBuilder stringBuilderInteger = new StringBuilder();
            StringBuilder stringBuilderFraction = new StringBuilder();
            double integer = 0;
            double fraction = 0;

            int index = 0;
            
            try
            {
                while (index != chars.Length)
                {
                    if (chars[index] == ',' || chars[index] == '.')
                    {
                        break;
                    }

                    stringBuilderInteger.Append(chars[index]);
                    index++;
                }

                if (index != chars.Length && (chars[index] == ',' || chars[index] == '.'))
                {
                    index++;
                    while (index != chars.Length)
                    {
                        stringBuilderFraction.Append(chars[index]);
                        index++;
                    }
                }

                integer = StringToDouble(stringBuilderInteger.ToString());
                if (stringBuilderFraction.Length != 0)
                {
                    fraction = StringToDouble(stringBuilderFraction.ToString());

                    return CombineIntegerAndFraction(integer, fraction);
                }

                return integer;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return integer;
        }

        private static double CombineIntegerAndFraction(double first, double second)
        {
            int buf = (int)second;
            int legthOfNumber = 0;
            while (buf != 0)
            {
                buf /= 10;
                legthOfNumber++;
            }

            int power = -legthOfNumber;

            return first + (second * Math.Pow(10, power));
        }

        private static double StringToDouble(string str)
        {
            if (str == string.Empty)
            {
                return 0;
            }

            double result = 0;

            try
            {
                string stringWithoutPlusOrMinus = str.Replace("-", string.Empty).Replace("+", string.Empty);

                for (int i = 0; i < stringWithoutPlusOrMinus.Length; i++)
                {
                    int power = stringWithoutPlusOrMinus.Length - i - 1;
                    var numValue = (int)char.GetNumericValue(stringWithoutPlusOrMinus[i]);
                    result += numValue * Math.Pow(10, power);
                }

                if (str[0] == '-')
                {
                    result *= -1;
                }

                return result;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return result;
        }

        private static bool CheckIsCorrectExponentionalNumber(char[] chars)
        {
            string pattern = "^[-+]?[0-9]*[.,]?[0-9]+([eE][-+]?[0-9]+)?$";
            return Regex.IsMatch(new string(chars), pattern);
        }
    }
}
