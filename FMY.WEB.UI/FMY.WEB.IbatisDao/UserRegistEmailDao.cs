using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FMY.WEB.Model;
using FMY.WEB.IDao;

namespace FMY.WEB.IbatisDao
{
    class UserRegistEmailDao : IUserRegistEmailDao
    {

        private string GetMapFullName(string statementName)
        {
            return string.Format("{0}.{1}.{2}", Mapper.MapperDomain, "UserRegistEmail", statementName);
        }

        public int addEmailRecrd(UserRegistEmail model)
        {
            string mapper = GetMapFullName("InsertUserRegistEmail");
            return (int)Mapper.Instance.Insert(mapper, model);
        }

        public int GetIdByUidAndVcode(string userId, string validateCode)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmailStatus(int id, string validateCode, int status)
        {
            throw new NotImplementedException();
        }
    }
}
