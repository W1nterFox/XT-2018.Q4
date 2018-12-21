using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task2.User;

namespace Epam.Task2.Employee
{
    public class Employee : User.User
    {
        private string position = string.Empty;
        private int workExperience;

        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        
        public Employee(string firstName, string lastName, string patronymic) : base(firstName, lastName, patronymic)
        {
        }
        
        public Employee(string firstName, string lastName, DateTime birthday) : base(firstName, lastName, birthday)
        {
        }
        
        public Employee(string firstName, string lastName, string patronymic, DateTime birthday) : base(firstName, lastName, patronymic, birthday)
        {
        }

        internal string Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (User.User.IsLetterString(value))
                {
                    this.position = value;
                }
                else
                {
                    throw new ArgumentException("Position must contain only letters");
                }
            }
        }

        internal int WorkExperience
        {
            get
            {
                return this.workExperience;
            }

            set
            {
                if (value > 0)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new ArgumentException("Work experience should have positive value");
                }
            }
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            if (this.Position != string.Empty)
            {
                Console.WriteLine("Position: {0}", this.Position);
            }
            else
            {
                Console.WriteLine("Position: No position");
            }

            Console.WriteLine("Work experience: {0}", this.WorkExperience);
        }
    }
}
