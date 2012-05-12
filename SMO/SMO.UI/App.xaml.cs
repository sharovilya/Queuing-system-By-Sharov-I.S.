using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using SMO.Core;
using SMO.UI.Views;

namespace SMO.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer Container = new UnityContainer(); 

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            RegisterSingleton<ISystemClock, SystemClock>();
            RegisterSingleton<IQueuingSystem, QueuingSystem>();
            RegisterSingleton<ISystemGenerator, SystemGenerator>();
            RegisterSingleton<ISystemDiscipline, Fifo>();
            RegisterSingleton<ISystemStatistics, SystemStatistics>();
            RegisterSingleton<IEngine, Engine>();
            RegisterSingleton<ISystemDevices, SystemDevices>();
            RegisterSingleton<ISystemConfiguration, SystemConfiguration>();
        

            RegisterSingleton<DisciplineView>();
            RegisterSingleton<DevicesView>();
            RegisterSingleton<RunView>();
            RegisterSingleton<ConfigurationView>();


            MainWindow main = new MainWindow();
            main.Show();
        }

        public void RegisterSingleton<TInterface, TClass>() where TClass : TInterface
        {
            Container.RegisterType<TInterface, TClass>(new ContainerControlledLifetimeManager());
        }

        public void RegisterSingleton<TClass>()
        {
            Container.RegisterType<TClass>(new ContainerControlledLifetimeManager());
        }

        public TInterface Resolve<TInterface>()
        {
            return Container.Resolve<TInterface>();
        }
    }
}
