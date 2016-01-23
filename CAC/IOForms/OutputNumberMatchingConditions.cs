using System;
using System.Collections.Generic;
using System.Windows.Forms;
using aGrader.Mathematic;

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
            var unknown = new List<string>(1) { "X" };
            if (!Validator.IsValidBooleanExpression(tbCondition.Text,unknown))
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
    }
}
