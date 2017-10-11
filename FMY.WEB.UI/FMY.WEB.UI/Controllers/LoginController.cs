using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FMY.WEB.UI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {            
            //Response.StatusCode = 403;
            throw new Exception("1");
            return View();
        }

    }
}
