using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.DAL.Interface;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.DAL
{
    public class FileAwardDao : IAwardDao
    {
        private readonly string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "awards.txt");

        public bool Add(Award award)
        {
            award.Id = this.GetMaxId() + 1;
            File.AppendAllLines(this.fileName, new[] { $"{award.Id}|{award.Name}" });
            return true;
        }

        public IEnumerable<Award> GetAll()
        {
            if (!File.Exists(this.fileName) || File.ReadAllLines(this.fileName).Length == 0)
            {
                throw new InvalidOperationException("Not a single award has been created yet");
            }

            try
            {
                return File.ReadAllLines(this.fileName)
                    .Select(str => str.Split('|'))
                    .Select(arr => new Award()
                    {
                        Id = int.Parse(arr[0]),
                        Name = arr[1]
                    });
            }
            catch
            {
                throw new InvalidOperationException("Error during the creation of award");
            }
        }

        public IEnumerable<Award> GetAwardsByIds(int[] ids)
        {
            var awards = File.ReadAllLines(this.fileName);
            var appropriateAwards = new List<Award>();

            foreach (var award in awards)
            {
                var arr = award.Split('|');
                if (ids.Contains(int.Parse(arr[0])))
                {
                    appropriateAwards.Add(new Award { Id = int.Parse(arr[0]), Name = arr[1] });
                }
            }

            return appropriateAwards;
        }

        public int GetMaxId()
        {
            if (!File.Exists(this.fileName) || File.ReadAllLines(this.fileName).Length == 0)
            {
                return 0;
            }

            string maxId = File.ReadAllLines(this.fileName).Select(str => str.Split('|')[0]).Max();

            return int.Parse(maxId);
        }

        public bool Contains(int id)
        {
            return this.GetById(id) != null;
        }

        public bool Remove(int id)
        {
            var lines = File.ReadAllLines(this.fileName).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(this.fileName, lines.ToArray(), Encoding.Default);
            return true;
        }

        public Award GetById(int id)
        {
            return this.GetAll().FirstOrDefault(award => award.Id == id);
        }

        public bool Update(int id, Award award)
        {
            throw new NotImplementedException();
        }

        public bool IsAwarded(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCascade(int id)
        {
            throw new NotImplementedException();
        }
    }
}
