using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FMY.WEB.UI.Modules
{
    public class TestModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/1.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(DateTime.Now.ToString());
            }
        }
    }
}