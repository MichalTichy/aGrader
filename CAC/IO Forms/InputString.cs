using System;

namespace aGrader.IO_Forms
{
    public partial class InputString : InputOutputForm
    {
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
