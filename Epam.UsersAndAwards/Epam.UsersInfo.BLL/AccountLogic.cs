using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.BLL.Interface;
using Epam.UsersInfo.DAL.Interface;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountDao accountDao;

        public AccountLogic()
        {
            this.accountDao = DaoProvider.AccountDao;
        }

        public void Add(Account account)
        {
            account.Password = GetPasswordsHash(account.Password);
            this.accountDao.Add(account);
        }

        public bool CanRegister(string login)
        {
            return this.accountDao.CanRegister(login);
        }

        public bool CanLogin(string login, string password)
        {
            return this.accountDao.CheckUser(login, GetPasswordsHash(password));
        }

        public string GetUsersRole(string login)
        {
            return this.accountDao.GetRole(login);
        }
        
        public Account GetByID(int id)
        {
            return this.accountDao.GetByID(id);
        }

        public bool Contains(int id)
        {
            return this.accountDao.Contains(id);
        }

        public bool ChangeRoleToAdmin(int id)
        {
            return this.accountDao.ChangeRoleToAdmin(id);
        }

        public bool ChangeRoleToUser(int id)
        {
            return this.accountDao.ChangeRoleToUser(id);
        }
        
        private static string GetPasswordsHash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }

                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
