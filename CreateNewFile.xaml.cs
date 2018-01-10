using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace The_Learning_IDE
{
    /// <summary>
    /// Interaction logic for CreateNewFile.xaml
    /// </summary>
    public partial class CreateNewFile : Window
    {
        private MainWindow theMainWindow;

        public CreateNewFile(MainWindow mw)
        {
            InitializeComponent();
            theMainWindow = mw;
        }

        private void BrowseDirectoryClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();

            DialogResult result = dlg.ShowDialog();

            if (!result.Equals(""))
            {
                DirectoryBox.Text = dlg.SelectedPath;
            }

        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            Language l = new Language();
            String filename = "";
            String directory = "";
            String extension = "";
            bool valid = true;

            #region button check
            if (CSButton.IsChecked == true)
            {
                l = The_Learning_IDE.Language.Csharp;
                extension = ".cs";
            }
            else if (JavaButton.IsChecked == true)
            {
                l = The_Learning_IDE.Language.Java;
                extension = ".java";
            }
            else if (JavaScriptButton.IsChecked == true)
            {
                l = The_Learning_IDE.Language.JavaScript;
                extension = ".js";
            }
            else if (PythonButton.IsChecked == true)
            {
                l = The_Learning_IDE.Language.Python;
                extension = ".py";
            }
            else if (RubyButton.IsChecked == true)
            {
                l = The_Learning_IDE.Language.Ruby;
                extension = ".rb";
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
                directory += @"\";
                string path = directory + filename + extension;

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("");
                        fs.Write(info, 0, info.Length);
                    }

                    theMainWindow.AddFile(path);

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                this.Close();
            }
            else
            {
                WarningError.Content = "Please input a filename, directory, and language";
            }
        }


    }
}
