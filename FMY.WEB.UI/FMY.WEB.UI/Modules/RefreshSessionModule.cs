﻿using FMY.WEB.Comm.CookieSession;
using FMY.WEB.Comm.Tools.EncryptTools;
using FMY.WEB.Comm.Tools.Log;
using System;
using System.Web;

namespace FMY.WEB.UI.Modules
{
    public class RefreshSessionModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieKeys.LoginKey];

            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;

            string token = string.Empty;

            try
            {
                token = DEncryptHelper.Decrypt(cookie.Value);
            }
            catch (Exception ex)
            {
                DealError(ex);
                return;
            }

            bool flag = SessionHelper.RefreshSessionOfEveryRequest(token);

            if (!flag)
                CookieHelper.ClearCookie(
                    HttpContext.Current.Request
                    , HttpContext.Current.Response
                    , string.Empty
                    , CookieKeys.LoginKey);
        }

        private static void DealError(Exception ex)
        {
            LogTool.Error(ex);
            LogTool.Error("RefreshSessionModule.Context_PreRequestHandlerExecute 解密登录cookie失败,推断为被恶意修改");
        }         
    }
}