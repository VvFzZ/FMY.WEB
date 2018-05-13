using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using FMY.WEB.Model;

namespace FMY.WEB.UI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            //Response.StatusCode = 403;
            //throw new Exception("1");
            return View();
        }

        [HttpPost]
        public JsonResult Login(string name, string pwd)
        {
            Session["FMY"] = name;
            return Json(new Result(true));
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Session["FMY"] = null;
            return Json(new Result(true));
        }

    }
}
