using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.WEB.Comm.Tools.Log
{
    public interface IFMYLog
    {
        void Debug(string message);

        void Error(object obj);

        void Error(object obj, Exception ex);

        void Info(string message);
    }
}
