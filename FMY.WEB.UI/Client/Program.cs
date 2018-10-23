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
            NetTCP_Binding_Test();
            HTTP_Binding_Test();
               CalculatorServiceClient client = new CalculatorServiceClient();
            CalculatorServiceClient client2 = new CalculatorServiceClient();
            //client.ClientCredentials.Windows.ClientCredential.Domain = "myDomain";

            //client.ClientCredentials.Windows.ClientCredential.UserName = "name";
            //client.ClientCredentials.Windows.ClientCredential.Password = "pwd";

            client.Add(1, 1);
            return;
            System.Threading.Tasks.Task.Factory.StartNew(() => {
                using (TransactionScope ts = new TransactionScope())
                {
                    Transaction.Current = null;
                    client2.InsertUser(new User()
                    {
                        ActiveTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Email = "1214211329@qq.com",
                        Name = "TestWF",
                        PassWord = "123",
                        Phone = "15832163021",
                        Sex = 1,
                        Status = false,
                        UpdateTime = DateTime.Now
                    });
                    int a = 1;
                    throw new Exception("");
                }
            });
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Transaction.Current = null;
                    client.InsertUser(new User()
                    {
                        ActiveTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Email = "1214211329@qq.com",
                        Name = "TestWF",
                        PassWord = "123",
                        Phone = "15832163021",
                        Sex = 1,
                        Status = false,
                        UpdateTime = DateTime.Now
                    });
                    int a = 1;
                    throw new Exception("");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            Console.ReadKey();
        }

        public static void NetTCP_Binding_Test()
        {
            FMY.WCF.Test.Client.Proxy.TCP.CalculatorServiceClient client 
                = new FMY.WCF.Test.Client.Proxy.TCP.CalculatorServiceClient();

            int result= client.Add(1, 2);

            Console.WriteLine(result);
        }

        public static void HTTP_Binding_Test()
        {
            FMY.WCF.Test.Client.Proxy.HTTP.CalculatorServiceClient client
                = new FMY.WCF.Test.Client.Proxy.HTTP.CalculatorServiceClient();

            Console.WriteLine(client.Add(1, 2));
        }
    }
}
