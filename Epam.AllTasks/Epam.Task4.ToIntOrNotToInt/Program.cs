using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.ToIntOrNotToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var listStrings = new List<string>
            {
                "++",
                "-",
                "123",
                "-123",
                "1,2",
                "1,2E5",
                "+000,123e0",
                "+0",
                "-000,123E10",
                "-000,123E+10",
                "-0",
                "+0e2",
                "1E+2",
                "-1E-2",
                "1,10000E-100",
                ",04e-4",
                "12,e+0",
                "14,2e+",
                "14,e+0",
                "qwerty123",
                "123йцуккен",
                "-",
                "E",
                "-e"
            };

            foreach (var str in listStrings)
            {
                Console.WriteLine("{0} - {1}", str, str.MyParse());
            }
        }
    }
}
