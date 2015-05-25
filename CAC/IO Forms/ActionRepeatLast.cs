using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class ActionRepeatLast : Form
    {
        public bool Exists = false;
        public int Repetitions;

        public ActionRepeatLast()
        {
            InitializeComponent();
            if (!CheckIfPreviousActionIsRepeatable())
            {
                SideFormManager.Close();
                return;
            }
            Repetitions = (int) numeric.Value;
            labLastAction.Text = InputsOutputs.GetList().Last().ToString();
        }
        
        public ActionRepeatLast(int numberOfRepetitions)
        {
            InitializeComponent();
            Repetitions = numberOfRepetitions;
            numeric.Value = numberOfRepetitions;
            labLastAction.Text = InputsOutputs.GetList().Last().ToString();
        }

        private bool CheckIfPreviousActionIsRepeatable()
        {
            string[] nonRepetable = { "ActionRepeatLast", "SettingsDeviation", "SettingsProhibitedCommand", "SettingsRequiedCommand" };
            if (!InputsOutputs.GetList().Any())
            {
                MessageBox.Show("Není co opakovat.");
                return false;
            }

            Type lastAction = InputsOutputs.GetList().Last().GetType();
            if (nonRepetable.Contains(lastAction.Name))
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
            Repetitions = (int)numeric.Value;
        }

        private void InputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
    }
}
