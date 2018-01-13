using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;

namespace FMY.WEB.UI.Handlers
{
    public class GoingHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("going");
            foreach (var item in HttpContext.Current.ApplicationInstance.Modules.AllKeys)
            {
                context.Response.Write(item + "\r\n");
            }
        }
    }


    public class GoingHandler_ : IHttpHandler
    {
        protected string HttpHandlers;

        private int counter;

        //IHttpHandler.IsReusable并不能决定是否重用HttpHanlder ！
        //小结：IHttpHandler.IsReusable并不能完全决定HttpHandler的实例是否能重用，它只起到一个指示作用。 
        //      HttpHandler如何重用，关键还是要由HttpHandlerFactory来实现。 
        //参照：ReusableAshxHandlerFactory
        public bool IsReusable
        {
            get { return false; }
        }

        //private int myVar;

        public void ProcessRequest(HttpContext context)
        {
            counter++;
            context.Response.ContentType = "text/html";
            //context.Response.Write("GoingHandler_");
            string typeName = typeof(HttpRequest).AssemblyQualifiedName
                                       .Replace("HttpRequest", "Configuration.RuntimeConfig");
            Type type = Type.GetType(typeName);

            bool useAppConfig = context.Request.QueryString["useAppConfig"] == "1";

            // 由于RuntimeConfig类型的可见性是internal，
            // 所以，我不能直接用它声明变量，只能使用object类型
            object config = null;

            if (useAppConfig)
                config = type.InvokeMember("GetAppConfig",
                    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic,
                    null, null, null);
            else
                config = type.InvokeMember("GetConfig",
                    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic,
                    null, null, new object[] { context });


            HttpHandlersSection section = (HttpHandlersSection)type.InvokeMember("HttpHandlers",
                 BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                 null, config, null);

            HttpHandlers = string.Format("总共 {0} 个配置项。<br />", section.Handlers.Count) +
                string.Join("<br />", (
                    from h in section.Handlers.Cast<HttpHandlerAction>()
                    let action = string.Format("path=\"{0}\" verb=\"{1}\" validate=\"{2}\" type=\"{3}\"",
                            h.Path, h.Verb, h.Validate, h.Type)
                    select action).ToArray());
            context.Response.Write(HttpHandlers);
        }
    }



    public class GoingRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new GoingHandler();
        }
    }
}