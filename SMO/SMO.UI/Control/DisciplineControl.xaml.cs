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
using SMO.UI.Views;
using Microsoft.Practices.Unity;

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for DisciplineControl.xaml
	/// </summary>
	public partial class DisciplineControl : UserControl
	{
		public DisciplineControl()
		{
			this.InitializeComponent();

        //    ISystemClock clock = new SystemClock();
        //    ISystemDiscipline d = new Fifo();
        //    d.Put(new Request(1,1,1));
        //    d.Put(new Request(2, 2, 2));
        //    d.Put(new Request(3, 3, 3));
        //    d.Put(new Request(4, 4, 4));
        //    DataContext = new DisciplineView(d, clock);
		    DataContext = App.Container.Resolve<DisciplineView>();
		}
	}
}