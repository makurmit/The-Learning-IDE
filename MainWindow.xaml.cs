using System;
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
        private int CurrIndex;
        private bool bNewFile;
        private List<String> FilePaths = new List<string>();
        private List<String> rtfs = new List<string>();
        private List<TabItem> tabs = new List<TabItem>();

        private bool bUnsavedChanges;

        public MainWindow()
        {
            //debug.writeline("this is how you console write in wpf");
            InitializeComponent();
            CurrIndex = 0;
            CurrentFilePath = "";
            bNewFile = false;
            bUnsavedChanges = false;
            TextField.Document.Blocks.Clear();
        }

        private void NewFileButtonClick(object sender, RoutedEventArgs e)
        {
            CreateNewFile NewFileWindow = new CreateNewFile(this);
            NewFileWindow.Show();
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            OpenFile();
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

                //string tHeader = "";
                //foreach (TabItem ti in tabs)
                //{
                //    tHeader = ti.Header as string;
                //    if (tHeader.Contains(" * "))
                //    {
                //        tHeader.Replace(" * ", "");
                //        ti.Header = tHeader;
                //        TabBar.Items.Refresh();
                //    }
                //}

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        private void OpenFile()
        {
            string NewPath = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                NewPath = dlg.FileName;

                if (!FilePaths.Contains(NewPath))
                {
                    try
                    {
                        String line;
                        String fileContent = "";
                        StreamReader sr = new StreamReader(NewPath);

                        line = sr.ReadLine();
                        while (line != null)
                        {
                            fileContent += line;
                            line = sr.ReadLine();
                        }

                        sr.Close();

                        AddFile(NewPath, fileContent, dlg.SafeFileName);

                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

            }
        }
        
        public void AddFile(String FilePath, String FileContent, String fileName)
        {
            SaveCurrTab();

            TabItem ti = new TabItem
            {
                Header = fileName
            };

            tabs.Add(ti);
            TabBar.Items.Add(ti);

            CurrentFilePath = FilePath;
            FilePaths.Add(CurrentFilePath);
            rtfs.Add(FileContent);
            CurrIndex = FilePaths.IndexOf(CurrentFilePath);
            bNewFile = true;

            if (!TextField.IsEnabled)
            {
                TextField.IsEnabled = true;
            }

            ti.IsSelected = true;
        }

        private void SaveCurrTab()
        {
            //take whatevers in the textfield
            string fileContent = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd).Text;
            if (fileContent != "" && fileContent != null)
            {
                //save it into the rtfs list
                rtfs[CurrIndex] = fileContent;
            }
        }

        private void TabBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!bNewFile)
            {
                //if it's not a new tab save the current tab and adjust the currindex and currfilepath
                SaveCurrTab();
                CurrIndex = TabBar.SelectedIndex;
                CurrentFilePath = FilePaths[CurrIndex];
            }
            else
            {
                bNewFile = false;
            }

            TextField.Document.Blocks.Clear();
            TextField.Document.Blocks.Add(new Paragraph(new Run(rtfs[CurrIndex])));
        }

        private void TabBar_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if over current tab wip
            if (tabs.Count > 0)
            {
                tabs.RemoveAt(CurrIndex);
                rtfs.RemoveAt(CurrIndex);
                FilePaths.RemoveAt(CurrIndex);

                if (CurrIndex > 0)
                {
                    CurrIndex -= 1;
                }

                CurrentFilePath = FilePaths[CurrIndex];
            }
        }

        //private void UnsavedChanges(object sender, TextChangedEventArgs e)
        //{
        //    //first time opening
        //    if (TextField.IsEnabled)
        //    {
        //        string tHeader = tabs[CurrIndex].Header as string;
        //        if (!tHeader.Contains(" * "))
        //        {
        //            bUnsavedChanges = true;

        //            tabs[CurrIndex].Header += " * ";
        //        }
        //    }
        //}
    }
}
