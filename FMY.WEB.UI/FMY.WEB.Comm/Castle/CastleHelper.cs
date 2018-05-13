using System.Web.Mvc;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace FMY.WEB.Comm.Castle
{
    public class CastleHelper
    {
        static IWindsorContainer container;

        public static void RegistCastle()
        {
            container = new WindsorContainer();

            //注册Installer (Installer 注册组件)
            container.Install(FromAssembly.This());//注册本程序集中实现IWindsorInstaller接口的Installer
            string configPath = System.Configuration.ConfigurationManager.AppSettings["CastleConfigPath"];
            container.Install(
                Configuration.FromXmlFile(configPath)
                //,Configuration.FromAppConfig()
                //,Configuration.FromXml(new AssemblyResource("assembly://Acme.Crm.Data/Configuration/services.xml"))
                );
            IControllerFactory controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
        

        public static void Release()
        {
            container.Dispose();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}