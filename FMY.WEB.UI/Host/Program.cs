using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.ServiceModel.Description;
using FMY.WCF.Test.Contract;
using FMY.WCF.Test.Services;


namespace FMY.WCF.Test.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                #region MyRegion
                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:8095/calculatorservice");
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //    behavior.HttpGetEnabled = true;
                //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:8095/calculatorservice/metadata");
                //    host.Description.Behaviors.Add(behavior);
                //}` 
                #endregion
                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };
                host.Open();
                Console.Read();
            }
        }
    }
}
