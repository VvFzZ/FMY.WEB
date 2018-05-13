using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMY.WEB.Comm.Tools
{
    public class ExceptionHelper
    {
        public static void WriteFile404()
        {
            RespEndWriteFile("~/Error/500.html", 404);
        }

        public static void WriteFile500()
        {
            RespEndWriteFile("~/Error/500.html", 500);
        }

        public static void RespEndWriteFile(string filePath, int statusCode)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.StatusCode = statusCode;
            HttpContext.Current.Response.WriteFile(filePath);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static void ApplicationError(HttpApplication application)
        {
            #region 
            //refer：http://shiyousan.com/post/635813858052755170
            //1.将Web.config配置文件中customErrors节点的mode设置为Off
            //2.在GlobalFilter全局过滤器中取消HandleErrorAttribute的注册： 
            #endregion
            Exception lastException = application.Server.GetLastError();
            Log.LogTool.Error(lastException);
            application.Response.Clear();

            if (lastException != null)
            {
                //异常信息
                string strExceptionMessage = string.Empty;
                //对HTTP 404做额外处理，其他错误全部当成500服务器错误
                HttpException httpError = lastException as HttpException;

                if (httpError != null)
                {
                    //获取错误代码
                    int httpCode = httpError.GetHttpCode();
                    strExceptionMessage = httpError.Message;

                    if (httpCode == 400 || httpCode == 404)
                    {
                        WriteFile404();
                        application.Server.ClearError();
                        return;
                    }
                }

                WriteFile500();                
                application.Server.ClearError();                

                //一定要调用Server.ClearError()否则会触发错误详情页（就是黄页）                
                //Server.Transfer("~/HttpError/500.aspx");
            }
        }
    }
}