using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!EquationValidator.IsValid(tbJahoda.Text) && Exists)
            {
                DialogResult msg = MessageBox.Show("Jahoda nemá správný formát! \n Pokud si přejete pokračovat objekt bude smazán.","Upozornění",MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
                SideFormManager.Close();
                return;
            }
            SideFormManager.Close();
            InputsOutputs.UpdateSelectedLbItem();
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

        private void cbRanNumInputs_DropDown(object sender, EventArgs e)
        {
            cbRanNumInputs.Items.Clear();
            foreach (InputRandomNumber inputRandomNumber in InputsOutputs.GetList(typeof (InputRandomNumber)))
            {
                cbRanNumInputs.Items.Add(inputRandomNumber.ToString());
            }
        }

        private void butAddToList_Click(object sender, EventArgs e)
        {
                lbNumbers.Items.Add(cbRanNumInputs.SelectedText);
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            lbNumbers.Items.Remove(lbNumbers.SelectedItem);
        }

        private void tbJahoda_Leave(object sender, EventArgs e)
        {
            if (!EquationValidator.IsValid(tbJahoda.Text) && tbJahoda.Text.Length > 0)
                tbJahoda.ForeColor = Color.Red;
            else
                tbJahoda.ResetForeColor();
        }

        private void OutputNumberBasedOnRandomInput_Shown(object sender, EventArgs e)
        {
            if (Exists)
                butAddOrDelete.Text = "Smazat";
            
        }
    }
}