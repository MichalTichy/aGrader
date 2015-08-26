using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputNumber : CAC.IO_Forms.InputNumber
    {
        public OutputNumber()
        {
            InitializeComponent();
        }

        public OutputNumber(decimal value) : base(value)
        {
        }
    }
}
