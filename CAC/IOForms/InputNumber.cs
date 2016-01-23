using System;

namespace aGrader.IOForms
{
    public partial class InputNumber : InputOutputForm
    {
        public decimal Value;

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
