using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace FMY.WEB.UI.Handlers
{
    //设计HttpHandlerFactory并不是完全为了重用Handler， 
    //它的主要用途还是如何创建HttpHandler，
    //而且定义IHttpHandlerFactory的主要目的是为了扩展性
    public class ReusableAshxHandlerFactory : IHttpHandlerFactory
    {
        private Dictionary<string, IHttpHandler> _cache
        = new Dictionary<string, IHttpHandler>(200, StringComparer.OrdinalIgnoreCase);
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            string cacheKey = requestType + url;

            // 检查是否有缓存的实例（或者可理解为：被重用的实例）
            IHttpHandler handler = null;
            if (_cache.TryGetValue(cacheKey, out handler) == false)
            {
                // 根据请求路径创建对应的实例
                Type handlerType = BuildManager.GetCompiledType(url);

                // 确保一定是IHttpHandler类型
                if (typeof(IHttpHandler).IsAssignableFrom(handlerType) == false)
                    throw new HttpException("要访问的资源没有实现IHttpHandler接口。");

                // 创建实例，并保存到成员字段中
                handler = (IHttpHandler)Activator.CreateInstance(handlerType, true);

                // 如果handler要求重用，则保存它的引用。
                if (handler.IsReusable)
                    _cache[cacheKey] = handler;
            }
            return handler;
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            //HttpRuntime.Cache
        }
    }
}