using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.BLL.Interface
{
    public interface IAccountLogic
    {
        void Add(Account account);

        bool CanRegister(string login);

        bool CanLogin(string login, string password);

        string GetUsersRole(string login);

        Account GetByID(int id);

        bool Contains(int id);

        bool ChangeRoleToAdmin(int id);

        bool ChangeRoleToUser(int id);
    }
}
