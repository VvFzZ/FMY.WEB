using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMY.WEB.BLL;
using FMY.WEB.Model;

namespace FMY.WEB.UI
{
    /// <summary>
    /// ActiveUser 的摘要说明
    /// </summary>
    public class ActiveUser : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            int result = 0;
            string scriptStr = string.Empty;
            string emailId = context.Request["emailId"];
            string validateCode = context.Request["validateCode"];
            if (string.IsNullOrEmpty(emailId) || string.IsNullOrEmpty(validateCode))
            {
                context.Response.Write("<script>alert('激活失败');window.close()</script>");
            }

            UserRegistEmailService userRegistEmailService = new UserRegistEmailService();

            //if (userRegistEmailService.GetIdByUidAndVcode(emailId, validateCode) >= 1)//存在待激活邮件
            //{
            result = userRegistEmailService.UpdateEmailStatus(int.Parse(emailId), validateCode, (int)UserRegEmailStatEnum.Actived);//修改邮件状态
            //}
            if (result > 0)
                scriptStr = "<script>alert('激活成功');location.href='http://localhost:39740/index'</script>";
            else
                scriptStr = "<script>alert('激活失败');";
            context.Response.Write(scriptStr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}