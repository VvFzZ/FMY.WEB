using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers
{
    [CustomAuhtorize]
    [Foo]
    public class FilterSequenceController : Controller
    {
        public ActionResult Index()
        {
            //ReflectedControllerDescriptor controllerDescripter = new ReflectedControllerDescriptor(typeof(FilterSequenceController));
            //ActionDescriptor actionDescriptor = controllerDescripter.FindAction(ControllerContext, "DemoAction");
            //IEnumerable<Filter> filters = FilterProviders.Providers.GetFilters(ControllerContext, actionDescriptor);
            //foreach (var item in filters)
            //{
            //    Response.Write(string.Format("Instance.GetType:{0}, Order:{1}, Scope{2}    ----------------------------------------------------"
            //        , item.Instance.GetType(), item.Order, item.Scope));

            //}
            return null;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Response.Write("Controller Override");
        }

        [Bar]
        public ActionResult DemoAction()
        {
            return null;
        }
    }
}