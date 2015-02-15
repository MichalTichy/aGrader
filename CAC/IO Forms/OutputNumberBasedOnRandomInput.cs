﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    //todo přejmenovat tbjahoda
    public partial class OutputNumberBasedOnRandomInput : Form
    {
        public bool Exists = false;
        public List<string> RandomInputs = new List<string>();
        public string jahoda;
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
            if (cbRanNumInputs.SelectedItem != null)
                tbProperities.Text = cbRanNumInputs.SelectedItem + " ZN:X" +
                                     cbRanNumInputs.SelectedIndex;
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            lbNumbers.Items.Remove(lbNumbers.SelectedItem);
        }
    }
}