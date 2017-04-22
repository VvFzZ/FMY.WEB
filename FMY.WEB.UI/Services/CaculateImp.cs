using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WCF.Test.Contract;

namespace FMY.WCF.Test.Services
{
    public class CalculatorService : ICalculator
    {
        public int Add(int i, int j)
        {
            return i + j;
        }
    }
}
