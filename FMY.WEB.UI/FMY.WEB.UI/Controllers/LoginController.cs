using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using FMY.WEB.Comm.CookieSession;
using FMY.WEB.Comm.Tools.EncryptTools;
using FMY.WEB.Model;

namespace FMY.WEB.UI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/\
        public LoginController()
        {
            //C3
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string name, string pwd)
        {

#if DEBUG
            if (name != pwd)
                return Json(new Result(false));
#else
            //Validate
#endif
            User user = new User() { Id = 1, Name = "wifi" };

            string token = string.Empty;

            SessionHelper.Login(out token, user);

            CookieHelper.WriteCookie(
                System.Web.HttpContext.Current.Request
                , System.Web.HttpContext.Current.Response
                , string.Empty
                , CookieKeys.LoginKey
                , token
                , null);

            return Json(new Result(true));
        }


        public JsonResult IsLogin()
        {
            string token = System.Web.HttpContext.Current.Request.Cookies[CookieKeys.LoginKey].Value;
            string decryptedToken = DEncryptHelper.Decrypt(token);
            bool flag = SessionHelper.IsLogin(decryptedToken);

            return Json(new Result(flag), JsonRequestBehavior.AllowGet);
        }
    }
}
