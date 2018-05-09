using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using FMY.WEB.Comm.Containers;
using FMY.WEB.UI.Framework.View;
using FMY.WEB.Comm.Castle;
using FMY.WEB.Comm.Tools;
using System.Web.SessionState;
using System.Reflection;

namespace FMY.WEB.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CastleHelper.RegistCastle();
            //ViewEngines.Engines.Insert(0, new StaticFileViewEngine());
            //ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());
        }

        public override void Init()
        {
            base.Init();
            foreach (string moduleName in this.Modules)
            {
                string appName = "zizhiguanjia.com";
                IHttpModule module = this.Modules[moduleName];
                SessionStateModule ssm = module as SessionStateModule;
                if (ssm != null)
                {
                    FieldInfo storeInfo = typeof(SessionStateModule).GetField("_store", BindingFlags.Instance | BindingFlags.NonPublic);
                    SessionStateStoreProviderBase store = (SessionStateStoreProviderBase)storeInfo.GetValue(ssm);
                    if (store == null)//In IIS7 Integrated mode, module.Init() is called later
                    {
                        FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
                        HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
                        FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
                        appNameInfo.SetValue(theRuntime, appName);
                    }
                    else
                    {
                        Type storeType = store.GetType();
                        if (storeType.Name.Equals("OutOfProcSessionStateStore"))
                        {
                            FieldInfo uribaseInfo = storeType.GetField("s_uribase", BindingFlags.Static | BindingFlags.NonPublic);
                            uribaseInfo.SetValue(storeType, appName);
                        }
                    }
                }
            }
        }

        #region [          Application管道          ]
        //如果是IIS7，第10个事件也就是MapRequestHandler事件，而且在EndRequest 事件前，还增加了另二个事件：LogRequest 和 PostLogRequest 事件。
        //只有当应用程序在 IIS 7.0 集成模式下运行，并且与.NET Framework 3.0 或更高版本一起运行时，才会支持 MapRequestHandler、LogRequest 和 PostLogRequest 事件

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var a= RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
           
        }

        //验证
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 授权
        /// //Context.RewritePath:
        /// 1.不会重发请求（需要查看源码实现） 
        /// 2.要在确定IHttpHandler之前调用，否则 重定向无效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {

        }

        //缓存处理
        protected void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            //HttpApplication app = (HttpApplication)sender;
            //// 这里将检查URL是否为需要重写的模式，比如:
            //if (string.Compare(app.Context.Request.RawUrl, "/regist.go", true) == 0)
            //    app.Context.RewritePath("~/regist/index");            
        }

        protected void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            //UrlRoutingModule通过此事件订阅HttpApplication对象
            if (string.Compare(HttpContext.Current.Request.RawUrl, "/going.go", true) == 0)
                HttpContext.Current.RemapHandler(new Handlers.GoingHandler());
            //HttpContext.Current.RemapHandler(new Handlers.GoingHandler_());
            //Warn：在PostMapRequestHandler 中调用RemapHandler 引发错误。System.InvalidOperationException:“只能在引发“HttpApplication.MapRequestHandler”之前调用“HttpContext.RemapHandler”。”
        }


        protected void Application_MapRequestHandler(object sender, EventArgs e)
        {
            //根据所请求资源的文件扩展名（在应用程序的配置文件中映射），选择实现 IHttpHandler 的类，对请求进行处理。 
            //如果该请求针对从 Page 类派生的对象（页），并且需要对该页进行编译，则 ASP.NET 会在创建该页的实例之前对其进行编译。
        }

        protected void Application_PostMapRequestHandler(object sender, EventArgs e)
        {
            //HttpContext.Current.RemapHandler(new Handlers.GoingHandler_());
        }

        //
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }

        protected void Application_PostAcquireRequestState(object sender, EventArgs e)
        {

        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        //调用ProcessRequest 
        //为该请求调用合适的 IHttpHandler 类的 ProcessRequest 方法（或异步版 IHttpAsyncHandler.BeginProcessRequest）。 例如，如果该请求针对某页，则当前的页实例将处理该请求。

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        //
        protected void Application_ReleaseRequestState(object sender, EventArgs e)
        {

        }

        protected void Application_PostReleaseRequestState(object sender, EventArgs e)
        {

        }

        //如果定义了 Filter (HttpContext.Filter)属性，则执行响应筛选

        //更新缓存
        protected void Application_UpdateRequestCache(object sender, EventArgs e)
        {

        }

        protected void Application_PostUpdateRequestCache(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
           ExceptionHelper.ApplicationError(this);
        }

        /// <summary>
        /// 
        /// 在IHttpHandler中调用Response.End 会跳过ProcessRequest之后 PostRequestHandlerExecute到PostUpdateRequestCache的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_LogRequest(object sender, EventArgs e)
        {

        }

        protected void Application_PostLogRequest(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {

        }

        protected void Application_PreSendRequestContent(object sender, EventArgs e)
        {

        }

        #endregion

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为InProc 时，才会引发 Session_End 事件
            // 如果会话模式设置为 StateServer 或 SQLServer，则不会引发该事件
        }

        protected void Application_End(object sender, EventArgs e)
        {
            CastleHelper.Release();
        }
    }


    //public class UnityControllerFactory:DefaultControllerFactory
    //{
    //    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    //    {
    //        return (IController)UnityContainerHelper.GetInstance(controllerType);
    //    }
    //}

}