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
            Console.WriteLine(client.Add(1, 3));
            //client.InsertUserNoTrans(new User()
            //{
            //    ActiveTime = DateTime.Now,
            //    CreateTime = DateTime.Now,
            //    Email = "1214211329@qq.com",
            //    Name = "TestWF",
            //    Password = "123456",
            //    Phone = "15832163021",
            //    Sex = 1,
            //    Status = false,
            //    UpdateTime = DateTime.Now
            //});
            using (TransactionScope ts = new TransactionScope())
            {
                client.InsertUser(new User()
                {
                    ActiveTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Email = "1214211329@qq.com",
                    Name = "TestWF",
                    Password = "123456",
                    Phone = "15832163021",
                    Sex = 1,
                    Status = false,
                    UpdateTime = DateTime.Now
                });
                System.Transactions.Transaction.Current.Rollback();
            }
            Console.ReadKey();
        }
    }
}
