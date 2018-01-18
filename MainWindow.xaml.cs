﻿using System;
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
using The_Learning_IDE.Models;

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
        public List<MMTabItem> tabs = new List<MMTabItem>();

        public MainWindow()
        {
            //debug.writeline("this is how you console write in wpf");
            InitializeComponent();
            CurrIndex = 0;
            CurrentFilePath = "";
            bNewFile = false;
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
            String StringInfo = tabs[CurrIndex].rtf;

            SaveFile(path, StringInfo, CurrIndex);
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

                bool exists = false;
                foreach (MMTabItem ti in tabs){
                    if (ti.filePath.Equals(NewPath))
                    {
                        exists = true;
                    }
                }

                if (!exists)
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

                        string extension = System.IO.Path.GetExtension(NewPath).ToUpper();
                        Language l;

                        switch (extension)
                        {
                            case ".CS":
                                l = The_Learning_IDE.Language.Csharp;
                                break;
                            case ".JAVA":
                                l = The_Learning_IDE.Language.Java;
                                break;
                            case ".JS":
                                l = The_Learning_IDE.Language.JavaScript;
                                break;
                            case ".PY":
                                l = The_Learning_IDE.Language.Python;
                                break;
                            case ".RB":
                                l = The_Learning_IDE.Language.Ruby;
                                break;
                            default:
                                l = The_Learning_IDE.Language.Text;
                                break;
                        }

                        AddFile(NewPath, fileContent, dlg.SafeFileName, l);

                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

            }
        }
        
        public void AddFile(String FilePath, String FileContent, String fileName, Language l)
        {
            SaveCurrTab();

            MMTabItem ti = new MMTabItem
            {
                Header = fileName,
                filePath = FilePath,
                rtf = FileContent,
                fileName = fileName,
                unSavedChanges = false,
                fileLanguage = l
            };

            tabs.Add(ti);
            TabBar.Items.Add(ti);

            CurrentFilePath = FilePath;
            CurrIndex = tabs.IndexOf(ti);
            bNewFile = true;

            if (!TextField.IsEnabled)
            {
                TextField.IsEnabled = true;
            }

            ti.IsSelected = true;
        }

        public void SaveFile(string path, string StringInfo, int tabIndex)
        {
            try
            {

                using (FileStream fs = File.OpenWrite(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(StringInfo);
                    fs.Write(info, 0, info.Length);
                }

                tabs[tabIndex].unSavedChanges = false;

                string tHeader = tabs[CurrIndex].Header as string;
                if (tHeader.Contains(" * "))
                {
                    tHeader = tHeader.Replace(" * ", "");
                    tabs[CurrIndex].Header = tHeader;
                    TabBar.Items.Refresh();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void SaveCurrTab()
        {
            //take whatevers in the textfield
            string fileContent = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd).Text;
            if (fileContent != "" && fileContent != null)
            {
                //save it into the rtfs list
                tabs[CurrIndex].rtf = fileContent;
            }
        }

        private void TabBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!bNewFile)
            {
                //if it's not a new tab save the current tab and adjust the currindex and currfilepath
                SaveCurrTab();
                CurrIndex = TabBar.SelectedIndex;
                CurrentFilePath = tabs[CurrIndex].filePath;
            }
            else
            {
                bNewFile = false;
            }

            TextField.Document.Blocks.Clear();
            TextField.Document.Blocks.Add(new Paragraph(new Run(tabs[CurrIndex].rtf)));
        }

        private void TabBar_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if over current tab wip
            //if (tabs.Count > 0)
            //{
            //    tabs.RemoveAt(CurrIndex);

            //    if (CurrIndex > 0)
            //    {
            //        CurrIndex -= 1;
            //    }

            //    CurrentFilePath = tabs[CurrIndex].filePath;
            //}
        }

        private void UnsavedChanges(object sender, TextChangedEventArgs e)
        {
            //first time opening
            if (TextField.IsEnabled)
            {
                tabs[CurrIndex].unSavedChanges = true;
                string theHeader = tabs[CurrIndex].Header as string;
                if (!theHeader.Contains(" * "))
                {
                    tabs[CurrIndex].Header += " * ";
                }

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool changes = false;
            foreach (MMTabItem ti in tabs)
            {
                if (ti.unSavedChanges)
                {
                    changes = true;
                }
            }

            if (changes)
            {
                e.Cancel = true;
                SaveChanges sc = new SaveChanges(this);
                sc.Show();
            }
        }
    }
}
