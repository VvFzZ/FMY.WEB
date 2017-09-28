using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMY.WEB.Model;
using FMY.WEB.IDao;
using System.Data;

namespace FMY.WEB.IbatisDao
{
    public class UserDao : IUserDao
    {
        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllUser()
        {
            throw new NotImplementedException();
        }

        public int GetUserCountByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
