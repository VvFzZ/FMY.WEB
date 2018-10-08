using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.WEB.Comm.CookieSession
{
    public class CookieKeys
    {
        public static string LoginKey
        {
            get
            {
                return "55m75b2V";
            }
        }

        public static string GetValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
