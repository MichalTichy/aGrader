using System;
using System.Linq;
using System.Windows.Forms;

namespace aGrader.IOForms
{
    public partial class SettingsStartupArguments : InputOutputForm
    {
        public string Arguments;

        public SettingsStartupArguments()
        {
            InitializeComponent();
        }

        public SettingsStartupArguments(string arguments)
        {
            InitializeComponent();
            Arguments = arguments;
            tbArguments.Text = arguments;
        }

        public override string ToString()
        {
            return "NASTAVENÍ: souštěcí parametry: \"" + Arguments + "\"";
        }

        private void InputString_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void tbString_TextChanged(object sender, EventArgs e)
        {
            Arguments = tbArguments.Text;
        }

        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
            {
                if (InputsOutputs.GetList(typeof(SettingsStartupArguments)).Any())
                {
                    MessageBox.Show("Spouštěcí parametry jsou již nastaveny.");
                    return;
                }
                InputsOutputs.Add(this);
            }
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }
    }
}
