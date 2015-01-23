using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputNumber : Form
    {
        public bool Exists = false;
        public decimal Value;

        public OutputNumber()
        {
            InitializeComponent();
            Value = numeric.Value;
        }

        public OutputNumber(decimal value)
        {
            InitializeComponent();
            Value = value;
            numeric.Value = value;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.UpdateSelectedLbItem();
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
            return "VÝSTUP: číslo " + Value;
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Value = numeric.Value;
        }

        private void OutputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}
