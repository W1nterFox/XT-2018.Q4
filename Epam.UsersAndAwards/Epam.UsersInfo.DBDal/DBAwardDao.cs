using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private const int DefaultImageId = 1;

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
                cmd.Parameters.AddWithValue("@AwardImageId", DefaultImageId);

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
            var list = new List<Award> { };
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
                    int imageId = (int)reader["ImageID"];
                    list.Add(new Award { Name = title, Id = idAccount, ImageId = imageId });
                }

                return list;
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
                    int awardImageId = (int)reader["ImageId"];
                    award = new Award { Name = title, Id = idAccount, ImageId = awardImageId };
                }

                return award;
            }
        }

        public Award GetAwardByAwardTitle(string awardTitle)
        {
            Award award = new Award();
            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_GetAwardByTitle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardTitle", awardTitle);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    award.Id = (int)reader["Id"];
                    award.Name = (string)reader["Title"];
                    award.ImageId = (int)reader["ImageId"];
                }
            }

            if (award.Id == 0)
            {
                return null;
            }

            return award;
        }

        public Image GetAwardImageByAwardImageId(int awardImageId)
        {
            Image image = new Image();
            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImages_GetById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ImageId", awardImageId);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    image.ImageId = (int)reader["Id"];
                    image.MimeType = (string)reader["MimeType"];
                    image.ImageData = (string)reader["ImageData"];
                }
            }

            if (image.ImageId == 0)
            {
                return null;
            }

            return image;
        }

        public bool AddDefaultAwardImage(Image image)
        {
            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImage_AddDefault";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                cmd.Parameters.AddWithValue("@ImageData", image.ImageData);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public int AddAwardImage(Image image)
        {
            int imageId = 0;

            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImages_Add";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MimeType", image.MimeType);
                cmd.Parameters.AddWithValue("@ImageData", image.ImageData);
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                con.Open();

                cmd.ExecuteNonQuery();
                imageId = (int)cmd.Parameters["@Id"].Value;
            }

            return imageId;
        }

        public bool AddImageToAward(Image image, Award award)
        {
            int oldImageId = award.ImageId;
            bool result;
            int imageId = this.AddAwardImage(image);

            if (imageId == 0)
            {
                return false;
            }

            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Awards_AddImageToAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AwardId", award.Id);
                cmd.Parameters.AddWithValue("@ImageId", imageId);

                con.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }

            if (oldImageId != DefaultImageId)
            {
                this.RemoveImageFromDB(oldImageId);
            }

            return result;
        }

        private bool RemoveImageFromDB(int imageId)
        {
            using (var con = new SqlConnection(connectionStr))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "AwardsImages_RemoveImage";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ImageId", imageId);

                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
