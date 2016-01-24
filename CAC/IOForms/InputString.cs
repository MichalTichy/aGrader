using System;
using aGrader.Properties;

namespace aGrader.IOForms
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
            return string.Format(Resources.IOFDescription_InputString, Text);
        }

        private void InputString_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }

        private void tbString_TextChanged(object sender, EventArgs e)
        {
            Text = tbString.Text;
        }
    }
}
