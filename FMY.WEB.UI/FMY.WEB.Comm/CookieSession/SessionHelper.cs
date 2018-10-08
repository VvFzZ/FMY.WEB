using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using FMY.WEB.Comm.Tools.EncryptTools;
using FMY.Core.RedisClient;
using FMY.WEB.Model;
using FMY.WEB.Comm.Tools.Log;

namespace FMY.WEB.Comm.CookieSession
{
    public class SessionHelper
    {
        public static string SessionIdPre = "SessionId:";
        public static string UserInfoPre = "UserInfo:";

        public static bool Login(
            out string token
            , FMY.WEB.Model.User user)
        {
            //HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieKeys.LoginKey];

            //if (cookie != null)//点击登录,但是已经存在登录cookie
            //{
            //    string oldToken = cookie.Value;
            //    string oldSessionKey = SessionIdPre + oldToken;
            //    //过期已经存在的cookie
            //    cookie.Expires.AddDays(-1);
            //    //过期原来的Session                
            //    bool existOldKey= RedisBase.Core.ContainsKey(oldSessionKey);

            //    if(existOldKey) RedisBase.Core.Delete<string>(SessionIdPre + oldToken);
            //}
            int count = 0;
            bool flag;
            string userInfoKey = UserInfoPre + user.Id;

            do
            {
                count++;
                token = Guid.NewGuid().ToString();//Convert.ToBase64String(Encoding.Default.GetBytes(Guid.NewGuid().ToString()));
                string newSessionKey = SessionIdPre + token;
                flag = RedisBase.Core.SetValueIfNotExists(newSessionKey, user.Id.ToString());//设置Seesion                

                if (flag)
                {
                    LogTool.Info("SessionHelper.Login:登录token生成次数");
                    //设置LoginSession 过期时间
                    RedisBase.Core.ExpireEntryIn(newSessionKey, TimeSpan.FromHours(20));
                    //设置UserInfo缓存信息
                    RedisBase.Core.SetRangeInHash(userInfoKey, new Dictionary<string, string>()
                    {
                        { "Token",token}
                        ,{"Name",user.Name}
                        ,{"UserId",user.Id.ToString()}
                    });

                    RedisBase.Core.ExpireEntryIn(userInfoKey, TimeSpan.FromHours(20));
                    break;
                }
                //System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(100));

            } while (flag);

            return true;
            //RedisSet.Add(LoginKeyPre + token, userId);
        }

        public static bool IsLogin(
            string token)
        {

            string sessionKey = SessionIdPre + token;
            string userId = RedisString.Get(sessionKey);

            // 没有找到session
            if (string.IsNullOrEmpty(userId))
                return false;

            //找到session后 进一步比对token值
            string userInfoKey = UserInfoPre + userId.ToString();
            string nowRedisToken = RedisBase.Core.GetValueFromHash(userInfoKey, "Token");

            return token == nowRedisToken;
        }

        public static bool RefreshSessionOfEveryRequest(string token)
        {
            //RedisString.Get(SessionIdPre + token);
            string sessionKey = SessionIdPre + token;
            string userId = RedisString.Get(sessionKey);

            if (string.IsNullOrEmpty(userId))
                return false;

            string userInfoKey = UserInfoPre + userId;
            string nowRedisToken = RedisBase.Core.GetValueFromHash(userInfoKey, "Token");

            if (token != nowRedisToken)
                return false;

            bool refreshSession = RefreshSession(token);
            bool refreshUserInfo = RefreshUserInfo(userId);

            if (refreshSession && refreshUserInfo)
                return true;
            else
            {
                LogTool.ErrorFromate("SessionHelper.RefreshSessionOfEveryRequest 每次请求更新Session错误 更新refreshSession{0},refreshUserInfo{1}", refreshSession, refreshUserInfo);
                return false;
            }
        }

        public static bool RefreshSession(string token)
        {
            return RedisBase.Core.ExpireEntryIn(SessionIdPre + token, TimeSpan.FromHours(20));
        }

        public static bool RefreshUserInfo(string userId)
        {
            string userInfoKey = UserInfoPre + userId;
            return RedisBase.Core.ExpireEntryIn(userInfoKey, TimeSpan.FromHours(20));
        }

    }
}
