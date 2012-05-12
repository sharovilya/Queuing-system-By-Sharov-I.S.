using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SMO.Core;
using SMO.UI.Views;
using Microsoft.Practices.Unity;

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for DevicesControl.xaml
	/// </summary>
	public partial class DevicesControl : UserControl
	{
		public DevicesControl()
		{
			this.InitializeComponent();

            //ISystemClock clock = new SystemClock();
            //ISystemDevices d = new SystemDevices(clock);
            //d.Add(new Device(clock));
            //d.Add(new Device(clock));
            //d.Add(new Device(clock));
            //d.Add(new Device(clock));
            //d.Children.First().Take(Request.New(1,1,1));

            //DataContext = new DevicesView(clock, d);

		    DataContext = App.Container.Resolve<DevicesView>();
		}
	}
}