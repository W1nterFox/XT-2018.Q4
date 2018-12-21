using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.User
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string patronymic;

        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = new DateTime(1900, 1, 1);
            this.CalculateAge();
        }

        public User(string firstName, string lastName, string patronymic) : this(firstName, lastName)
        {
            this.Patronymic = patronymic;
            this.CalculateAge();
        }

        public User(string firstName, string lastName, DateTime birthday) : this(firstName, lastName)
        {
            this.Birthday = birthday;
            this.CalculateAge();
        }

        public User(string firstName, string lastName, string patronymic, DateTime birthday) : this(firstName, lastName, patronymic)
        {
            this.Birthday = birthday;
            this.CalculateAge();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (IsLetterString(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name must contain only letters");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (IsLetterString(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name must contain only letters");
                }
            }
        }

        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }

            private set
            {
                if (IsLetterString(value))
                {
                    this.patronymic = value;
                }
                else
                {
                    throw new ArgumentException("Patronymic must contain only letters");
                }
            }
        }

        public DateTime Birthday { get; private set; }

        public int Age { get; private set; }
        
        public static bool IsLetterString(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine(
                "FirstName: {0}{1}LastName: {2}{1}Patronymic: {3}{1}Birthday: {4}{1}Age: {5}",
                this.FirstName,
                Environment.NewLine,
                this.LastName,
                this.Patronymic,
                this.Birthday,
                this.Age);
        }

        private void CalculateAge()
        {
            var today = DateTime.Today;
            this.Age = today.Year - this.Birthday.Year;
            if (this.Birthday > today.AddYears(-this.Age))
            {
                this.Age--;
            }
        }
    }
}
