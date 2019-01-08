using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.BLL.Interface
{
    public interface IUserLogic
    {
        User[] GetAll();

        User GetById(int id);

        bool Add(User user);

        bool Delete(int id);

        bool DeleteFromUsersAwardsList(int id);

        bool Contains(int id);

        bool Update(int id, User user);

        int GetMaxId();

        bool AddAwardToUser(int userId, int awardId);

        int[] GetUserAwardsIds(int id);
    }
}
