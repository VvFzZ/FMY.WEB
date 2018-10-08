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
        public int addEmailRecrd(UserRegistEmail model)
        {
            throw new NotImplementedException();
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
