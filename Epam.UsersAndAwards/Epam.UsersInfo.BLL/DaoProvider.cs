using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.DAL;
using Epam.UsersInfo.DAL.Interface;
using Epam.UsersInfo.DBDal;

namespace Epam.UsersInfo.BLL
{
    public class DaoProvider
    {
        static DaoProvider()
        {
            if (ConfigurationManager.AppSettings["DaoMode"] == "File")
            {
                UserDao = new FileUserDao();
                AwardDao = new FileAwardDao();
            }

            if (ConfigurationManager.AppSettings["DaoMode"] == "DB")
            {
                UserDao = new DBUserDao();
                AwardDao = new DBAwardDao();
                AccountDao = new DBAccountDao();
            }
        }

        public static IUserDao UserDao { get; }

        public static IAwardDao AwardDao { get; }

        public static IAccountDao AccountDao { get; }
    }
}
