using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAC.Mathematic;

namespace CAC.IO_Forms
{
    public partial class OutputCountOfNumbersMatchingConditions : CAC.IO_Forms.InputOutputForm
    {

        public int CountOfNumbers;
        public List<string> Conditions = new List<string>();

        public OutputCountOfNumbersMatchingConditions()
        {
            InitializeComponent();
        }
        public OutputCountOfNumbersMatchingConditions(List<string> conditions, int countOfNumbers, bool takeInputs)
        {
            InitializeComponent();
            Conditions = conditions;
            lbConditions.Items.AddRange(conditions.ToArray());
            CountOfNumbers = countOfNumbers;
            numCountOfNumbers.Value = countOfNumbers;
            radioInputs.Checked = takeInputs;
        }
        public override string ToString()
        {
            if (Conditions.Count == 1)
                return "VÝSTUP: číslo splňující 1 podmínku.";
            return "VÝSTUP: číslo splňující " + Conditions.Count + " podmínek.";
        }

        private void OutputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }
        private void butAddCondition_Click(object sender, EventArgs e)
        {
            if (Conditions.Contains(tbCondition.Text))
            {
                MessageBox.Show("Tato podmínka již existuje.");
                return;
            }

            if (!Validator.IsValidBooleanExpression(tbCondition.Text,new[] {"X"}))
            {
                MessageBox.Show("Podmínka není validní.");
                return;
            }
            Conditions.Add(tbCondition.Text);
            lbConditions.Items.Add(tbCondition.Text);
            tbCondition.Clear();
        }
        private void butRemoveConditon_Click(object sender, EventArgs e)
        {
            if (lbConditions.SelectedItem == null)
            {
                MessageBox.Show("Musíte zvolit kterou podmínku chcete vymazat.");
                return;
            }
            Conditions.Remove(lbConditions.SelectedItem.ToString());
            lbConditions.Items.RemoveAt(lbConditions.SelectedIndex);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!IsRequestedCountOfNumbersValid())
                numCountOfNumbers.Value = CountOfNumbers;
            else
                CountOfNumbers = (int)numCountOfNumbers.Value;
        }

        public bool TakesInputs()
        {
            return radioInputs.Checked;
        }

        public bool IsRequestedCountOfNumbersValid()
        {

            int formId = InputsOutputs.GetIdOfForm(this);

            int countOfPrecedingNumbres = radioInputs.Checked ? InputsOutputs.GetInputsList(formType.Number, formId).Count() : InputsOutputs.GetOutputsList(formType.Number, formId).Count();

            int numberOfValidNumbersAddedByRepeaters = GetCountOfValidRepetitions();
            if (numCountOfNumbers.Value <= countOfPrecedingNumbres + numberOfValidNumbersAddedByRepeaters)
            {
                numCountOfNumbers.BackColor = DefaultBackColor;
                return true;
            }
            numCountOfNumbers.BackColor = Color.Red;
            MessageBox.Show("Požadovaný počet čísel není možný.");
            return false;
        }

        private int GetCountOfValidRepetitions()
        {

            var validRepeaters =
                InputsOutputs.GetList(typeof(ActionRepeatLast), InputsOutputs.GetIdOfForm(this))
                    .Where(
                        t =>
                            t.GetRepeatedForm()
                                .GetType()
                                .ToString()
                                .StartsWith(radioInputs.Checked ? "CAC.IO_Forms.Input" : "CAC.IO_Forms.Output")
                                && t.GetRepeatedForm().GetType()
                                .ToString().Contains("Number"));

            int i = 0;
            foreach (dynamic validRepeater in validRepeaters)
            {
                i += validRepeater.Repetitions;
            }
            return i;
        }
    }
}
