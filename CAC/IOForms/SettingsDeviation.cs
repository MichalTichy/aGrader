using System;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class SettingsDeviation : InputOutputForm
    {
        public double Deviation;
        public SettingsDeviation()
        {
            InitializeComponent();
            Deviation = (double)numeric.Value;
        }

        public SettingsDeviation(double deviation)
        {
            InitializeComponent();
            Deviation = deviation;
            numeric.Value = (decimal)deviation;
        }

        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
            {
                if (InputsOutputs.GetList(typeof(SettingsDeviation)).Any())
                {
                    MessageBox.Show(Resources.SettingsDeviation_DeviationIsAllreadySet);
                    return;
                }
                InputsOutputs.Add(this);
            }
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return string.Format(Resources.IOFDescription_SettingsDeviation, Deviation);
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Deviation = (double)numeric.Value;
        }

        private void InputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }
    }
}
