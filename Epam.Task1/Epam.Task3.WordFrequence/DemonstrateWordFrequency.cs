using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.WordFrequence
{
    public class DemonstrateWordFrequency
    {
        public void DemonstrateStart()
        {
            int pickedElemMenu;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose menu element:");
                Console.WriteLine("1 - I want to input sentence by myself");
                Console.WriteLine("2 - I want to use sample sentence");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");

                while (!int.TryParse(Console.ReadLine(), out pickedElemMenu))
                {
                    Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                }

                switch (pickedElemMenu)
                {
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    case 1:
                        {
                            Console.Clear();
                            this.CreateWordFrequence(this.InputSentence());
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            this.CreateWordFrequence(this.UseSampleSentence());
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect value: valid values are 0, 1 and 2");
                            break;
                        }
                }

                Console.ReadKey();
            }
        }

        public void PrintDictionaryInfo(Dictionary<string, int> dictionary)
        {
            foreach (var keyValue in dictionary)
            {
                Console.WriteLine("{0} - {1} times", keyValue.Key, keyValue.Value);
            }
        }
        
        private void CreateWordFrequence(string str)
        {
            char[] splitChars = { ' ' };
            string[] strArr = str.Split(splitChars);

            this.StringsInArrayToOneSpecies(strArr);

            Dictionary<string, int> wordFrequence = this.CreateDictionary(strArr);

            this.PrintDictionaryInfo(wordFrequence);
        }

        private string InputSentence()
        {
            Console.WriteLine("Input sentence:");
            string str = Console.ReadLine();
            Console.WriteLine();
            return str;
        }

        private string UseSampleSentence()
        {
            string str = "My name is123 1` !@!#@#$ KA*te. My surname is Pavlova. " +  
                "I’m seven. I live in Minsk, in Pushkin street. I go to school number 214. " + 
                "I’m in the first form.";
            Console.WriteLine(str);
            Console.WriteLine();
            return str;
        }
        
        private Dictionary<string, int> CreateDictionary(string[] strArr)
        {
            Dictionary<string, int> wordFrequence = new Dictionary<string, int> { };

            try
            {
                foreach (var item in strArr)
                {
                    if (item != string.Empty)
                    {
                        if (wordFrequence.ContainsKey(item))
                        {
                            wordFrequence[item]++;
                        }
                        else
                        {
                            wordFrequence.Add(item, 1);
                        }
                    }
                }

                return wordFrequence;
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return wordFrequence;
        }

        private void StringsInArrayToOneSpecies(string[] strArr)
        {
            for (int i = 0; i < strArr.Length; i++)
            {
                strArr[i] = this.DeletePunctuation(strArr[i]);
                strArr[i] = this.SpellingAsInSentence(strArr[i]);
            }
        }

        private string SpellingAsInSentence(string str)
        {
            try
            {
                char[] buf = str.ToLower().ToCharArray();
                if (buf.Length != 0)
                {
                    buf[0] = char.ToUpper(buf[0]);
                    return new string(buf);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return string.Empty;
        }

        private string DeletePunctuation(string str)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    if (char.IsLetterOrDigit(str[i]))
                    {
                        sb.Append(str[i]);
                    }
                }

                return sb.ToString();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            return string.Empty;
        }
    }
}
