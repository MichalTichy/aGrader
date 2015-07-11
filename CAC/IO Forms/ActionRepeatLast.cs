#region

using System;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CAC.IO_Forms
{
    public partial class ActionRepeatLast : Form
    {
        public bool Exists = false;
        public int Repetitions;

        public ActionRepeatLast()
        {
            InitializeComponent();
            Repetitions = (int) numeric.Value;
        }

        public object GetRepeatedForm()
        {
            int idOfThisForm = InputsOutputs.GetIdOfForm(this);
            if (idOfThisForm == 0)
                return null;
            return InputsOutputs.GetIOForm(idOfThisForm!=-1 ? idOfThisForm - 1 : InputsOutputs.GetIdOfForm(InputsOutputs.GetList().Last()));
        }

        public ActionRepeatLast(int numberOfRepetitions)
        {
            InitializeComponent();
            Repetitions = numberOfRepetitions;
            numeric.Value = numberOfRepetitions;
            labLastAction.Text = InputsOutputs.GetList().Last().ToString();
        }

        public bool CheckIfPreviousActionIsRepeatable()
        {
            string[] nonRepetable =
            {
                "ActionRepeatLast", "SettingsDeviation", "SettingsProhibitedCommand",
                "SettingsRequiedCommand"
            };
            if (!InputsOutputs.GetList().Any())
            {
                MessageBox.Show("Není co opakovat.");
                return false;
            }

            if (nonRepetable.Contains(GetRepeatedForm().GetType().ToString()))
            {
                MessageBox.Show("Poslední akce nemůže být zopakována.");
                return false;
            }

            return true;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                InputsOutputs.Add(this);
            else
                InputsOutputs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "AKCE: opakuj předešlý krok " + Repetitions + "x";
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            Repetitions = (int) numeric.Value;
        }

        private void InputNumber_Activated(object sender, EventArgs e)
        {
            UpdateRepeatedActionLabel();
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void UpdateRepeatedActionLabel()
        {
            var RepeatedForm = GetRepeatedForm();
            labLastAction.Text = RepeatedForm!=null ? RepeatedForm.ToString() : "Není co opakovat.";
        }

        private void ActionRepeatLast_Shown(object sender, EventArgs e)
        {
            if (CheckIfPreviousActionIsRepeatable())
                return;

            SideFormManager.Close();
        }
    }
}