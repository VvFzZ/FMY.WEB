using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;

namespace FMY.WEB.Comm.Tools.Log
{
    public class LogTool
    {
        private static ILog logger = null;

        static LogTool()
        {
            //log4net.Util.LogLog.InternalDebugging = true;//??
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Config/log4net.xml");
            FileInfo fileInfo = new FileInfo(fileName);
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }

        private LogTool() { }

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger("LogTool.Logger");
                }
                return logger;
            }
            private set { }
        }

    }
}

