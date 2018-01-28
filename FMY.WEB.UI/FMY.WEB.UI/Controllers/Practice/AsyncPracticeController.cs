using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace FMY.WEB.UI.Controllers.Practice
{
    public class AsyncPracticeController : AsyncController//Controller
    {

        public void Article1Async()
        {
            AsyncManager.OutstandingOperations.Increment();
            Task.Factory.StartNew(() =>
            {
                string content = "content";
                Response.Write("ArtcleAsync");
                AsyncManager.Parameters["content"] = content;
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ActionResult Article1Completed(string content)
        {
            Response.Write("Completed");
            return Content(content);
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult> Article()
        {
            Response.Write("Article");
            
            return Task.Factory.StartNew(() =>
            {
                Response.Write(",Sleep Start");
                Response.Flush();
                Thread.Sleep(10000);
                
                Response.Write(",Sleep End");
                AsyncManager.Parameters["content"] = "content";

            }).ContinueWith<ActionResult>(task =>
            {
                string content=(string) AsyncManager.Parameters["content"];
                return Content(content);
            });
        }
    }
}