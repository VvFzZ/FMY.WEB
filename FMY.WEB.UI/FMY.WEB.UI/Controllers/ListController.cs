using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.BPDic = FMY.WEB.Comm.Tools.ExceptionHelper.BlackPhoneStateDic;
            return View();
        }

        public static IDictionary<int, string> _dic;

        /*
         * 一个静态字段 加载到Loader堆之后 什么时候会销毁
         * AppDomain 卸载会销毁
         * 更新dll会销毁吗
         * 
         * 
         **/




    }
}