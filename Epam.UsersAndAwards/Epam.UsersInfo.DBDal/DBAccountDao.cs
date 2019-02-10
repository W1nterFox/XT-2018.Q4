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
    public class DBAccountDao : IAccountDao
    {
        private static string connectionStr;

        static DBAccountDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(Account account)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddAccount";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", account.Login);
                cmd.Parameters.AddWithValue("@Password", account.Password);
                cmd.Parameters.AddWithValue("@RoleId", account.Role);
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public void SetRole(int id)
        {
            throw new NotImplementedException();
        }

        public bool CanRegister(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAccountByLogin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return !reader.Read();
            }
        }

        public bool CheckUser(string login, string password)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAccountByLoginAndPassword";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);
                connection.Open();

                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
        }

        public string GetRole(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();
                string role = string.Empty;
                while (reader.Read())
                {
                    role = (string)reader["RoleName"];
                }

                return role;
            }
        }
        
        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAccountById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
                
        public bool ChangeRoleToAdmin(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ChangeAccountRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Account account = this.GetByID(id);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.Parameters.AddWithValue("@RoleId", 3);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ChangeRoleToUser(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ChangeAccountRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                Account account = this.GetByID(id);

                cmd.Parameters.AddWithValue("@Id", id);

                if (this.GetRole(account.Login).Equals("Admin"))
                {
                    int countAdmins = 0;
                    string[] allAccountsRoles = GetAllAccountsRoles().ToArray();
                    foreach (var item in allAccountsRoles)
                    {
                        if (countAdmins > 1)
                        {
                            break;
                        }
                            
                        if (item == "Admin")
                        {
                            countAdmins++;
                        }
                    }

                    if (countAdmins == 1)
                    {
                        throw new InvalidOperationException("Cannot change the last admin's role");
                    }
                }
                
                cmd.Parameters.AddWithValue("@RoleId", 4);
                
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Account GetByID(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAccountByIdFull";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Account account = null;

                while (reader.Read())
                {
                    int idAccount = (int)reader["ID"];
                    string login = (string)reader["Login"];
                    account = new Account(idAccount, login, this.GetRole(login));
                }

                return account;
            }
        }

        private static IEnumerable<string> GetAllAccountsRoles()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllAccountsRoles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = (string)reader["RoleName"];
                    yield return role;
                }
            }
        }
    }
}
