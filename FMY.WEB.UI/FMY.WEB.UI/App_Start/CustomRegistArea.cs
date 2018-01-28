using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI.Controllers.Custom
{
    public class CustomRegistArea : System.Web.Mvc.AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CustomRegistArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapRoute(
                name: "CRAdefault",
                url: "cra/123",
                defaults: new { controller = "Area", action = "Index" }
                );
        }
    }

}
