using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputString : Form
    {
        public new string Text;
        public bool Exists = false;
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
            IOs.UpdateSelectedLbItem();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                IOs.Add(this);
            else
                IOs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: text: \""+Text+"\"";
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
