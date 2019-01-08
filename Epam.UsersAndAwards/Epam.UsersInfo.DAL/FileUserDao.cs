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
    public class FileUserDao : IUserDao
    {
        private const string DateFormat = "dd.MM.yyyy";
        private readonly string fileUsers = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.txt");
        private readonly string fileUsersAwards = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usersAwardsList.txt");

        public bool Add(User user)
        {
            user.Id = this.GetMaxId() + 1;
            string birthday = string.Format("{0:dd.MM.yyyy}", user.Birthday);
            File.AppendAllLines(this.fileUsers, new[] { $"{user.Id}|{user.Name}|{birthday}" });

            return true;
        }

        public int GetMaxId()
        {
            if (!File.Exists(this.fileUsers) || File.ReadAllLines(this.fileUsers).Length == 0)
            {
                return 0;
            }

            string maxId = File.ReadAllLines(this.fileUsers).Select(str => str.Split('|')[0]).Max();

            return int.Parse(maxId);
        }

        public int[] GetUserAwardsIds(int id)
        {
            if (!File.Exists(this.fileUsersAwards))
            {
                File.Create(this.fileUsersAwards).Close();
            }

            using (StreamReader sr = new StreamReader(this.fileUsersAwards, Encoding.Default))
            {
                string temp;
                List<int> userAwardsIds = new List<int>();

                while ((temp = sr.ReadLine()) != null)
                {
                    string[] arr = temp.Split('|');
                    if (arr[0] == id.ToString())
                    {
                        foreach (var awardId in arr[1].Split(' '))
                        {
                            userAwardsIds.Add(int.Parse(awardId));
                        }

                        return userAwardsIds.ToArray();
                    }
                }

                return userAwardsIds.ToArray();
            }
        }

        public bool AddUserAward(int userId, int awardId)
        {
            if (!File.Exists(this.fileUsersAwards))
            {
                File.WriteAllLines(this.fileUsersAwards, new[] { $"{userId}|{awardId}" });
            }
            else
            {
                var lines = File.ReadAllLines(this.fileUsersAwards).ToArray();

                for (int i = 0; i < lines.Length; i++)
                {
                    var bufArr = lines[i].Split('|');
                    if (bufArr[0] == userId.ToString())
                    {
                        foreach (var userAwardId in bufArr[1].Split(' '))
                        {
                            if (userAwardId == awardId.ToString())
                            {
                                throw new ArgumentException("User already has this award");
                            }
                        }

                        lines[i] = $"{lines[i]} {awardId}";
                        File.WriteAllLines(this.fileUsersAwards, lines.ToArray(), Encoding.Default);
                        return true;
                    }
                }

                File.AppendAllLines(this.fileUsersAwards, new[] { $"{userId}|{awardId}" });
            }

            return true;
        }
        
        public IEnumerable<User> GetAll()
        {
            if (!File.Exists(this.fileUsers) || File.ReadAllLines(this.fileUsers).Length == 0)
            {
                throw new InvalidOperationException("Not a single person has been created yet");
            }

            try
            {
                return File.ReadAllLines(this.fileUsers)
                    .Select(str => str.Split('|'))
                    .Select(arr => new User
                    {
                        Id = int.Parse(arr[0]),
                        Name = arr[1],
                        Birthday = DateTime.ParseExact(arr[2], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)
                    });
            }
            catch
            {
                throw new InvalidOperationException("Error during the creation of person");
            }
        }

        public User GetById(int id)
        {
            return this.GetAll().FirstOrDefault(user => user.Id == id);
        }

        public bool Contains(int id)
        {
            return this.GetById(id) != null;
        }

        public bool Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            var lines = File.ReadAllLines(this.fileUsers).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            
            File.WriteAllLines(this.fileUsers, lines.ToArray(), Encoding.Default);
            return true;
        }

        public bool RemoveFromUsersAwardsList(int id)
        {
            var lines = File.ReadAllLines(this.fileUsersAwards).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(this.fileUsersAwards, lines.ToArray(), Encoding.Default);
            return true;
        }
    }
}
