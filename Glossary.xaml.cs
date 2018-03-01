using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
	/// Interaction logic for Glossary.xaml
	/// </summary>
	public partial class Glossary : Window
	{
		private string FileContent = File.ReadAllText(@"C:\school\Capstone\PROJECT\lessons\Glossary\Glossary.txt");

		public Glossary()
		{
			InitializeComponent();
			TheTextBox.Text = FileContent;
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			string query = SearchBox.Text;
			string[] file = FileContent.Split('\n');
            string key = "";
            string value = "";
            bool bkey = true;
            Dictionary<string, string> gloss = new Dictionary<string, string>();

			foreach (string s in file)
			{
				if (s.Equals("-------------------------------------------------\r"))
				{
                    gloss.Add(key, value);

					key = "";
					value = "";
                    bkey = true;
				}
				else
				{
                    if (bkey)
                    {
                        bkey = false;
                        key = s.ToUpper();
                    }else
                    {
                        value += s;
                    }
				}
			}

            query = query.ToUpper() + "\r";

            if (gloss.ContainsKey(query))
            {
                TheTextBox.Text = SearchBox.Text + '\n' + gloss[query];
            }
		}

		private void Refresh_Click(object sender, RoutedEventArgs e)
		{
			TheTextBox.Text = FileContent;
			SearchBox.Text = "";
		}

	}
}
