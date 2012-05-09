using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SMO.Core.Tests;

namespace SMO.Core
{
    public static class IoC
    {
        private static IUnityContainer container; 

        static IoC()
        {
            container = new UnityContainer();
            RegisterSingleton<ISystemClock, SystemClock>();
            RegisterSingleton<IQueuingSystem, QueuingSystem>();
            RegisterSingleton<ISystemGenerator, SystemGenerator>();
            RegisterSingleton<IDisciplineQueuingSystem, FIFOQueuingSystem>();
            RegisterSingleton<ISystemStatistics, SystemStatistics>();
            RegisterSingleton<IEngine, Engine>();
            RegisterSingleton<ISystemDevices, SystemDevices>();

            container.RegisterType<IDevice, Device>();
        }

        private static void RegisterSingleton<TInterface, TClass> () where TClass : TInterface {
            container.RegisterType<TInterface, TClass>(new ContainerControlledLifetimeManager());
        }

        public static TInterface Resolve<TInterface>()
        {
            return container.Resolve<TInterface>();
        }
    }
}
