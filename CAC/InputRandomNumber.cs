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

        public bool exists = false;

        public InputRandomNumber()
        {            
            InitializeComponent();
            min = numMin.Value;
            max = numMax.Value;
            Decimal = !cbNoDecimal.Checked;
        }

        public InputRandomNumber(decimal min,decimal max,bool generateDecimal)
        {
            InitializeComponent();
            numMin.Value = numMin.Minimum; //HACK to bypass control for min>max and visaversa
            numMax.Value = numMax.Maximum;
            this.min = min;
            this.max = max;
            this.Decimal = !generateDecimal;
            numMin. Value = min;
            numMax.Value = max;
            Decimal = generateDecimal;
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
                max = numMax.Value;
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
                min = numMin.Value;
            }
                
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
            if (Decimal)
                return "VSTUP: náhodné desetiné číslo od " + min + " do " + max;
            else
                return "VSTUP: náhodné celé číslo od " + min + " do " + max;
        }

        private void cbNoDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNoDecimal.Checked)
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
            if (exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}
