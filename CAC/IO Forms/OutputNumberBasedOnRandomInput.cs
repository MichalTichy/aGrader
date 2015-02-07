using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputNumberBasedOnRandomInput : Form
    {
        public bool Exists = false;

        public OutputNumberBasedOnRandomInput()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.UpdateSelectedLbItem();
        }

        private void butAddOrDelete_Click(object sender, EventArgs e)
        {
            if (!Exists)
                InputsOutputs.Add(this);
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "XXX"; //TODO  doplnit
        }

        private void OutputNumberBasedOnRandomInput_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void cbRanNumInputs_DropDown(object sender, EventArgs e)
        {
            cbRanNumInputs.Items.Clear();
            foreach (InputRandomNumber inputRandomNumber in InputsOutputs.GetList(typeof (InputRandomNumber)))
            {
                cbRanNumInputs.Items.Add(inputRandomNumber.ToString());
            }
            cbRanNumInputs.Items.Add("Rovnice");
        }
    }
}