using System;
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
        public void GetDictionary()
        {
            try
            {
                UserDao userDao = new UserDao();
                IDictionary<string,string> dic= userDao.GetDictionary<string, string>();
            }
            catch (Exception ex)
            {

                throw;
            }
                         
        }
    }
}
