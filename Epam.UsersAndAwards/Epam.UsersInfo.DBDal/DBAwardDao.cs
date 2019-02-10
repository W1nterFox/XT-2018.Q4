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
    public class DBAwardDao : IAwardDao
    {
        private static string connectionStr;

        static DBAwardDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(Award award)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", award.Name);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAwardById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public bool IsAwarded(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUsersAwardsByAwardId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAwards";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idAccount = (int)reader["Id"];
                    string title = (string)reader["Title"];
                    yield return new Award { Name = title, Id = idAccount };
                }
            }
        }

        public bool Update(int id, Award award)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Title", award.Name);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        
        public bool Remove(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public bool RemoveCascade(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveAwardCascade";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardsByIds(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                yield return this.GetById(ids[i]);
            }
        }

        public Award GetById(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAwardByIdFull";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Award award = null;

                while (reader.Read())
                {
                    int idAccount = (int)reader["Id"];
                    string title = (string)reader["Title"];
                    award = new Award { Name = title, Id = idAccount };
                }

                return award;
            }
        }
    }
}
