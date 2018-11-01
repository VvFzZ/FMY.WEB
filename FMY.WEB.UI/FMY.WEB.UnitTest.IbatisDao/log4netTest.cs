using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using log4net;

using FMY.WEB.Comm;
using FMY.WEB.Model;
using FMY.WEB.IbatisDao;

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

        [TestMethod]
        public void TestMethod2()
        {
            //string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Config/log4net.xml";
            //System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            //log4net.Config.XmlConfigurator.Configure(fileInfo);
            FMY.WEB.Comm.Tools.Log.IFMYLog loger = new FMY.WEB.Comm.Tools.Log.Log4FMYLog();
            loger.Error(DateTime.Now.ToString() + "Error");
        }

        [TestMethod]
        public void TestMethod3()
        {
            
           
        }
    }
}
