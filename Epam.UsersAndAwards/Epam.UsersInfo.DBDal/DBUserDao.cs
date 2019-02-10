using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.DAL.Interface;
using Epam.UsersInfo.Entities;

namespace Epam.UsersInfo.DBDal
{
    public class DBUserDao : IUserDao
    {
        private static string connectionStr;

        static DBUserDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                string[] parts = user.Name.Split('*');
                cmd.CommandText = "AddUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", parts[0]);
                cmd.Parameters.AddWithValue("@Surname", parts[1]);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.Birthday);

                if (parts[2] == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Patronymic", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patronymic", parts[2]);
                }

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool AddUserAward(int userID, int awardID)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "AddUsersAwards";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@AwardID", awardID);
                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch
                {
                    throw new InvalidOperationException("User already has the same award!");
                }
            }
        }

        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUsers";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idAccount = (int)reader["Id"];
                    string patronymic = reader["Patronymic"] is DBNull ? string.Empty : (string)reader["Patronymic"];
                    string name = $"{(string)reader["Name"]} {(string)reader["Surname"]} {patronymic}";
                    DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                    yield return new User { Name = name, Birthday = dateOfBirth, Id = idAccount };
                }
            }
        }

        public bool Update(int id, User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string[] parts = user.Name.Split('*');

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", parts[0]);
                cmd.Parameters.AddWithValue("@Surname", parts[1]);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.Birthday);

                if (parts[2] == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Patronymic", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Patronymic", parts[2]);
                }

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public User GetById(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserByIdFull";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                User user = null;

                while (reader.Read())
                {
                    int idAccount = (int)reader["Id"];
                    string patronymic = reader["Patronymic"] is DBNull ? string.Empty : (string)reader["Patronymic"];
                    string name = $"{(string)reader["Name"]} {(string)reader["Surname"]} {patronymic}";
                    DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                    user = new User
                    {
                        Name = name,
                        Birthday = dateOfBirth,
                        Id = idAccount
                    };
                }

                return user;
            }
        }

        public int[] GetUserAwardsIds(int idAccount)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                List<int> awardIDs = new List<int>();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserAwardsIds";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", idAccount);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    awardIDs.Add((int)reader["AwardID"]);
                }

                return awardIDs.ToArray();
            }
        }

        public bool Remove(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public bool RemoveFromUsersAwardsList(int id)
        {
            throw new NotImplementedException();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}
