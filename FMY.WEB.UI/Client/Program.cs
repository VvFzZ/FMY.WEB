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
            using (CalculatorServiceClient client = new CalculatorServiceClient())
            {
                try
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
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
            }
            Console.ReadKey();
        }
    }
}
