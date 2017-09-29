using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FMY.WEB.Model;
using FMY.WEB.IDao;
using System.Data;

namespace FMY.WEB.IbatisDao
{
    public class UserDao : IUserDao
    {

        private string GetMapFullName(string statementName)
        {
            return string.Format("{0}.{1}.{2}", Mapper.MapperDomain, "User", statementName);
        }


        public int AddUser(User user)
        {
            string mapper = GetMapFullName("InsertUser");
            return (Int32)Mapper.GetInstance().Insert(mapper, user);
        }


        public DataTable GetAllUser()
        {
            return null;
        }


        public int GetUserCountByEmail(string email)
        {
            return 0;
        }


        public IDictionary<K, V> GetDictionary<K, V>()
        {
            string mapper = GetMapFullName("GetdictionaryTest");
            return Mapper.GetInstance().QueryForDictionary<K, V>(mapper, null, "Name", "PassWord");
        }

    }
}
