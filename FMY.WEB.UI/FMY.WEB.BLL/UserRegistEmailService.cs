using FMY.WEB.Model;
using FMY.WEB.Dao;//和具体Dao解耦后 不需要引用此库
using FMY.WEB.IDao;

namespace FMY.WEB.BLL
{
    public class UserRegistEmailService
    {

        private IUserRegistEmailDao userRegistEmailDao;

        public UserRegistEmailService()
        {
            //通过注入可以解耦 
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
