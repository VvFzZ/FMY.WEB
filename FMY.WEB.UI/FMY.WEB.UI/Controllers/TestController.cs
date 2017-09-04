using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMY.WEB.BLL;
using System.Web.Security;
using FMY.WEB.Comm.Tools.ConfigTools;

namespace FMY.WEB.UI.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
           string str= WebConfigTool.GetRobsunPara();
            return View();
        }
    }
}
