using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputString : CAC.IO_Forms.InputString
    {
        public OutputString()
        {
            InitializeComponent();
        }

        public OutputString(string text) : base(text)
        {
            
        }
    }
}
