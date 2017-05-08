using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WCF.Test.Contract;
using FMY.WEB.Model;
using System.ServiceModel;
using System.Transactions;

namespace FMY.WCF.Test.Services
{
    [ServiceBehavior(
       TransactionTimeout = "00:00:30",
       InstanceContextMode = InstanceContextMode.PerCall)]
    public class CalculatorService : ICalculator
    {
        public int Add(int i, int j)
        {
            return i + j;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public int InserRegistEmail(UserRegistEmail userRegistEmailModel)
        {
            FMY.WEB.BLL.UserRegistEmailService userRegistEmailServie = new WEB.BLL.UserRegistEmailService();
            userRegistEmailServie.addEmailRecrd(new UserRegistEmail()
            {
                SendTime = DateTime.Now,
                Status = 1,
                UserId = 2,
                ValidateCode = "testcode"
            });
            return 1;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public int InsertUser(User user)
        {
            FMY.WEB.BLL.UserService userServie = new WEB.BLL.UserService();
            try
            {
                userServie.AddUser(user);
                user.Name = user.Name + "_";
                userServie.AddUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
            return 1;
        }
    }
}
