using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.WEB.Comm.Tools.Log
{
    public class Log4FMYLog : IFMYLog
    {

        public void Debug(string message)
        {
            LogTool.Logger.Debug(message);
        }

        public void Error(string message)
        {
            LogTool.Logger.Error(message);
        }

        public void Info(string message)
        {
            LogTool.Logger.Info(message);
        }

    }
}
