using System;

namespace Epam.UsersInfo.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.Birthday.Year;
                if (this.Birthday > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
