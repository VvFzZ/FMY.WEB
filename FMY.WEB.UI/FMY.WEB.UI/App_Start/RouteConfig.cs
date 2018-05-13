using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FMY.WEB.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = false;//默认为false
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //RegisterRoutesExt(routes);

            routes.MapRoute(
                name: "DefaultList",
                url: "List/{action}",
                defaults: new { controller = "List", action = "Index" },
                namespaces:new string[] { "FMY.WEB.UI.Controllers" }                 
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Regist", action = "Index", id = UrlParameter.Optional,input="extent" }
            );
        }

        public static void RegisterRoutesExt(RouteCollection routes)
        {
            routes.Add(new Route("going.go", new Handlers.GoingRouteHandler()));
        }

    }

    public class MyAreaRegist : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Vip"; }
        }


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "defaultVip"
                , url: "vip/"
                , defaults: new { controller = "UserCenter", action = "index" }
                //, constraints: new object()
                , namespaces: new string[] { "FMY.WEB.UI.Controllers.VIP" }
                );
            context.MapRoute(
                name: "VipList"
                , url: "vip/List/"
                , defaults: new { controller = "List", action = "Index" }
                //, constraints: new object()
                , namespaces: new string[] { "FMY.WEB.UI.Controllers.VIP" }
                );
        }
    }
}