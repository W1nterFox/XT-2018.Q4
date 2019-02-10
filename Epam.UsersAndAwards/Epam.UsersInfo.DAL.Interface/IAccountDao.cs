using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.DAL.Interface
{
    public interface IAccountDao
    {
        bool Add(Account account);

        void SetRole(int id);

        bool CanRegister(string login);

        bool CheckUser(string login, string password);

        string GetRole(string login);

        Account GetByID(int id);

        bool Contains(int id);

        bool ChangeRoleToAdmin(int id);

        bool ChangeRoleToUser(int id);
    }
}
