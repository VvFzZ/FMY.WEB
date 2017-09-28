using System;
using System.Data;
using System.Data.SqlClient;
using FMY.WEB.Model;
using FMY.SQL.ADO;
using FMY.WEB.IDao;

namespace FMY.WEB.Dao
{
    public class UserDao:IUserDao
    {

        public DataTable GetAllUser()
        {
            string sql = "SELECT * FROM dbo.[user]";
            return SQLHelper.Select(sql, CommandType.Text);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        //public void ExecProc(string proc, CommandType commandType, params SqlParameter[] parameters)
        //{
        //    //SqlParameter 此类型不应该为参数 service层需要引用System.Data.SqlClient; 应该使用Model的参数类型
        //    SQLHelper.Excute(proc, commandType, parameters);
        //}

    }
}
