using System;
using FMY.WEB.Model;
using FMY.WEB.IbatisDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;

namespace FMY.WEB.UnitTest.IbatisDaoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //UserDao userDao = new UserDao();
            //userDao.GetDictionary<string, string>();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Config/log4net.xml";
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger("Debug").Error("Error");
        }
    }
}
