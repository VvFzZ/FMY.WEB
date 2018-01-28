using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FMY.WEB.UI.Controllers
{
    public class HomeController : Controller
    {
        //protected override bool DisableAsyncSupport
        //{
        //    /*
        //     * 默认DisableAsyncSupport=false 为异步执行 BeginExecute/EndExecute 
        //     */
        //    get
        //    {
        //        return true;
        //    }
        //}

        public new HttpResponse Response
        {
            get { return System.Web.HttpContext.Current.Response; }
        }


        protected override void Execute(RequestContext requestContext)
        {
            

            Response.Write("Execute </br>");
            base.Execute(requestContext);
        }

        protected override void ExecuteCore()
        {
            Response.Write("ExecuteCore </br>");
            base.ExecuteCore();
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            Response.Write("BeginExecute </br>");
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            Response.Write("EndExecute </br>");
            base.EndExecute(asyncResult);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            Response.Write("BeginExecuteCore </br>");
            return base.BeginExecuteCore(callback, state);
        }

        protected override void EndExecuteCore(IAsyncResult asyncResult)
        {
            Response.Write("EndExecuteCore </br>");
            base.EndExecuteCore(asyncResult);
        }

        public ActionResult Index()
        {
            string output = "Home/Index </br>DisableAsyncSupport:{0}";
            string isDisableAsyncSupport = string.Empty;
            if (DisableAsyncSupport)
                isDisableAsyncSupport = "True";
            else
                isDisableAsyncSupport = "False";
            return Content(string.Format(output,isDisableAsyncSupport));
        }
    }

    public class AsyncHomeController : AsyncController
    {

    }
}