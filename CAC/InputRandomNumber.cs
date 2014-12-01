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
    public partial class InputRandomNumber : Form
    {
        public decimal max;
        public decimal min;
        public bool Decimal;

        public InputRandomNumber()
        {
            InitializeComponent();
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            if (numMax.Value <= numMin.Value)
            {
                numMax.Value = numMin.Value + 1;
                labErr.Text = "MAX nemůže být menší než MIN!";
            }
            else
                labErr.Text = "";
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            if (numMin.Value >= numMax.Value)
            {
                numMin.Value = numMax.Value + -1;
                labErr.Text = "MIN nemůže být větší než MAX!";
            }
            else
                labErr.Text = "";
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            IOs.Add(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            if (Decimal)
                return "VSTUP: náhodné desetiné číslo od " + min + " do " + max;
            else
                return "VSTUP: náhodné celé číslo od " + min + " do " + max;
        }

        private void numMin_Validated(object sender, EventArgs e)
        {
            min = numMin.Value;
        }

        private void numMax_Validated(object sender, EventArgs e)
        {
            max = numMax.Value;
        }

        private void cbNoDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNoDecimal.Checked)
            {
                Decimal = false;
                numMin.DecimalPlaces = 0;
                numMin.DecimalPlaces = 0;
            }
            else
            {
                Decimal = true;
                numMin.DecimalPlaces = 3;
                numMin.DecimalPlaces = 3;
            }

        }
    }
}
