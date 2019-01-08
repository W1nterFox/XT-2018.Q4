using System.Collections.Generic;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.DAL.Interface
{
    public interface IUserDao
    {
        bool Add(User user);

        IEnumerable<User> GetAll();

        User GetById(int id);

        bool Remove(int id);

        bool RemoveFromUsersAwardsList(int id);

        bool Contains(int id);

        bool Update(int id, User user);

        int GetMaxId();

        int[] GetUserAwardsIds(int id);

        bool AddUserAward(int userId, int awardId);
    }
}
