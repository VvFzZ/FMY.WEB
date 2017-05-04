using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMY.WEB.Model
{
    public class UserRegistEmail
    {
        private int id;

        /// <summary>
        /// 主键id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int userId;

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        private DateTime sendTime;

        /// <summary>
        /// 邮件发送时间
        /// </summary>
        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }


        private int status;

        /// <summary>
        /// 邮件是否失效（超过两小时失效）
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }


        private string validateCode;

        /// <summary>
        /// 验证码（验证邮件的验证码：guid）
        /// </summary>
        public string ValidateCode
        {
            get { return validateCode; }
            set { validateCode = value; }
        }
    }
}
