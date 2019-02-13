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
        private const int DefaultImageId = 1;

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

            if (this.awardDao.GetAwardByAwardTitle(award.Name) != null)
            {
                throw new ArgumentException("Award with Name '" + award.Name + "' already exist");
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

            var buf = this.awardDao.GetAwardByAwardTitle(award.Name);

            if (buf != null && buf.Id != id)
            {
                throw new ArgumentException("Award with Name '" + award.Name + "' already exist");
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

        public bool AddImageToAward(Image image, string awardTitle)
        {
            Award award = this.awardDao.GetAwardByAwardTitle(awardTitle);

            if (award != null)
            {
                return this.awardDao.AddImageToAward(image, award);
            }
            else
            {
                return false;
            }
        }

        public bool AddDefaultAwardImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Image GetAwardImageByAwardImageId(int awardImageId)
        {
            Image image = null;
            image = this.awardDao.GetAwardImageByAwardImageId(awardImageId);
            if (image == null)
            {
                image = this.awardDao.GetAwardImageByAwardImageId(DefaultImageId);
            }

            return image;
        }
    }
}
