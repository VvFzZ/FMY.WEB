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
            routes.RouteExistingFiles = false;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //RegisterRoutesExt(routes);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Regist", action = "Index", id = UrlParameter.Optional }
            );
            
        }

        public static void RegisterRoutesExt(RouteCollection routes)
        {
            routes.Add(new Route("going.go", new Handlers.GoingRouteHandler()));
        }
    }
}