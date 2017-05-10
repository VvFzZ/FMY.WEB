using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WEB.Model;
using FMY.WEB.DAL;

namespace FMY.WEB.BLL
{
    public class UserRegistEmailService
    {
        private UserRegistEmailDao userRegistEmailDao;
        public UserRegistEmailService()
        {
            userRegistEmailDao = new UserRegistEmailDao();
        }
        /// <summary>
        /// 添加一条激活邮件记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>记录id</returns>
        public int addEmailRecrd(UserRegistEmail model)
        {
            return userRegistEmailDao.addEmailRecrd(model);
        }

        public int UpdateEmailStatus(int id,string validateCode,int status)
        {
            return userRegistEmailDao.UpdateEmailStatus(id, validateCode,status);
        }

        /// <summary>
        /// 根据用户id 验证码获取 待激活邮件数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public int GetModelByUidAndVcode(int userId,string validateCode)
        {
            return this.GetIdByUidAndVcode(userId.ToString(), validateCode);
        }
        /// <summary>
        /// 根据用户id 验证码获取 待激活邮件数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public int GetIdByUidAndVcode(string userId, string validateCode)
        {
            return userRegistEmailDao.GetIdByUidAndVcode(userId, validateCode);
        }
    }
}
