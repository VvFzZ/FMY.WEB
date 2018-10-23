using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers
{
    public class ValidateAntiForgeryTestController:Controller
    {        
        public ActionResult Index()
        {
            return View("~/Views/Test/ValidateAntiForgery.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public JsonResult PostSomeThing()
        {
            return null;
        }

    }
}