using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FMY.WEB.Model;
using FMY.WEB.IbatisDao;


namespace FMY.WEB.UnitTest.IbatisDaoTest
{
    [TestClass]
    public class UserDaoTest
    {

        [TestMethod]
        public void InsertUser()
        {
            User user = new User()
            {
                ActiveTime = DateTime.Now,
                CreateTime = DateTime.Now,
                Email = "1214211329@qq.com",
                Name = "T-FMY",
                PassWord = "123",
                Phone = "15832163021",
                Sex = 1,
                Status = false,
                UpdateTime = DateTime.Now
            };
            UserDao userDao = new UserDao();
            int result = userDao.AddUser(user);
        }


        [TestMethod]
        public void GetDictionary()
        {
            try
            {
                UserDao userDao = new UserDao();
                IDictionary<string, string> dic = userDao.GetDictionary<string, string>();
            }
            catch (Exception )
            {
                throw;
            }
        }


        [TestMethod]
        public void QueryNameLikeInjection()
        {
            UserDao userDao = new UserDao();
            try
            {
                string name = "tran";
                name = " Name LIKE '%%' AND  Name like '' ";
                name = " ' DELETE dbo.[User] -- ";//注入成功
                name = "T-";
                IList<User> userList = userDao.GetUserListByNameLike(name);
            }
            catch (Exception )
            {
                throw;
            }
        }


        [TestMethod]
        public void TestIbatis_isNotParameterPresent()
        {
            UserDao userDao = new UserDao();
            IList<User> users = userDao.GetUserListByDynamic(new Hashtable() { { "Id", null } });
            users = userDao.GetUserListByDynamic(null);
        }

    }
}
