#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAC.Mathematic;

#endregion

namespace CAC.IO_Forms
{
    //todo validovani nefunguje tak jak by melo.
    //todo přejmenovat tbMath
    public partial class OutputNumberBasedOnRandomInput : Form
    {
        private List<string> _existingUnknowns = new List<string>();
        public bool Exists = false;
        private bool _isMathValid; //todo prejmenovat
        public string Math; //todo prejmenovat

        public OutputNumberBasedOnRandomInput()
        {
            InitializeComponent();
            FillLbNumbers();
        }

        public OutputNumberBasedOnRandomInput(string math)
        {
            InitializeComponent();
            tbJahoda.Text = math;
            Math = math;
            FillLbNumbers();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!_isMathValid && Exists)
            {
                DialogResult msg =
                    MessageBox.Show("Matematický příklad nemá správný formát! \nPokud si přejete pokračovat objekt bude smazán.",
                        "Upozornění", MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
            }
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private void butAddOrDelete_Click(object sender, EventArgs e)
        {
            if (!Exists)
                if (_isMathValid)
                {
                    InputsOutputs.Add(this);
                }
                else
                {
                    MessageBox.Show("Musíte zadat platný matematický příklad.");
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
            _isMathValid = MathValidator.IsValid(tbJahoda.Text, _existingUnknowns);
            if (!_isMathValid)
            {
                tbJahoda.ForeColor = Color.Red;
                _isMathValid = false;
            }
            else
            {
                tbJahoda.ResetForeColor();
                Math = tbJahoda.Text;
                _isMathValid = true;
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
            foreach (InputRandomNumber inputRandomNumber in InputsOutputs.GetList(typeof (InputRandomNumber)))
            {
                lbNumbers.Items.Add(inputRandomNumber + " ZN: X" + inputRandomNumber.Id);
                _existingUnknowns.Add('X' + inputRandomNumber.Id.ToString());
            }
        }
    }
}