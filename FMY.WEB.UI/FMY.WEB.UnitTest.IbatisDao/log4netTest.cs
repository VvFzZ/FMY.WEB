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
            //http://www.cnblogs.com/xiekeli/p/4611113.html
            //http://www.cnblogs.com/kissazi2/p/3392605.html
            //http://www.cnblogs.com/lzrabbit/archive/2012/03/23/2413180.html
            //http://blog.csdn.net/zhoufoxcn/article/details/6029021
            //UserDao userDao = new UserDao();
            //userDao.GetDictionary<string, string>();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Config/log4net.xml";
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            log4net.Config.XmlConfigurator.Configure(fileInfo);
            //Log4Mongo2.2 与log4net2.0.8不兼容 与1.2.11兼容
            LogManager.GetLogger("Debug").Error("TestmongoErr_log4net1.2.11.0**3");
        }
    }
}
