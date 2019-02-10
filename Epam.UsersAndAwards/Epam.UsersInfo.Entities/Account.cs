using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.Entities
{
    public class Account
    {
        public Account(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public Account(int id, string login, string role)
        {
            this.Login = login;
            this.Role = role;
            this.Id = id;
        }

        public Account(string login, string password, string role)
        {
            this.Login = login;
            this.Password = password;
            this.Role = role;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
