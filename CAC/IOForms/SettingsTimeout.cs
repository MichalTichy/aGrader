﻿using System;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class SettingsTimeout : InputOutputForm
    {
        public int Timeout;
        public SettingsTimeout()
        {
            InitializeComponent();
            Timeout = (int)numericUpDown1.Value;
        }

        public SettingsTimeout(int timeout)
        {
            InitializeComponent();
            numericUpDown1.Value = timeout;
            Timeout = (int)numericUpDown1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Timeout = (int)numericUpDown1.Value;
        }

        public override string ToString()
        {
            return string.Format(Resources.IOFDescription_SettingsTimeout, Timeout);
        }

        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
            {
                if (InputsOutputs.GetList(typeof(SettingsTimeout)).Any())
                {
                    MessageBox.Show(Resources.SettingsTimeout_TimeoutAllreadySet);
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
