using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputRandomNumber : Form
    {
        public bool Decimal;
        public bool Exists = false;
        public decimal Max;
        public decimal Min;
        private static int _idCounter=0;
        public readonly int ID;

        public InputRandomNumber()
        {
            InitializeComponent();
            Min = numMin.Value;
            Max = numMax.Value;
            Decimal = !cbNoDecimal.Checked;
            _idCounter++;
            ID = _idCounter;
        }

        public InputRandomNumber(decimal min, decimal max, bool generateDecimal,int id)
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
            ID = id;
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            if (numMax.Value <= numMin.Value)
            {
                numMax.Value = numMin.Value + 1;
                labErr.Text = "MAX nemůže být menší než MIN!";
            }
            else
            {
                labErr.Text = "";
                Max = numMax.Value;
            }
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            if (numMin.Value >= numMax.Value)
            {
                numMin.Value = numMax.Value + -1;
                labErr.Text = "MIN nemůže být větší než MAX!";
            }
            else
            {
                labErr.Text = "";
                Min = numMin.Value;
            }
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
            if (Decimal)
                return "VSTUP: náhodné desetiné číslo od " + Min + " do " + Max;
            return "VSTUP: náhodné celé číslo od " + Min + " do " + Max;
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
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}