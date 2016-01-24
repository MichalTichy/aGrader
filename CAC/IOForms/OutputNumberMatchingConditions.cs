using System;
using System.Collections.Generic;
using System.Windows.Forms;
using aGrader.Mathematic;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class OutputNumberMatchingConditions : InputOutputForm
    {
        public List<string> Conditions = new List<string>();

        public OutputNumberMatchingConditions()
        {
            InitializeComponent();
        }

        public OutputNumberMatchingConditions(List<string> conditions)
        {
            InitializeComponent();
            Conditions = conditions;
            lbConditions.Items.AddRange(conditions.ToArray());
        }

        public override string ToString()
        {
            if (Conditions.Count == 1)
                return Resources.IOFDescription_NumberSatisfyingSingleCondition;
            return string.Format(Resources.IOFDescription_NumberSatisfyingMultipleConditions, Conditions.Count);
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
                MessageBox.Show(Resources.OutputNumberMatchingConditions_ThisConditionAllreadyExists);
                return;
            }
            var unknown = new List<string>(1) { "X" };
            if (!Validator.IsValidBooleanExpression(tbCondition.Text,unknown))
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
    }
}
