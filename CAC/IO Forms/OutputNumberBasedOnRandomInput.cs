using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class OutputNumberBasedOnRandomInput : Form
    {
        public bool Exists = false;
        public List<string> Equation=new List<string>();

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

        private void butAddToList_Click(object sender, EventArgs e)
        {
            if (cbRanNumInputs.SelectedIndex == cbRanNumInputs.Items.Count - 1 && tbProperities.Text.Length == 0)
                MessageBox.Show("Musíte napsat rovnici!");
            else
                lbNumbers.Items.Add(tbProperities.Text);
        }

        private void cbRanNumInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO refaktorovat
            tbProperities.Enabled = false;
            if (cbRanNumInputs.SelectedIndex == cbRanNumInputs.Items.Count-1)
                tbProperities.Enabled = true;
            else if(cbRanNumInputs.SelectedItem!=null)
                tbProperities.Text = cbRanNumInputs.SelectedItem.ToString() + " ZN:X" +
                                cbRanNumInputs.SelectedIndex.ToString();
        }
    }
}