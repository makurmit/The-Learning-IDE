using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace The_Learning_IDE.Models
{
    public class MMTabItem : TabItem
    {
        /*
         * icons (NoChanges/UnsavedChanges)
         */

        private string Rtf;
        private string FilePath;
        private string FileName;
        private bool UnSavedChanges;
        private Language FileLanguage;

        //Contents of it's rich text field
        public string rtf
        {
            get { return Rtf; }
            set { Rtf = value; FieldChanged(); }
        }

        //Full path (C://desktop/example.txt)
        public string filePath
        {
            get { return FilePath; }
            set { FilePath = value; FieldChanged(); }
        }
        
        //File name (example.txt)
        public string fileName
        {
            get { return FileName; }
            set { FileName = value; FieldChanged(); }
        }

        //Determines if there are unsaved changes
        public bool unSavedChanges
        {
            get { return UnSavedChanges; }
            set { UnSavedChanges = value; FieldChanged(); }
        }

        public Language fileLanguage
        {
            get { return FileLanguage; }
            set { FileLanguage = value; FieldChanged(); }
        }


        //public static void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Debug.WriteLine("tab down");
        //}



        public event PropertyChangedEventHandler PropertyChanged;
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
