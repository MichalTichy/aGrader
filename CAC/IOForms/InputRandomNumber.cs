using System;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class InputRandomNumber : InputOutputForm
    {
        public static int IdCounter { get; private set; }
        public string Id;
        public bool Decimal;
        public decimal Max;
        public decimal Min;

        public InputRandomNumber()
        {
            InitializeComponent();
            Min = numMin.Value;
            Max = numMax.Value;
            Decimal = !cbNoDecimal.Checked;
            IdCounter++;
            Id = "X" + IdCounter;
        }

        public InputRandomNumber(decimal min, decimal max, bool generateDecimal, string id)
        {
            InitializeComponent();
            numMin.Value = numMin.Minimum; //HACK to bypass control for min>max and visaversa
            numMax.Value = numMax.Maximum;
            Min = min;
            Max = max;
            Decimal = !generateDecimal;
            numMin.Value = min;
            numMax.Value = max;
            Decimal = generateDecimal;
            Id = id;
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            if (numMax.Value <= numMin.Value)
            {
                numMax.Value = numMin.Value + 1;
                LabErr.Text = Resources.InputRandomNumber_MaxCantBeGreatherThanMin;
            }
            else
            {
                LabErr.Text = "";
                Max = numMax.Value;
            }
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            if (numMin.Value >= numMax.Value)
            {
                numMin.Value = numMax.Value + -1;
                LabErr.Text = Resources.InputRandomNumber_MinCantBeGreatherThanMax;
            }
            else
            {
                LabErr.Text = "";
                Min = numMin.Value;
            }
        }

        public override string ToString()
        {
            return string.Format(Decimal ? Resources.IOFDescription_InputRandomDecimalNumber : Resources.IOFDescription_InputRandomNumber, Min, Max);
        }

        private void cbNoDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoDecimal.Checked)
            {
                Decimal = false;
                numMin.DecimalPlaces = 0;
                numMax.DecimalPlaces = 0;
            }
            else
            {
                Decimal = true;
                numMin.DecimalPlaces = 3;
                numMax.DecimalPlaces = 3;
            }
        }

        private void InputRandomNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }
    }
}
