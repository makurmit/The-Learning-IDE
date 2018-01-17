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
    /// Interaction logic for SaveChanges.xaml
    /// </summary>
    public partial class SaveChanges : Window
    {

        private MainWindow theMW;

        public SaveChanges(MainWindow mw)
        {
            InitializeComponent();
            theMW = mw;
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void YesClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
