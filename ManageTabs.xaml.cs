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
using The_Learning_IDE.Models;

namespace The_Learning_IDE
{
    /// <summary>
    /// Interaction logic for ManageTabs.xaml
    /// </summary>
    public partial class ManageTabs : Window
    {
        public ManageTabs(List<MMTabItem> tabs)
        {
            InitializeComponent();

            foreach (MMTabItem ti in tabs)
            {
                Label name = new Label()
                {
                    Content = ti.fileName,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Height = 20
                };
                theGrid.Items.Add(name);

                //Button Bx = new Button()
                //{
                //    Content = "x",
                //    Name = ti.fileName,
                //    Width = 20,
                //    Height = 20,
                //    VerticalAlignment = VerticalAlignment.Center,
                //    HorizontalAlignment = HorizontalAlignment.Left
                //};
                //Bx.Click += new RoutedEventHandler(CloseTabClick);

                //theGrid.Children.Add(Bx);
            }
        }


        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
