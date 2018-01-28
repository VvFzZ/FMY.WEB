using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace FMY.WEB.UI.Controllers
{
    public class Home2Controller : Controller
    {
        public ActionResult Index()
        {
            /*
             * ContorllerActionInvoker 的 InvokeActionMethod方法
             *    1调用 actionDescripor的Excute()方法返回 参数(object)actionReturnValue
             *    2调用 CreateActionResult(actionReturnValue)
             *                                                  
             */
            Dictionary<ActionDescriptor, ActionResult> actionResults = new Dictionary<ActionDescriptor, ActionResult>();

            MethodInfo getConrollerDescripter =
                this.ActionInvoker.GetType().GetMethod("GetControllerDescriptor", BindingFlags.Instance | BindingFlags.NonPublic);

            ControllerDescriptor controllerDescriptor =
                (ControllerDescriptor)getConrollerDescripter.Invoke(this.ActionInvoker, new object[] { ControllerContext });

            MethodInfo invokeActionMethod =
                this.ActionInvoker.GetType().GetMethod("InvokeActionMethod", BindingFlags.Instance | BindingFlags.NonPublic);

            string[] actions = new string[] { "Foo", "Bar", "Baz", "Qux" };

            Array.ForEach(actions, action =>
            {
                ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(ControllerContext, action);
                ActionResult actionResult = (ActionResult)invokeActionMethod.Invoke(this.ActionInvoker, new object[] { ControllerContext, actionDescriptor, new Dictionary<string, object>() });
                actionResults.Add(actionDescriptor, actionResult);
            });

            return View("~/Views/ActoinResult/HomeIndex.cshtml",actionResults);

        }

        public ActionResult Foo()
        {
            return new RedirectResult("http://www.baidu.com");
        }

        public void Bar()
        {

        }

        public ActionResult Baz()
        {
            return null;
        }

        public double Qux()
        {
            return 1.00;
        }

    }
}