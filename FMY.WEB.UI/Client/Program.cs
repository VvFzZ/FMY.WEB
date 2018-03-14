using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMY.WEB.Model;
using System.Transactions;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorServiceClient client = new CalculatorServiceClient();
            int a = client.Add(1, 1);
            //client.ClientCredentials.Windows.ClientCredential.Domain = "myDomain";
            //client.ClientCredentials.Windows.ClientCredential.UserName = "name";
            //client.ClientCredentials.Windows.ClientCredential.Password = "pwd";
            client.Add(1, 1);
            Console.ReadKey();
        }
    }
}
