using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMY.WEB.Model;

namespace FMY.WEB.IDao
{
    public interface IUserRegistEmailDao
    {

        int addEmailRecrd(UserRegistEmail model);
        
        int GetIdByUidAndVcode(string userId, string validateCode);
        
        int UpdateEmailStatus(int id, string validateCode, int status);
    }
}
