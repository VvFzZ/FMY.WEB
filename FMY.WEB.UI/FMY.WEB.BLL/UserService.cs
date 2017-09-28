﻿using System.Data;
using FMY.WEB.Model;
using FMY.WEB.Dao;
using FMY.WEB.IDao;

namespace FMY.WEB.BLL
{

    public class UserService
    {

        IUserDao userDao;


        public UserService()
        {
            //需要解耦
            userDao = new UserDao();
        }


        public DataTable GetAllUser()
        {
            //不要写sql语句
            return userDao.GetAllUser();
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


        //public void TestExecProc()
        //{
        //    userDao.ExecProc("adduser", CommandType.StoredProcedure);
        //}

    }
}
