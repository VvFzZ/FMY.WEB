using FMY.WCF.Test.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMY.WEB.Model;

namespace FMY.WCF.Test.Services
{
    public class CaculateImpExt : ICalculator
    {
        public int Add(int i, int j)
        {
            return i * 2 + j * 2;
        }

        public int InserRegistEmail(UserRegistEmail userRegistEmailModel)
        {
            return 4;
        }

        public int InsertUser(User user)
        {
            return 4;
        }
    }
}
