using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers
{
    public class LayUIAdminContorller : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/LayUI/LayuiAdmin.cshtml");
        }
    }
}