using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WEB.Model;
using FMY.SQL.ADO;
using System.Data;
using System.Data.SqlClient;

namespace FMY.WEB.DAL
{
    public class UserRegistEmailDao
    {
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns>记录id</returns>
        public int addEmailRecrd(UserRegistEmail model)
        {
            string sql = string.Format("INSERT INTO dbo.UserRegistEmail ( userid ,sendtime ,status ,validatecode)VALUES ({0},{1},{2},{3});select @@identity", "@userid", "@sendtime", "@status", "@validatecode");
            SqlParameter[] parameters ={
                                           new SqlParameter("@userid",SqlDbType.Int),
                                           new SqlParameter("@sendtime",SqlDbType.DateTime),
                                           new SqlParameter("@status",SqlDbType.Bit),
                                           new SqlParameter("@validatecode",SqlDbType.NVarChar)
                                       };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.SendTime;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.ValidateCode;
            //object obj=SQLHelper.SelectFirst(sql, CommandType.Text, parameters);
            object obj = Instance.GetInstance().SelectFirst(sql, CommandType.Text, parameters);

            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 根据用户id 验证码查询记录数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public int GetIdByUidAndVcode(string userId, string validateCode)
        {
            string sql = string.Format("SELECT id FROM dbo.UserRegistEmail ure WHERE ure.userid={0} AND ure.validatecode='{1}' AND ure.status=0", userId, validateCode);//status=0待激活
            return SQLHelper.Excute(sql, CommandType.Text);
        }
        /// <summary>
        /// 根据id修改记录状态为
        /// </summary>
        /// <param name="status">订单状态</param>
        /// <param name="id">要修改记录的id</param>
        /// <returns></returns>
        public int UpdateEmailStatus(int id, string validateCode, int status)
        {
            string sql = string.Format("UPDATE dbo.UserRegistEmail SET status={0} WHERE id={1} AND validatecode='{2}'", status, id, validateCode);
            return SQLHelper.Excute(sql, CommandType.Text);
        }
    }
}
