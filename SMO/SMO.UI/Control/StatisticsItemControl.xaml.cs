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

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for StatisticsItemControl.xaml
	/// </summary>
	public partial class StatisticsItemControl : UserControl
	{
		public StatisticsItemControl()
		{
			this.InitializeComponent();
		}

	    public static readonly DependencyProperty DescriptionProperty =
	        DependencyProperty.Register("Description", typeof (string), typeof (StatisticsItemControl), new PropertyMetadata(default(string), OnUpdateDescr));

	    private static void OnUpdateDescr(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
            ((StatisticsItemControl)d).UpdateDescr((string)e.NewValue);
	    }

	    private void UpdateDescr(string newValue)
	    {
	        txtDescription.Text = newValue;
	    }

	    public string Description
	    {
	        get { return (string) GetValue(DescriptionProperty); }
	        set { SetValue(DescriptionProperty, value); }
	    }


	    public static readonly DependencyProperty ValueProperty =
	        DependencyProperty.Register("Value", typeof (double), typeof (StatisticsItemControl), new PropertyMetadata(0.0, OnUpdateValue));

	    private static void OnUpdateValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
            ((StatisticsItemControl)d).UpdateValue((double)e.NewValue);

	    }

	    private void UpdateValue(double newValue)
	    {
	        txtValue.Text = (Math.Round(newValue, 3)).ToString();
	    }

	    public double Value
	    {
	        get { return (double) GetValue(ValueProperty); }
	        set { SetValue(ValueProperty, value); }
	    }

	}
}