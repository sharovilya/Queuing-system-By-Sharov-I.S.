using System;
using System.Collections.Generic;
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
using Microsoft.Practices.Unity;

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for GraphGenerator.xaml
	/// </summary>
	public partial class GraphGenerator : UserControl
	{
	    private ISystemClock clock;
	    private ISystemGenerator generator;

		public GraphGenerator()
		{
			this.InitializeComponent();

		    clock = App.Container.Resolve<ISystemClock>();
		    generator = App.Container.Resolve<ISystemGenerator>();

            clock.TickEvent += clock_TickEvent;

        //    LineG
		}

        void clock_TickEvent(object sender, EventArgs e)
        {
            
        }
	}
}