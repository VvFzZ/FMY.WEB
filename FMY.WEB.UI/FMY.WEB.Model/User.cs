using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMY.WEB.Model
{
    public class User
    {
        private int id;
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string phone;
        /// <summary>
        /// 用户电话
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int sex;
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string email;
        /// <summary>
        /// 邮箱  
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private DateTime activeTime;
        /// <summary>
        /// 激活时间
        /// </summary>
        public DateTime ActiveTime
        {
            get { return activeTime; }
            set { activeTime = value; }
        }
        private DateTime updateTime;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
        private bool status;
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        } 
        
        
    }
}
