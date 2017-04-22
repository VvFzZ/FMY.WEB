using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace FMY.WCF.Test.Contract
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.artech.com/")]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int i, int j);
    }
}
