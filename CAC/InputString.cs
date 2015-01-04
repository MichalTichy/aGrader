using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC
{
    public partial class InputString : Form
    {
        public string text;
        public bool exists = false;
        public InputString()
        {
            InitializeComponent();
        }
        public InputString(string text)
        {
            InitializeComponent();
            this.text = text;
            tbString.Text = text;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            IOs.UpdateSelectedLBItem();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!exists)
                IOs.Add(this);
            else
                IOs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: text: \""+text+"\"";
        }

        private void InputString_Activated(object sender, EventArgs e)
        {
            if (exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void tbString_TextChanged(object sender, EventArgs e)
        {
            text = tbString.Text;
        }
    }
}
