using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputString : Form
    {
        public bool Exists = false;
        public string Text;

        public OutputString()
        {
            InitializeComponent();
        }

        public OutputString(string text)
        {
            InitializeComponent();
            Text = text;
            tbString.Text = text;
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                InputsOutputs.Add(this);
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        public override string ToString()
        {
            return "VÝSTUP: text: \"" + Text + "\"";
        }

        private void OutputString_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void tbString_TextChanged(object sender, EventArgs e)
        {
            Text = tbString.Text;
        }
    }
}
