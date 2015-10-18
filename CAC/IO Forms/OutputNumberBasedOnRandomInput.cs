using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using aGrader.Mathematic;

namespace aGrader.IO_Forms
{
    public partial class OutputNumberBasedOnRandomInput : InputOutputForm
    {
        private List<string> _existingUnknowns = new List<string>();
        public string Math;

        public OutputNumberBasedOnRandomInput()
        {
            InitializeComponent();
        }

        public OutputNumberBasedOnRandomInput(string math)
        {
            InitializeComponent();
            tbMath.Text = math;
            Math = math;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!IsMathValid() && Exists)
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

        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                if (IsMathValid())
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

        private void tbMath_Leave(object sender, EventArgs e)
        {
            IsMathValid();
        }

        public bool IsMathValid()
        {
            if (!Validator.IsValidMath(tbMath.Text, _existingUnknowns))
            {
                tbMath.ForeColor = Color.Red;
                return false;
            }
            tbMath.ResetForeColor();
            Math = tbMath.Text;
            return true;
        }

        private void OutputNumberBasedOnRandomInput_Activated(object sender, EventArgs e)
        {
            _existingUnknowns.Clear();
            FillLbNumbers();
            if (Exists)
                butAddOrDelete.Text = "Smazat";
        }

        private void FillLbNumbers()
        {
            lbNumbers.Items.Clear();
            var formId = InputsOutputs.GetIdOfForm(this);
            var countOfPrecedingInputsOutputs = (formId == -1) ? InputsOutputs.GetList().Count() : formId;
            IEnumerable<dynamic> inputsOutputs = InputsOutputs.GetList().Take(countOfPrecedingInputsOutputs);

            foreach (InputRandomNumber inputRandomNumber in inputsOutputs.Where(item=>item is InputRandomNumber))
            {
                lbNumbers.Items.Add(inputRandomNumber + " ZN: " + inputRandomNumber.Id);
                _existingUnknowns.Add(inputRandomNumber.Id);
            }
        }
    }
}
