using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FMY.WEB.Comm.Tools.ConfigTools
{
    public class WebConfigTool
    {
        public static string GetAppsetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
