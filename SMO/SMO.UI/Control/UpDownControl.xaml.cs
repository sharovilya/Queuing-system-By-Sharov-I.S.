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

namespace SMO.UI.Control
{
	/// <summary>
	/// Interaction logic for UpDownControl.xaml
	/// </summary>
	public partial class UpDown : UserControl
	{
	    public int Value { 
            get
            {
                return Int32.Parse((string)GetValue(ValueProperty));
            }
	        set
	        {
	            SetValue(ValueProperty, value.ToString());
	        }
        }

		public UpDown()
		{
			this.InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Value - 1 > 0)
                Value--;
        }

        public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(string), typeof(UpDown), new FrameworkPropertyMetadata(ChangeText));

        private static void ChangeText(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            
            ((UpDown)source).UpdateText(e.NewValue.ToString());
        }

        private void UpdateText(string newText)
        {
            txtValue.Text = newText;
        }
	}
}