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
            IOMethods.IO.Add(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: náhodné číslo od " + numMin + " do " + numMax;
        }
    }
}
