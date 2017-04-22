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

        public DataTable GetAllUser()
        {
            UserDao userDao = new UserDao();
            string sql="SELECT * FROM dbo.[user]";
            return userDao.GetAllUser(sql);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sqlText">插入sql语句</param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            UserDao userDao = new UserDao();
            return userDao.AddUser(user);
        }
        public int GetUserCountByEmail(string email)
        {
            UserDao userDao = new UserDao();
            return userDao.GetUserCountByEmail(email);
        }
        public void TestExecProc1()
        {
            UserDao userDao = new UserDao();
            userDao.ExecProc("adduser", CommandType.StoredProcedure);
        }
    }
}
