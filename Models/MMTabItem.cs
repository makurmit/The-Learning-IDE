using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Learning_IDE.Models
{
    class MMTabItem : TabItem
    {
        /*
         * icons (NoChanges/UnsavedChanges
         */

        //Contents of it's rich text field
        public string rtf
        {
            get;
            set;
        }

        //Full path (C://desktop/example.txt)
        public string filePath
        {
            get;
            set;
        }
        
        //File name (example.txt)
        public string fileName
        {
            get;
            set;
        }

        //Determines if there are unsaved changes
        public bool unSavedChanges
        {
            get;
            set;
        }

        public Language fileLanguage
        {
            get;
            set;
        }

    }
}
