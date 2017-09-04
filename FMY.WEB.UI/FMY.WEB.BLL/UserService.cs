using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WEB.Model;
using FMY.WEB.DAL;
using System.Data.SqlClient;
using System.Data;

namespace FMY.WEB.BLL
{

    public class UserService
    {
        UserDao userDao;

        public UserService()
        {
            userDao = new UserDao();
        }

        public DataTable GetAllUser()
        {
            string sql = "SELECT * FROM dbo.[user]";
            return userDao.GetAllUser(sql);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sqlText">插入sql语句</param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            return userDao.AddUser(user);
        }

        public int GetUserCountByEmail(string email)
        {
            return userDao.GetUserCountByEmail(email);
        }

        public void TestExecProc1()
        {
            userDao.ExecProc("adduser", CommandType.StoredProcedure);
        }
    }
}
