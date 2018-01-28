using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FMY.WEB.UI.Controllers
{
    public class TestAsyncController : Controller
    {
        public Task<string> result1()
        {
            AsyncMethod();
            HttpContext.Response.Write("will return taskresult -------------");
            HttpContext.Response.Flush();
            return Task<string>.Factory.StartNew(() =>
            {
                HttpContext.Response.Write("                                     will sleep-----------------");


                HttpContext.Response.Flush();
                Thread.Sleep(5000);                
                HttpContext.Response.Write("                                    after sleep------------------");
                HttpContext.Response.Flush();
                
                return "sss";
            });
        }

        public async static void AsyncMethod()
        {
            await DoSomething();
            //System.Web.HttpContext.Current.Response.Write("AsyncMethod");
        }

        public static System.Threading.Tasks.Task DoSomething()
        {
            Thread.Sleep(2000);
           // System.Web.HttpContext.Current.Response.Write("DoSomething1");
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
               // System.Web.HttpContext.Current.Response.Write("DoSomething2");
            });
        }
    }
}