using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace FMY.WEB.Model
{
    [DataContract]
    public class User
    {
        
        private int id;
        [DataMember]
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
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phone;
        [DataMember]
        /// <summary>
        /// 用户电话
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private int sex;
        [DataMember]
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        
        private string passWord;
        [DataMember]
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private string email;
        [DataMember]
        /// <summary>
        /// 邮箱  
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime? createTime;
        [DataMember]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private DateTime? activeTime;
        [DataMember]
        /// <summary>
        /// 激活时间
        /// </summary>
        public DateTime? ActiveTime
        {
            get { return activeTime; }
            set { activeTime = value; }
        }

        private DateTime? updateTime;
        [DataMember]
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        private bool status;
        [DataMember]
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
