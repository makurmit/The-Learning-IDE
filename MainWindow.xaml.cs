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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String CurrentFilePath;
        private List<String> FilePaths = new List<string>();
        private List<String> rtfs = new List<string>();
        private List<TabItem> tabs = new List<TabItem>();

        //to do
        //add * on unsaved files
        //change files when tabs change
        //check all methods to make sure rtfs are saved before creating their own
        //refactoring will help

        public MainWindow()
        {
            InitializeComponent();
            TextField.Document.Blocks.Clear();
        }

        private void NewFileButtonClick(object sender, RoutedEventArgs e)
        {
            CreateNewFile NewFileWindow = new CreateNewFile(this);
            NewFileWindow.Show();
        }

        public void AddFile(String FilePath, String FileContent, String fileName)
        {
            SaveTextField();

            TabItem ti = new TabItem
            {
                Header = fileName
            };

            tabs.Add(ti);
            TabBar.Items.Add(ti);

            CurrentFilePath = FilePath;
            FilePaths.Add(CurrentFilePath);
            rtfs.Add(FileContent);

            if (!TextField.IsEnabled)
            {
                TextField.IsEnabled = true;
            }

            ti.IsSelected = true;
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

                        int filesIndex = FilePaths.IndexOf(CurrentFilePath);
                        rtfs[filesIndex] = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd).Text;

                        TextField.Document.Blocks.Clear();
                        TextField.Document.Blocks.Add(new Paragraph(new Run(fileContent)));

                        AddFile(path, fileContent, dlg.SafeFileName);
                        

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

        private void TabBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveTextField();

            TabItem tab = TabBar.SelectedItem as TabItem;

            if (tab != null && tab.Header != null)
            {
                CurrentFilePath = FilePaths[tabs.IndexOf(tab)];
                int index = FilePaths.IndexOf(CurrentFilePath);
                TextField.Document.Blocks.Clear();
                TextField.Document.Blocks.Add(new Paragraph(new Run(rtfs[index])));
            }
        }

        private void SaveTextField()
        {
            //take whatevers in the textfield
            string fileContent = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd).Text;
            if (fileContent != "" && fileContent != null)
            {
                //save it into the rtfs list
                int filesIndex = FilePaths.IndexOf(CurrentFilePath);
                rtfs[filesIndex] = fileContent;
            }
        }
    }
}
