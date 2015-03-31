using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAC.Math;

namespace CAC.IO_Forms
{
    //todo přejmenovat tbjahoda
    public partial class OutputNumberBasedOnRandomInput : Form
    {
        public bool Exists = false;
        public string jahoda; //todo prejmenovat

        public OutputNumberBasedOnRandomInput()
        {
            InitializeComponent();
        }

        public OutputNumberBasedOnRandomInput(string jahoda)
        {
            InitializeComponent();
            tbJahoda.Text = jahoda;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!EquationValidator.IsValid(tbJahoda.Text) && Exists)
            {
                DialogResult msg = MessageBox.Show("Jahoda nemá správný formát! \nPokud si přejete pokračovat objekt bude smazán.","Upozornění",MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
            }
            else if (EquationValidator.GetUnknownsFromEquation(tbJahoda.Text).Count!=lbNumbers.Items.Count && Exists)
            {
                DialogResult msg = MessageBox.Show("V jahodě se nachází neexistující neznámé! \nPokud si přejete pokračovat objekt bude smazán.", "Upozornění", MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
            }
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private void butAddOrDelete_Click(object sender, EventArgs e)
        {
            if (!Exists)
                if (EquationValidator.IsValid(tbJahoda.Text))
                {
                    InputsOutputs.Add(this);
                }
                else
                {
                    MessageBox.Show("Musíte zdat platnou jahodu."); //todo přepsat
                    return;
                }
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VÝSTUP: Číslo závyslé na vygenerovaných hodnotách"; //možná předělat?
        }

        private void tbJahoda_Leave(object sender, EventArgs e)
        {
            if (!EquationValidator.IsValid(tbJahoda.Text) && tbJahoda.Text.Length > 0)
                tbJahoda.ForeColor = Color.Red;
            else
            {
                tbJahoda.ResetForeColor();
                jahoda = tbJahoda.Text;
            }
        }

        private void OutputNumberBasedOnRandomInput_Activated(object sender, EventArgs e)
        {
            if (Exists)
                butAddOrDelete.Text = "Smazat";
            FillLbNumbers(); //todo prejmenovat
        }

        private void FillLbNumbers()
        {
            lbNumbers.Items.Clear();
            foreach (InputRandomNumber inputRandomNumber in InputsOutputs.GetList(typeof(InputRandomNumber)))
            {
                lbNumbers.Items.Add(inputRandomNumber.ToString()+" ZN: X"+inputRandomNumber.ID);
            }
        }
    }
}