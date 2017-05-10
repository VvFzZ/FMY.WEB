using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FMY.WEB.Model;

namespace FMY.WCF.Test.Contract
{
    [ServiceContract(Name = "CalculatorService",SessionMode =SessionMode.Required)]
    public partial interface ICalculator
    {
        [OperationContract]
        int Add(int i, int j);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        int InsertUser(User user);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        int InserRegistEmail(UserRegistEmail userRegistEmailModel);

        [OperationContract]
        int InsertUserNoTrans(User user);
    }
}
