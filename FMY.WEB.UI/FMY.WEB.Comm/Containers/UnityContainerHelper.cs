using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;

using FMY.WEB.IDao;
using FMY.WEB.IbatisDao;


namespace FMY.WEB.Comm.Containers
{
    public class UnityContainerHelper
    {

        public static readonly IUnityContainer _container;
        static UnityContainerHelper()
        {
            _container = new UnityContainer();

            _container.RegisterType<IUserDao, UserDao>();
        }

        public static T GetInstance<T>(T targetType)
        {
            return _container.Resolve<T>();
        }
    }


    
}
