using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Lost;

namespace Epam.Task3.DynamicArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DynamicArray<Person> dynamicArrayString = new DynamicArray<Person> { };
            List<Person> listString = new List<Person>
            {
                new Person("Person0"),
                new Person("Person1"),
                new Person("Person2"),
                new Person("Person3"),
                new Person("Person4"),
                new Person("Person5")
            };
            Console.WriteLine("DynamicArrayString: ");
            Console.WriteLine("Explicit initialization");
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method Add");
            Person personInit = new Person("PersonInit");
            dynamicArrayString.Add(personInit);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method AddRange");
            dynamicArrayString.AddRange(listString);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Change capacity to 100");
            dynamicArrayString.Capacity = 100;
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Change capacity to 6");
            dynamicArrayString.Capacity = 6;
            PrintInfo(dynamicArrayString);
            
            Console.WriteLine("Item access via negative index");
            Console.WriteLine(dynamicArrayString[-1]);
            Console.WriteLine(dynamicArrayString[-2]);
            Console.WriteLine(dynamicArrayString[-3]);
            Console.WriteLine(dynamicArrayString[-4]);
            Console.WriteLine(dynamicArrayString[-5]);
            Console.WriteLine(dynamicArrayString[-6]);
            Console.WriteLine();

            Console.WriteLine("Method AddRange again");
            dynamicArrayString.AddRange(listString);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method RemoveAt (Remove by index '3')");
            dynamicArrayString.RemoveAt(3);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method Remove (Remove by value)");
            dynamicArrayString.Remove(personInit);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method Insert to the end");
            dynamicArrayString.Insert(new Person("NewPerson"), dynamicArrayString.Length);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method Insert to the index '4'");
            dynamicArrayString.Insert(new Person("NewPerson"), 4);
            PrintInfo(dynamicArrayString);

            Console.WriteLine("Method ToArray");
            Person[] perArr = dynamicArrayString.ToArray();
            Console.WriteLine("Dynamic array to simple array");
            foreach (var elem in perArr)
            {
                Console.WriteLine(elem.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Method Clone ");
            DynamicArray<Person> second = (DynamicArray<Person>)dynamicArrayString.Clone();
            second.Insert(new Person("Kate"), 5);
            Console.WriteLine("Initial array: ");
            PrintInfo(dynamicArrayString);
            Console.WriteLine("Clone + new Person 'Kate' to index '5' ");
            PrintInfo(second);
        }
        
        public static void PrintInfo<Person>(DynamicArray<Person> dynamicArray)
        {
            Console.WriteLine("Capacity: {0}", dynamicArray.Capacity);
            Console.WriteLine("Length: {0}", dynamicArray.Length);
            foreach (Person elem in dynamicArray)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine();
        }
    }
}
