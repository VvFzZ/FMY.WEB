using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers.ViewResult
{
    public class ViewEngineController : Controller
    {
        public void Index()
        {
            //ViewEngines.Engines 全局ViewEngines列表
            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, "NotContainView", null);
            foreach (var item in result.SearchedLocations)
            {
                Response.Write(item+"<br/>");
            }
            Response.Flush();
            Response.End();
            //
            ///IViewEngine
        }

        public ActionResult ShowNotExistsView()
        {
            return View("NotExistsView");
        }

        public ActionResult ShowStaticFileView()
        {
            return View();
        }
    }
}