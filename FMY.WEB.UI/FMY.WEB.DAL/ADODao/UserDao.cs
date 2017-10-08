using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using FMY.WEB.Model;
using FMY.SQL.ADO;

namespace FMY.WEB.DAL
{
    public class UserDao
    {

        public List<User> GetAllUser(string sqlText)
        {
            return SQLHelper.Select<User>(sqlText, CommandType.Text);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            UserDao userDao = new UserDao();
            string sql = string.Format(@"INSERT INTO dbo.[user] (Name, Phone, Sex, PassWord,Email,Status) 
                                       VALUES (@name,@phone,@sex,@password,@email,@status);SELECT @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@name",SqlDbType.NVarChar),
                new SqlParameter("@phone",SqlDbType.NVarChar),
                new SqlParameter("@sex",SqlDbType.TinyInt),
                new SqlParameter("@password",SqlDbType.NVarChar),
                new SqlParameter("@email",SqlDbType.NVarChar),
                new SqlParameter("@status",SqlDbType.Bit)
            };
            parameters[0].Value = user.Name;
            parameters[1].Value = user.Phone ?? string.Empty;
            parameters[2].Value = user.Sex;
            parameters[3].Value = user.Password;
            parameters[4].Value = user.Email;
            parameters[5].Value = 0;
            return Convert.ToInt32(SQLHelper.SelectFirst(sql, CommandType.Text, parameters));
        }


        public int GetUserCountByEmail(string email)
        {
            string sql = string.Format("SELECT * FROM dbo.[user] u WHERE u.email='{0}'", email);
            return (int)(SQLHelper.SelectFirst(sql, CommandType.Text) ?? 0);
        }

        public void ExecProc(string proc, CommandType commandType, params SqlParameter[] parameters)
        {
            SQLHelper.Excute(proc, commandType, parameters);
        }
    }
}
