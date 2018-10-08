using System.Data;
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
            userDao = new IbatisDao.UserDao();  //new UserDao();
        }

        //public UserService()
        //{

        //}

        public UserService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public DataTable GetAllUser()
        {
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

        public bool CheckUser(string name, string pwd)
        {
            return true;
        }

        //public void TestExecProc()
        //{
        //    userDao.ExecProc("adduser", CommandType.StoredProcedure);
        //}

    }
}
