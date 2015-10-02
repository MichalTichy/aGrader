using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class ActionLoadOutputsFromTextFile : CAC.IO_Forms.InputTextFile
    {
        public ActionLoadOutputsFromTextFile() : base()
        {
            InitializeComponent();
        }

        public ActionLoadOutputsFromTextFile(string path)  : base(path)
        {
        }


        public override string ToString()
        {
            return "AKCE: načtení výstupů z " + System.IO.Path.GetFileName(Path);
        }
    }
}
