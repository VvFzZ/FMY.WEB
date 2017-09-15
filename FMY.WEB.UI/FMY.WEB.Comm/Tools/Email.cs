using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using FMY.WEB.Model.Comm;
using FMY.WEB.Model;

namespace FMY.WEB.Comm.Tools.CommTools
{
    public class EmailTool
    {
        private Email email;

        public EmailTool(Email model)
        {
            email = model;
        }
        /// <summary>
        /// 生成激活邮件内容
        /// </summary>
        /// <param name="dic">激活连接url参数键值对</param>
        /// <returns></returns>
        private string GetSendBody(string body, string linkDomain, IDictionary<string, string> dic)
        {
            if (dic == null || dic.Count < 1)
                throw new Exception("paramemeter is null!");
            StringBuilder bodyBuilder = new StringBuilder(body);
            StringBuilder paramBuilder = new StringBuilder();
            foreach (var item in dic)
            {
                paramBuilder.AppendFormat("&{0}={1}", item.Key, item.Value);
            }
            bodyBuilder.AppendFormat("{0}?{1}", linkDomain, paramBuilder.ToString().Substring(1));
            return bodyBuilder.ToString();
        }
        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="sendToAdd">邮件目标地址</param>
        /// <param name="mailBody">邮件内容</param>
        public void SendEmail()
        {
            //发送地址
            MailAddress mailSender = new MailAddress(email.SenderAddr);
            //目标地址
            MailAddress mailReceiver = new MailAddress(email.ReceiverAddr);
            //初始化邮件
            MailMessage mailMessage = new MailMessage(mailSender, mailReceiver);
            mailMessage.Body = this.GetSendBody(email.Body, email.ActiveLinkUrl, email.ActiveLinkParams);//正文
            mailMessage.BodyEncoding = email.BodyEncoding;//正文编码
            mailMessage.IsBodyHtml = email.IsBodyHtml;
            mailMessage.Sender = mailSender;//发件人地址
            mailMessage.From = mailSender;//发件人地址
            mailMessage.Priority = (MailPriority)Enum.ToObject(typeof(EmailPriority), ((int)email.Priority)); // //优先级 (MailPriority)((int)(email.Priority))
            mailMessage.Subject = email.Subject;//邮件主题
            mailMessage.SubjectEncoding = email.SubjectEncoding;//主题编码
            //发送邮件
            SmtpClient client = new SmtpClient(email.SmtpHost);
            string emailAcount = email.EmailAcount;//帐号
            string emailPassword = email.EmailPassword;//密码
            client.Credentials = new NetworkCredential(emailAcount, emailPassword);
            client.EnableSsl = email.EnableSsl;
            client.Send(mailMessage);
        }
    }
}
