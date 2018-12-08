using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Lost
{
    public class DemonstrateLost
    {
        public void StartDemonstrate()
        {
            LinkedList<Person> roundOfPerson = new LinkedList<Person> { };

            try
            {
                this.CreatePersons(roundOfPerson);
                this.DeleteEverySecondPerson(roundOfPerson);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
        }

        private void CreatePersons(LinkedList<Person> roundOfPerson)
        {
            int countOfPersons;
            Console.WriteLine("Input count of persons:");
            while (!int.TryParse(Console.ReadLine(), out countOfPersons) || countOfPersons <= 0)
            {
                Console.WriteLine("Incorrect value: valid values are positive numbers");
                Console.WriteLine("Input count of persons again:");
            }

            Person person;
            string nameOfPerson;
            for (int i = 0; i < countOfPersons; i++)
            {
                Console.WriteLine("Input name of {0} person:", i + 1);
                nameOfPerson = Console.ReadLine();
                person = new Person(nameOfPerson);
                roundOfPerson.AddLast(person);
                Console.WriteLine();
            }
        }

        private void DeleteEverySecondPerson(LinkedList<Person> roundOfPerson)
        {
            Console.WriteLine("First round.");
            while (roundOfPerson.Count != 1)
            {
                for (int i = 0; i < roundOfPerson.Count; i++)
                {
                    Console.WriteLine("Deleted person '{0}'", roundOfPerson.FindByIndex<Person>(i).Value.Name);
                    roundOfPerson.RemoveByIndex<Person>(i);
                }

                Console.WriteLine();
                Console.WriteLine("Next round.");
            }

            Console.WriteLine("Lost one Person! His name is '{0}'", roundOfPerson.First.Value.Name);
        }
    }
}
