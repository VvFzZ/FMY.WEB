using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace FMY.WEB.UI
{
    /*filter 执行顺序  
     * 
     *      1.Controller自身 
     *      2.Gloable
     *      3.Conroller的AttributeFilter
     *      4.ActionFilter
     * 
     * 
     * 当AllowMultipe=false时 在全局,Class,Action上应用同一个Filter会执行一个（Action的Filter）
     */
    public class FilterBaseAttribute : FilterAttribute, IActionFilter
    {
        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }

    public class FooAttribute : FilterBaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
            
        {            
            HttpContext.Current.Response.Write("Class Foo");
        }
    }

    public class BarAttribute : FilterBaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Action Bar");
        }
    }

    public class BazAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContext.Current.Response.Write("Baz Executed");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Baz Executing");
        }
    }
}