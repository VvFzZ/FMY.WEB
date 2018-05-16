using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using FMY.WEB.Model;

namespace FMY.WEB.UI.Controllers
{
    public class UpLoadController : Controller
    {
        public ActionResult Index()
        {
            return View("~/views/test/UpLoadIndex.cshtml");
        }

        [HttpPost]
        public JsonResult UpLoad()
        {
            Result result = null;
            HttpPostedFileBase file = Request.Files[0];
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory
                , ConfigurationManager.AppSettings["UpLoadPath"]);
            //string serverpath = Server.MapPath("\\images\\") + filename;
            string extension = Path.GetExtension(file.FileName);

            if (!(extension == ".jpeg"
                || extension == ".jpg"
                || extension == ".png"
                || extension == ".gif"))
            {
                result = new Result(false, "图片格式错误");
            }
            else
            {
                file.SaveAs(string.Format("{0}{1}{2}"
                    , filePath, DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension));
            }

            return Json(new Result(true));
        }
    }
}