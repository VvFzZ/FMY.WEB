//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace FMY.WEB.UI
//{
//    public class CastleConfig
//    {

//    }
//    public class WindsorControllerFactory : DefaultControllerFactory
//    {

//        private readonly IKernel _kernel;


//        public WindsorControllerFactory(IKernel kernel)
//        {
//            _kernel = kernel;

//        }
//        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
//        {
//            if (controllerType == null)
//            {
//                throw new HttpException(404, string.Format("当前对{0}的请求不存在", requestContext.HttpContext.Request.Path));
//            }
//            return (IController)_kernel.Resolve(controllerType);

//        }
//        public override void ReleaseController(IController controller)
//        {
//            _kernel.ReleaseComponent(controller);
//            base.ReleaseController(controller);

//        }
//    }
//    public class ControllerInstaller : IWindsorInstaller
//    {
//        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
//        {

//            container.Register(Classes.FromThisAssembly() //在哪里找寻接口或类

//               .BasedOn<IController>() //实现IController接口

//               .If(Component.IsInSameNamespaceAs<HomeController>()) //与HomeController在同一个命名空间

//               .If(t => t.Name.EndsWith("Controller")) //以"Controller"结尾

//               .Configure(c => c.LifestylePerWebRequest()));//每次请求创建一个Controller实例



//            container.Register(
//             Component.For<IUserDal>().ImplementedBy<UserDal>().LifestylePerWebRequest());

//        }

//    }
//}