using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace The_Learning_IDE
{
	/// <summary>
	/// Interaction logic for fundamentals.xaml
	/// </summary>
	public partial class fundamentals : Window
	{
		public fundamentals()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string buttonPressed = (sender as Button).Content.ToString();
			switch (buttonPressed)
			{
				case "C#":
                    TheBox.Text = Properties.Resources.Csharp_Fundamentals;
					break;
				case "Java":
                    TheBox.Text = Properties.Resources.Java_Fundamentals;
					break;
				case "Python":
                    TheBox.Text = Properties.Resources.Python_Fundamentals;
					break;
				case "Ruby":
                    TheBox.Text = Properties.Resources.Ruby_Fundamentals;
					break;
			}
		}
	}
}
