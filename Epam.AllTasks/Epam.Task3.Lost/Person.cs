using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Lost
{
    public class Person
    {
        public Person()
        {
            this.Name = string.Empty;
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
