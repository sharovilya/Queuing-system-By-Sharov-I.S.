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
using SMO.UI.Views;
using Microsoft.Practices.Unity;

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for StatisticsControl.xaml
	/// </summary>
	public partial class StatisticsControl : UserControl
	{
		public StatisticsControl()
		{
			this.InitializeComponent();
		   // DataContext = App.Container.Resolve<StatisticsView>();
		}
	}
}