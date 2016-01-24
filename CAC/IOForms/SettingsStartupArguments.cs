using System;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;

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
            return string.Format(Resources.IOFDescription_StartupArguments, Arguments);
        }

        private void InputString_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
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
                    MessageBox.Show(Resources.SettingsStartupArguments_StartupArgumentsAreAllreadySet);
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
