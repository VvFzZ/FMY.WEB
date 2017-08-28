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
            var expiration = DateTime.Now.Add(new TimeSpan(8, 0, 0));
            FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(1, "WangFeng", DateTime.Now, expiration
                , true, "UserData", FormsAuthentication.FormsCookiePath);
            HttpCookie cookie=new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authenticationTicket));
            System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
            //Response.StatusCode = 403;
            //throw new Exception("1");
            return View();
        }


    }
}
