using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Learning_IDE
{
    public delegate void OpenWindow(bool b);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<String> FilePaths = new List<string>();
        private String CurrentFilePath;
        /*
         * read files to see if there are any changes: if so add "*" to the tab.
         * 
         * Change save file to check tab order.
        */


        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFileButtonClick(object sender, RoutedEventArgs e)
        {
            CreateNewFile NewFileWindow = new CreateNewFile(this);
            NewFileWindow.Show();
        }

        public void AddFile(String FilePath)
        {
            CurrentFilePath = FilePath;
            FilePaths.Add(CurrentFilePath);
            if (!TextField.IsEnabled)
            {
                TextField.IsEnabled = true;
            }
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            string path = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path = dlg.FileName;

                if (!FilePaths.Contains(path))
                {
                    try
                    {
                        String line;
                        String fileContent = "";
                        StreamReader sr = new StreamReader(path);

                        line = sr.ReadLine();
                        while (line != null)
                        {
                            fileContent += line;
                            line = sr.ReadLine();
                        }

                        sr.Close();

                        TextField.Document.Blocks.Clear();
                        TextField.Document.Blocks.Add(new Paragraph(new Run(fileContent)));

                        AddFile(path);
                        //add tab

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

            }
        }

        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            String path = CurrentFilePath;
            String StringInfo = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd).Text;

            try
            {

                using (FileStream fs = File.OpenWrite(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(StringInfo);
                    fs.Write(info, 0, info.Length);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void LessonClick(object sender, RoutedEventArgs e)
        {
            string path = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path = dlg.FileName;

                try
                {
                    String line;
                    String fileContent = "";
                    StreamReader sr = new StreamReader(path);

                    line = sr.ReadLine();
                    while (line != null)
                    {
                        fileContent += line;
                        line = sr.ReadLine();
                    }

                    sr.Close();

                    LessonBox.Text = fileContent;

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}
