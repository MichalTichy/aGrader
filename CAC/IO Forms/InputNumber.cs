using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputNumber : Form
    {
        public decimal Value;

        public bool Exists = false;
        public InputNumber()
        {
            InitializeComponent();
            Value = numeric.Value;
        }

        public InputNumber(decimal value)
        {
            InitializeComponent();
            Value = value;
            numeric.Value = value;
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
            return "VSTUP: číslo " + Value;
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Value = numeric.Value;
        }

        private void InputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}
