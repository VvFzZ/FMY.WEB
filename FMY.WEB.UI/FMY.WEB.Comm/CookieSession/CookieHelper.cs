using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

using FMY.WEB.Comm.Tools.EncryptTools;

namespace FMY.WEB.Comm.CookieSession
{
    public class CookieHelper
    {
        public static void ClearCookie(HttpRequest req, HttpResponse res, string cookieDomain, string cookieName)
        {
            HttpCookie cookie = req.Cookies.Get(cookieName);
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookie.Values.Clear();

                res.AppendCookie(cookie);
            }
        }

        public static void WriteCookie(HttpRequest req
            , HttpResponse res
            , string cookieDomain
            , string cookieName
            , object cookieValue
            , int? expireMinute)
        {
            int realExpireMinute = expireMinute.HasValue
                ? expireMinute.Value
                : 60 * 24;

            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = DEncryptHelper.Encrypt(cookieValue.ToString());
            cookie.Expires = DateTime.Now.AddMinutes(realExpireMinute);
            cookie.Domain = cookieDomain;
            cookie.Path = "/";

            res.AppendCookie(cookie);
        }
    }
}
