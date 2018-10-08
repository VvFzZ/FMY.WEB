using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

using FMY.WEB.Model;
using FMY.WEB.Model.Comm;
using FMY.WEB.BLL;
using FMY.WEB.Comm.Tools.CommTools;
using FMY.WEB.Comm.Tools.ConfigTools;
using FMY.WEB.Comm.Tools.Log;


namespace FMY.WEB.UI.Controllers
{
    public class RegistController : Controller
    {

        UserRegistEmailService userRegistEmailService;

        public int a = 1;
        public RegistController(UserRegistEmailService userRegistEmailService)
        {
            this.userRegistEmailService = userRegistEmailService;
        }

        // GET: /Regist/
        //[OutputCache(Duration = 10, VaryByParam = null)]
        public ActionResult Index()
        {
            try
            {
                IFMYLog loger = new Log4FMYLog();
                int a = 0;
                try
                {
                    LogTool.Debug("DebugMessage");
                    a = 1 / a;
                }
                catch (Exception ex)
                {
                    loger.Error(ex.Message);
                }
            }
            catch (Exception)
            {
                throw;
            }

            //string LastModifiedTime = Request.Headers["If-Modified-Since"];            
            //Response.Cache.SetCacheability(HttpCacheability.Private);
            ////Response.Cache.SetExpires(DateTime.Now.AddSeconds(10.0));
            Response.Cache.SetMaxAge(TimeSpan.FromSeconds(5));
            //if (!string.IsNullOrEmpty(LastModifiedTime))
            //{
            //    Response.StatusCode = 304;
            //    Response.End();
            //}
            //Response.Cache.SetLastModified(DateTime.Now);
            //Response.Cache.SetLastModified(DateTime.Now);
            //throw new Exception();
            //要让表示层尽可能的简单，简单到不需要测试      
            //把调用业务逻辑代码提取到 单独一层(比如叫服务层) ，UI层调用服务层，由服务层去调用BLL （层间API粒度如何设计）
            return View();
        }


        [HttpPost]
        public JsonResult Regist(User user)
        {
            string validateMsg = string.Empty;
            bool validate = ValidateRegist(user, ref validateMsg);

            if (!validate)
                return Json(new Result(validate, validateMsg));

            UserService userService = new UserService();//×××

            if (userService.GetUserCountByEmail(user.Email) > 0)
                return Json(new Result(false, "注册失败：该邮箱已注册！"));

            int userId = -1;

            using (TransactionScope trans = new TransactionScope())
            {
                user.CreateTime = DateTime.Now;
                user.UpdateTime = DateTime.Now;
                userId = userService.AddUser(user);

                if (userId <= 0)
                    return Json(new Result(false, "注册失败！"));

                //用户状态session默认失效时间20min
                Session[string.Format("User{0}", userId)] = user;
                string validateCode = Guid.NewGuid().ToString();

                UserRegistEmail emailModel = new UserRegistEmail()
                {
                    SendTime = DateTime.Now,
                    Status = (int)UserRegEmailStatEnum.NeedActive,
                    ValidateCode = validateCode,
                    UserId = userId
                };

                //数据库记录邮件
                int emailId = userRegistEmailService.addEmailRecrd(emailModel);

                //发送邮件
                SendEmail(emailId, validateCode, user.Email);
                trans.Complete();
            }

            return Json(new Result(true, userId.ToString()));
        }


        /// <summary>
        /// 验证输入
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool ValidateRegist(User user, ref string msg)
        {
            bool result = true;
            if (user.Name == null || user.PassWord == null || user.Email == null)
            {
                msg = "信息不完善！";
                result = false;
            }
            else if (!Regex.IsMatch(user.Name, "^[A-Za-z0-9_\u554A-\u9C52]{2,10}+$"))
            {
                msg = "错误数据提交！";
                result = false;
            }
            else if (user.PassWord.Length < 5 || user.PassWord.Length > 20)
            {
                msg = "错误数据提交！";
                result = false;
            }
            else if (!Regex.IsMatch(user.Email, "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$"))
            {
                msg = "错误数据提交！";
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="validateCode"></param>
        private void SendEmail(int emailId, string validateCode, string recevierMail)
        {
            IDictionary<string, string> paramDic = new Dictionary<string, string>(3);//激活邮件url参数
            paramDic.Add("emailId", emailId.ToString());
            paramDic.Add("validateCode", validateCode);
            new EmailTool(new Email
            {
                ActiveLinkUrl = WebConfigTool.GetAppsetting("UserActivePageUrl"),
                ActiveLinkParams = paramDic,
                Body = WebConfigTool.GetAppsetting("ValidateEmailBody"),
                BodyEncoding = Encoding.UTF8,
                EmailAcount = "15832163021@163.com",
                EmailPassword = "f13932258865",
                EnableSsl = true,
                IsBodyHtml = false,
                Priority = EmailPriority.Normal,
                ReceiverAddr = recevierMail,
                SenderAddr = "15832163021@163.com",
                SmtpHost = "smtp.163.com",
                Subject = "感谢您的注册",
                SubjectEncoding = Encoding.UTF8
            }).SendEmail();//发送邮件
        }

    }
}
