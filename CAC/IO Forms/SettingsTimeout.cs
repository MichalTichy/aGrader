using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace aGrader.IO_Forms
{
    public partial class SettingsTimeout : InputOutputForm
    {
        public int Timeout;
        public SettingsTimeout()
        {
            InitializeComponent();
            Timeout = (int)numericUpDown1.Value;
        }

        public SettingsTimeout(int timeout)
        {
            InitializeComponent();
            numericUpDown1.Value = timeout;
            Timeout = (int)numericUpDown1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Timeout = (int)numericUpDown1.Value;
        }

        public override string ToString()
        {
            return $"Maximální doba pro běh programu: {Timeout}";
        }
    }
}
