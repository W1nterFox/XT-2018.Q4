﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.DAL.Interface
{
    public interface IAwardDao
    {
        bool Add(Award award);

        IEnumerable<Award> GetAll();

        IEnumerable<Award> GetAwardsByIds(int[] ids);

        int GetMaxId();

        bool Contains(int id);

        bool Remove(int id);

        Award GetById(int id);

        bool Update(int id, Award award);

        bool IsAwarded(int id);
    }
}