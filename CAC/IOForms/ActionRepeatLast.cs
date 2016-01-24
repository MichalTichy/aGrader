using System;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class ActionRepeatLast : InputOutputForm
    {
        public int Repetitions;

        public ActionRepeatLast()
        {
            InitializeComponent();
            Repetitions = (int)numeric.Value;
        }
        public ActionRepeatLast(int numberOfRepetitions)
        {
            InitializeComponent();
            Repetitions = numberOfRepetitions;
            numeric.Value = numberOfRepetitions;
            labLastAction.Text = InputsOutputs.GetList().Last().ToString();
        }

        public object GetRepeatedForm()
        {
            if (!InputsOutputs.GetList().Any())
                return null;
            var idOfThisForm = InputsOutputs.GetIdOfForm(this);
            if (idOfThisForm == 0)
                return null;
            return InputsOutputs.GetIOForm(idOfThisForm != -1 ? idOfThisForm - 1 : InputsOutputs.GetIdOfForm(InputsOutputs.GetList().Last()));
        }

        public bool CheckIfPreviousActionIsRepeatable()
        {
            string[] nonRepetable =
            {
                "ActionRepeatLast", "SettingsDeviation","SettingsStartupArguments", "SettingsProhibitedCommand",
                "SettingsRequiedCommand"
            };
            if (!InputsOutputs.GetList().Any())
            {
                MessageBox.Show(Resources.ActionRepeatLast_NothingToRepeat);
                return false;
            }

            if (nonRepetable.Contains(GetRepeatedForm().GetType().ToString()))
            {
                MessageBox.Show(Resources.ActionRepeatLast_LastActionCouldNotBeRepeated);
                return false;
            }

            return true;
        }

        private void ActionRepeatLast_Activated(object sender, EventArgs e)
        {
            UpdateRepeatedActionLabel();
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }
        
        private void UpdateRepeatedActionLabel()
        {
            var repeatedForm = GetRepeatedForm();
            labLastAction.Text = repeatedForm?.ToString() ?? Resources.ActionRepeatLast_NothingToRepeat;
        }

        private void ActionRepeatLast_Shown(object sender, EventArgs e)
        {
            if (InputsOutputs.GetList().Count()!=0 && CheckIfPreviousActionIsRepeatable())
                return;

            SideFormManager.Close();
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Repetitions = (int)numeric.Value;
        }

        public override string ToString()
        {
            return string.Format(Resources.IOFDescription_RepeatLast, Repetitions);
        }
    }
}
