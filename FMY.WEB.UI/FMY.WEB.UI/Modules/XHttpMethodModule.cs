using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FMY.WEB.UI.Modules
{
    public class XHttpMethodModule : IHttpModule
    {
        private FieldInfo _field;
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            // 订阅这个较早的事件，可以让请求的后续阶段都能读到新的结果。
            context.BeginRequest += new EventHandler(context_BeginRequest);
            _field = typeof(HttpRequest).GetField("_httpMethod", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            // 这里仅检查是否为POST操作，如果您的应用中需要使用GET来模拟的，请修改这里。
            if (string.Equals(app.Request.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                // 这里为了简单，我只检查请求头，如果还需要检查表单值或者查询字符串，请修改这里。
                string headerOverrideValue = app.Request.Headers["X-HTTP-Method-Override"];

                if (string.IsNullOrEmpty(headerOverrideValue) == false)
                {
                    if (string.Equals(headerOverrideValue, "GET", StringComparison.OrdinalIgnoreCase) == false
                        && string.Equals(headerOverrideValue, "POST", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        // HttpRequest.HttpMethod属性其实就是访问_httpMethod这个私有字段，我将直接修改它。
                        // 这样修改后，最原始的HTTP方法就丢失，通常这或许也是可以接受的。
                        _field.SetValue(app.Request, headerOverrideValue.ToUpper());
                    }
                }
            }
        }
    }
}