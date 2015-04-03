using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputString : Form
    {
        public bool Exists = false;
        public string Text;

        public InputString()
        {
            InitializeComponent();
        }

        public InputString(string text)
        {
            InitializeComponent();
            Text = text;
            tbString.Text = text;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                InputsOutputs.Add(this);
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: text: \"" + Text + "\"";
        }

        private void InputString_Activated(object sender, EventArgs e)
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