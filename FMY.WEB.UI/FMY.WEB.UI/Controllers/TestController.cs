using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMY.WEB.BLL;

namespace FMY.WEB.UI.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            BLL.UserService userService = new UserService();
            userService.AddUser(new Model.User()
            {
                Name = "Test1"
            });
            return View();
        }

    }
}
