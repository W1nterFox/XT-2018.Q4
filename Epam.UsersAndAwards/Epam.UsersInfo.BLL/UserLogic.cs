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
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao = DaoProvider.UserDao;
        private IAwardDao awardDao = DaoProvider.AwardDao;

        public User[] GetAll()
        {
            return this.userDao.GetAll().ToArray();
        }

        public User GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.userDao.Contains(id))
            {
                throw new ArgumentException("User with id " + id + " don`t exist");
            }

            return this.userDao.GetById(id);
        }

        public bool Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.userDao.Contains(id))
            {
                throw new ArgumentException("User with id " + id + " don`t exist");
            }

            return this.userDao.Remove(id);
        }

        public bool DeleteFromUsersAwardsList(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }
            
            return this.userDao.RemoveFromUsersAwardsList(id);
        }

        public bool Contains(int id)
        {
            return this.userDao.Contains(id);
        }

        public bool Update(int id, User user)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.userDao.Contains(id))
            {
                throw new ArgumentException("User with id " + id + " don`t exist");
            }

            if (user.Name.Contains('|'))
            {
                throw new ArgumentException("Name of user can`t contains '|'");
            }

            if (user.Birthday > DateTime.Today)
            {
                throw new ArgumentException("Birthday of user must be earlier than today");
            }

            if (user.Age > 135)
            {
                throw new ArgumentException("Age of user must be less than 135");
            }

            return this.userDao.Update(id, user);
        }

        public int GetMaxId()
        {
            return this.userDao.GetMaxId();
        }

        public bool AddAwardToUser(int userId, int awardId)
        {
            if (userId < 1 || awardId < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.userDao.Contains(userId))
            {
                throw new ArgumentException("User with id " + userId + " don`t exist");
            }

            if (!this.awardDao.Contains(awardId))
            {
                throw new ArgumentException("Award with id " + awardId + " don`t exist");
            }

            return this.userDao.AddUserAward(userId, awardId);
        }

        public int[] GetUserAwardsIds(int id)
        {
            return this.userDao.GetUserAwardsIds(id);
        }

        public bool Add(User user)
        {
            if (user.Name.Contains('|'))
            {
                throw new ArgumentException("Name of user can`t contains '|'");
            }

            if (user.Birthday > DateTime.Today)
            {
                throw new ArgumentException("Birthday of user must be earlier than today");
            }

            if (user.Age > 135)
            {
                throw new ArgumentException("Age of user must be less than 135");
            }

            return this.userDao.Add(user);
        }
    }
}
