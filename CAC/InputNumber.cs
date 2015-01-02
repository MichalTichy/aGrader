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
    public partial class InputNumber : Form
    {
        public decimal Value;

        public bool exists = false;
        public InputNumber()
        {
            InitializeComponent();
            Value = numeric.Value;
        }

        public InputNumber(decimal value)
        {
            InitializeComponent();
            this.Value = value;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
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
            return "VSTUP: číslo " + Value;
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Value = numeric.Value;
        }

        private void InputNumber_Activated(object sender, EventArgs e)
        {
            if (exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}
