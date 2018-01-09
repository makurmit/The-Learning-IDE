using System;
using System.Windows;

namespace The_Learning_IDE
{
    /// <summary>
    /// Interaction logic for CreateNewFile.xaml
    /// </summary>
    public partial class CreateNewFile : Window
    {
        public CreateNewFile()
        {
            InitializeComponent();
        }

        private void BrowseDirectoryClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            Language l = new Language();
            String filename = "";
            String directory = "";
            bool valid = true;

            #region button check
            if (CSButton.IsEnabled)
            {
                l = The_Learning_IDE.Language.Csharp;
            }
            else if (JavaButton.IsEnabled)
            {
                l = The_Learning_IDE.Language.Java;
            }
            else if (JavaScriptButton.IsEnabled)
            {
                l = The_Learning_IDE.Language.JavaScript;
            }
            else if (PythonButton.IsEnabled)
            {
                l = The_Learning_IDE.Language.Python;
            }
            else if (RubyButton.IsEnabled)
            {
                l = The_Learning_IDE.Language.Ruby;
            }
            else
            {
                valid = false;
            }
            #endregion

            if (FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }
            else
            {
                valid = false;
            }

            if (DirectoryBox.Text != "")
            {
                directory = DirectoryBox.Text;
            }
            else
            {
                valid = false;
            }

            if (valid)
            {
                //create new file
                //close window
            }
            else
            {
                WarningError.Content = "Please input a filename, directory, and language";
            }
        }

    }
}
