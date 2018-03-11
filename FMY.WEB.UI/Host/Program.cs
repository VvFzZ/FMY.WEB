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
                #region [    ]
                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:8095/calculatorservice");
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //    behavior.HttpGetEnabled = true;
                //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:8095/calculatorservice/metadata");
                //    host.Description.Behaviors.Add(behavior);
                //}` 
                #endregion

                #region [              设置授权模式 P497          ]
                //host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.None; 
                #endregion

                #region [              自定义X509验证           ]
                //serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
                //serviceHost.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new CustomX509CertificateValidator(); 
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
