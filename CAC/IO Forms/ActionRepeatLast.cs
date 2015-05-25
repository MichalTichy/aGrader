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
        public decimal Value;

        public ActionRepeatLast()
        {
            InitializeComponent();
            CheckIfPreviousActionIsRepeatable();
            Value = numeric.Value;
        }

        private void CheckIfPreviousActionIsRepeatable()
        {
            string[] nonRepetable = {};
            string lastAction = InputsOutputs.GetList().Last().GetType();
            if (!InputsOutputs.GetList().Any())
                MessageBox.Show("Není co opakovat.");
            else if (nonRepetable.Contains(lastAction))
                MessageBox.Show(InputsOutputs.GetList().Last().ToString() + " nemůže být zopakován.");
            else
                return;
            SideFormManager.Close();
        }

        public ActionRepeatLast(decimal value)
        {
            InitializeComponent();
            Value = value;
            numeric.Value = value;
        }
    }
}
