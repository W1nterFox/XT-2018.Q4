using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.BLL.Interface
{
    public interface IAwardLogic
    {
        Award[] GetAll();

        Award[] GetAwardsByIds(int[] ids);

        Award GetById(int id);

        bool Add(Award award);

        int GetMaxId();

        bool Delete(int id);

        bool DeleteCascade(int id);

        bool Contains(int id);

        bool Update(int id, Award award);

        bool IsAwarded(int id);
    }
}
