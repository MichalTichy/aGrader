using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class ActionLoadOutputsFromTextFile : CAC.IO_Forms.InputOutputForm
    {
        public ActionLoadOutputsFromTextFile()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return "AKCE: Načti výstupy ze souboru.";
        }
    }
}
