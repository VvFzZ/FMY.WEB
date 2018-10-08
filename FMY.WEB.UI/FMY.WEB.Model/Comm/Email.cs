using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FMY.WEB.Model;

namespace FMY.WEB.Model.Comm
{
    public class Email
    {
        private string senderAddr;
        /// <summary>
        /// 发送地址
        /// </summary>
        public string SenderAddr
        {
            get { return senderAddr; }
            set { senderAddr = value; }
        }
        private string receiverAddr;
        /// <summary>
        /// 收件地址
        /// </summary>
        public string ReceiverAddr
        {
            get { return receiverAddr; }
            set { receiverAddr = value; }
        }
        private string body;
        /// <summary>
        /// 邮件正文
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        private Encoding bodyEncoding;
        /// <summary>
        /// 正文编码
        /// </summary>
        public Encoding BodyEncoding
        {
            get { return bodyEncoding; }
            set { bodyEncoding = value; }
        }
        private bool ssBodyHtml;
        /// <summary>
        /// 正文是否是html
        /// </summary>
        public bool IsBodyHtml
        {
            get { return ssBodyHtml; }
            set { ssBodyHtml = value; }
        }
        private EmailPriority priority;
        /// <summary>
        /// 邮件优先级
        /// </summary>
        public EmailPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        private string subject;
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private Encoding subjectEncoding;
        /// <summary>
        /// 主题编码
        /// </summary>
        public Encoding SubjectEncoding
        {
            get { return subjectEncoding; }
            set { subjectEncoding = value; }
        }

        private string smtpHost;
        /// <summary>
        /// smtp发送服务器ip
        /// </summary>
        public string SmtpHost
        {
            get { return smtpHost; }
            set { smtpHost = value; }
        }
        private string emailAcount;
        /// <summary>
        /// 邮件帐号
        /// </summary>
        public string EmailAcount
        {
            get { return emailAcount; }
            set { emailAcount = value; }
        }
        private string emailPassword;
        /// <summary>
        /// 邮件密码
        /// </summary>
        public string EmailPassword
        {
            get { return emailPassword; }
            set { emailPassword = value; }
        }

        private bool enableSsl;
        /// <summary>
        /// 是否使用安全套接字层（ssl）加密连接
        /// </summary>
        public bool EnableSsl
        {
            get { return enableSsl; }
            set { enableSsl = value; }
        }

        private string activeLinkUrl;
        /// <summary>
        /// 激活链接域名
        /// </summary>
        public string ActiveLinkUrl
        {
            get { return activeLinkUrl; }
            set { activeLinkUrl = value; }
        }

        private IDictionary<string, string> activeLinkParams;
        /// <summary>
        /// 激活链接参数
        /// </summary>
        public IDictionary<string, string> ActiveLinkParams
        {
            get { return activeLinkParams; }
            set { activeLinkParams = value; }
        }
        
    }
}
