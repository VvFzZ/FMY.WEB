using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMY.WEB.UI
{
    public class CustomAuhtorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)

        {

            bool Pass = false;
            if (true/*Check Authority*/)
            {
                httpContext.Response.StatusCode = 401;//无权限状态码  
                Pass = false;
            }
            else
            {
                Pass = true;
            }

            return Pass;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                string path = filterContext.HttpContext.Request.Path;
                string strUrl = "/Account/LogOn?returnUrl={0}";

                filterContext.HttpContext.Response.Redirect(string.Format(strUrl,path/* HttpUtility.UrlEncode(path)*/), true);

            }
        }
    }
}