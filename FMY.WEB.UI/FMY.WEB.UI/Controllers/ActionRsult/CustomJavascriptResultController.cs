using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers.ActionRsult
{
    public class CustomJavascriptResultController : Controller
    {
        public ActionResult Javascript1()
        {
            return JavaScript("alert(''hello world)");
        }
    }
}