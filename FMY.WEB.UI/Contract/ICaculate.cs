using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FMY.WEB.Model;

namespace FMY.WCF.Test.Contract
{
    [ServiceContract(Name = "CalculatorService",SessionMode =SessionMode.Required)]
    //[DeliveryRequirements(RequireOrderedDelivery = true)]
    public partial interface ICalculator
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int Add(int i, int j);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int InsertUser(User user);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int InserRegistEmail(UserRegistEmail userRegistEmailModel);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int InsertUserNoTrans(User user);
    }
}
