using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.RedisClient
{
    public class RedisConfig : ConfigurationSection
    {
        public static string WriteServerConStr
        {
            get
            {
                //return string.Format("{0}", "123@127.0.0.1:6379");
                return string.Format("{0}", "127.0.0.1:6379");
            }
        }
        public static string ReadServerConStr
        {
            get
            {
                return string.Format("{0},{1}", "127.0.0.1:6379", "127.0.0.1:6378");
                //return string.Format("{0},{1}", "123@127.0.0.1:6379", "123@127.0.0.1:6378");
            }
        }
        public static int MaxWritePoolSize
        {
            get
            {
                return 50;
            }
        }
        public static int MaxReadPoolSize
        {
            get
            {
                return 200;
            }
        }
        public static bool AutoStart
        {
            get
            {
                return true;
            }
        }
    }
}
