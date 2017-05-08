using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using FMY.WEB.Model;
using FMY.SQL.ADO;



namespace FMY.WEB.DAL
{
    public class UserDao
    {
        public DataTable GetAllUser(string sqlText)
        {
            return SQLHelper.Select(sqlText, CommandType.Text);
        }
        /// <summary>
        /// 插入新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            UserDao userDao = new UserDao();
            string sql = string.Format("INSERT INTO dbo.[user] (Name, Phone, Sex, PassWord,Email,Status) VALUES (@name,@phone,@sex,@password,@email,@status);SELECT @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { 
                new System.Data.SqlClient.SqlParameter("@name",System.Data.SqlDbType.NVarChar),
                new System.Data.SqlClient.SqlParameter("@phone",System.Data.SqlDbType.NVarChar),
                new System.Data.SqlClient.SqlParameter("@sex",System.Data.SqlDbType.TinyInt),
                new System.Data.SqlClient.SqlParameter("@password",System.Data.SqlDbType.NVarChar),
                new System.Data.SqlClient.SqlParameter("@email",System.Data.SqlDbType.NVarChar),
                new System.Data.SqlClient.SqlParameter("@status",System.Data.SqlDbType.Bit)
            };
            parameters[0].Value = user.Name;
            parameters[1].Value = user.Phone ?? "";
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

        public void ExecProc(string proc, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            SQLHelper.Excute(proc, commandType, parameters);
        }
    }
}
