using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FMY.WEB.Model;

namespace FMY.WEB.IDao
{
    public interface IUserDao
    {
        DataTable GetAllUser();

        int AddUser(User user);

        int GetUserCountByEmail(string email);

        //void ExecProc(string proc, System.Data.CommandType commandType, params SqlParameter[] parameters)

    }
}
