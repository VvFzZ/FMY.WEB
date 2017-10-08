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


        public static string GetRobsunPara()
        {
            RobsunPara para = ConfigurationManager.GetSection("robsunGroup/robsunSection") as RobsunPara;
            return string.Format("CompanyName:{0},Path:{1},isPrivate:{2}", para.CompanyName, para.Path, para.IsPrivate);
        }
    }
}
