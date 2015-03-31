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
        private bool isJahodaValid;//todo prejmenovat
        private List<string> _existingUnknowns=new List<string>(); 
        public OutputNumberBasedOnRandomInput()
        {
            InitializeComponent();
            FillLbNumbers();
        }

        public OutputNumberBasedOnRandomInput(string jahoda)
        {
            InitializeComponent();
            tbJahoda.Text = jahoda;
            FillLbNumbers();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!isJahodaValid && Exists)
            {
                DialogResult msg = MessageBox.Show("Jahoda nemá správný formát! \nPokud si přejete pokračovat objekt bude smazán.","Upozornění",MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
            }
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private void butAddOrDelete_Click(object sender, EventArgs e)
        {
            if (!Exists)
                if (isJahodaValid)
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
            isJahodaValid = EquationValidator.IsValid(tbJahoda.Text,_existingUnknowns);
            if (!isJahodaValid)
            {  
                tbJahoda.ForeColor = Color.Red;
                isJahodaValid = false;
            }
            else
            {
                tbJahoda.ResetForeColor();
                jahoda = tbJahoda.Text;
                isJahodaValid = true;
            }
        }

        private void OutputNumberBasedOnRandomInput_Activated(object sender, EventArgs e)
        {
            if (Exists)
                butAddOrDelete.Text = "Smazat";
        }

        private void FillLbNumbers()
        {
            lbNumbers.Items.Clear();
            foreach (InputRandomNumber inputRandomNumber in InputsOutputs.GetList(typeof(InputRandomNumber)))
            {
                lbNumbers.Items.Add(inputRandomNumber+" ZN: X"+inputRandomNumber.ID);
                _existingUnknowns.Add('X'+inputRandomNumber.ID.ToString());
            }
        }
    }
}