using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMY.WEB.Model
{

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatEnum
    {
        /// <summary>
        /// 待激活
        /// </summary>
        NeedActive = 0,
        /// <summary>
        /// 已激活
        /// </summary>
        Actived = 1,
        /// <summary>
        /// 已失效
        /// </summary>
        Invalid = 2
    }


    /// <summary>
    /// 注册邮件状态
    /// </summary>
    public enum UserRegEmailStatEnum
    {
        /// <summary>
        /// 待激活
        /// </summary>
        NeedActive = 0,
        /// <summary>
        /// 已激活
        /// </summary>
        Actived = 1,
        /// <summary>
        /// 已失效
        /// </summary>
        Invalid = 2
    }


    public enum EmailPriority
    {
        Normal = 0,
        Hight = 1,
        low = 2
    }
}
