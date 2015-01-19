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
            IOs.UpdateSelectedLbItem();
        }

        private void butAddOrDelete_Click(object sender, EventArgs e)
        {
            if (!Exists)
                IOs.Add(this);
            else
                IOs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return ""; //TODO  doplnit
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
            foreach (dynamic inputRandomNumber in IOs.GetList())
            {
                cbRanNumInputs.Items.Add(inputRandomNumber.ToString());
            }
        }
    }
}