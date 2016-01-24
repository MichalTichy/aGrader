using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using aGrader.Mathematic;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class OutputCountOfNumbersMatchingConditions : InputOutputForm
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
                return Resources.IOFDesruption_CountOfNumMatchingSingleCondition;
            return string.Format(Resources.IOFDesruption_CountOfNumMatchingMultipleConditions, Conditions.Count);
        }

        private void OutputNumber_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = Resources.Delete;
            }
        }
        private void butAddCondition_Click(object sender, EventArgs e)
        {
            if (Conditions.Contains(tbCondition.Text))
            {
                MessageBox.Show(Resources.OutputCountOfNumbersMatchingConditions_ThisConditionAllreadyExists);
                return;
            }

            if (!Validator.IsValidBooleanExpression(tbCondition.Text,new[] {"X"}))
            {
                MessageBox.Show(Resources.OutputCountOfNumbersMatchingConditions_InvalidCondition);
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
                MessageBox.Show(Resources.OutputCountOfNumbersMatchingConditions_YouHaveToSelectConditionForDeletion);
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

            var formId = InputsOutputs.GetIdOfForm(this);

            var countOfPrecedingNumbres = radioInputs.Checked ? InputsOutputs.GetInputsList(FormType.Number, formId).Count() : InputsOutputs.GetOutputsList(FormType.Number, formId).Count();

            var numberOfValidNumbersAddedByRepeaters = GetCountOfValidRepetitions();
            if (numCountOfNumbers.Value <= countOfPrecedingNumbres + numberOfValidNumbersAddedByRepeaters)
            {
                numCountOfNumbers.BackColor = DefaultBackColor;
                return true;
            }
            numCountOfNumbers.BackColor = Color.Red;
            MessageBox.Show(Resources.OutputCountOfNumbersMatchingConditions_RequestedNumberOfNumbersIsNotPOssible);
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
                                .StartsWith(radioInputs.Checked ? "aGrader.IOForms.Input" : "aGrader.IOForms.Output")
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
