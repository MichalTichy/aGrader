using System;
using System.Windows.Forms;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class InputOutputForm : Form
    {
        public bool Exists = false;

        public InputOutputForm()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        protected virtual void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                InputsOutputs.Add(this);
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        protected virtual void InputOutputForm_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }
    }
}
