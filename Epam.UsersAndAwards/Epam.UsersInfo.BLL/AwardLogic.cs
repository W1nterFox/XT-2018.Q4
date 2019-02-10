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
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao awardDao = DaoProvider.AwardDao;

        public Award[] GetAll()
        {
            return this.awardDao.GetAll().ToArray();
        }

        public Award[] GetAwardsByIds(int[] ids)
        {
            if (ids.Length == 0)
            {
                return new Award[0];
            }
            else
            {
                return this.awardDao.GetAwardsByIds(ids).ToArray();
            }
        }

        public Award GetById(int id)
        {
            return this.awardDao.GetById(id);
        }

        public bool Add(Award award)
        {
            if (award.Name.Contains('|'))
            {
                throw new ArgumentException("Name of award can`t contains symbol '|'");
            }

            return this.awardDao.Add(award);
        }

        public int GetMaxId()
        {
            return this.awardDao.GetMaxId();
        }

        public bool Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.awardDao.Contains(id))
            {
                throw new ArgumentException("Award with id " + id + " don`t exist");
            }

            return this.awardDao.Remove(id);
        }

        public bool Contains(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            return this.awardDao.Contains(id);
        }

        public bool Update(int id, Award award)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (award.Name.Contains('|'))
            {
                throw new ArgumentException("Name of award can`t contains symbol '|'");
            }

            return this.awardDao.Update(id, award);
        }

        public bool IsAwarded(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be more than 0");
            }

            if (!this.awardDao.Contains(id))
            {
                throw new ArgumentException("Award with id " + id + " don`t exist");
            }

            return this.awardDao.IsAwarded(id);
        }

        public bool DeleteCascade(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID can't be less than 1");
            }

            if (!this.awardDao.Contains(id))
            {
                throw new ArgumentException("Can't find award with such ID");
            }

            return this.awardDao.RemoveCascade(id);
        }
    }
}
