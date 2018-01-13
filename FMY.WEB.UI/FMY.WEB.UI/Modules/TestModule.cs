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

        /// <summary>
        /// 没有订阅Application事件 最后加载
        /// 配置文件中需要把配置注册到system.webServer modules配置节点（IIS7集成模式） 
        /// 在system.web配置无效
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;            
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/1.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(DateTime.Now.ToString());
            }
        }
    }
}