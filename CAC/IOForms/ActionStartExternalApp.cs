using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class ActionStartExternalApp : InputOutputForm
    {
        public string Path
        {
            get { return tbPath.Text; }
            set { tbPath.Text = value; }
        }

        public bool RunAfter
        {
            get { return radAfter.Checked; }
            set { radAfter.Checked = value; }
        }

        public string Arguments
        {
            get { return tbArguments.Text; }
            set { tbArguments.Text = value; }
        }

        public ActionStartExternalApp()
        {
            InitializeComponent();
        }

        public ActionStartExternalApp(bool runAfter, string path,string arguments)
        {
            InitializeComponent();
            RunAfter = runAfter;
            Path = path;
            Arguments = arguments;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            var dialog=new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path = dialog.FileName;
            }
        }

        private void tbArguments_TextChanged(object sender, EventArgs e)
        {
            Arguments = tbArguments.Text;
        }

        private void radAfter_CheckedChanged(object sender, EventArgs e)
        {
            RunAfter = radAfter.Checked;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Path) && Exists)
            {
                DialogResult msg =
                    MessageBox.Show(Resources.YouHaveToSelectFile,
                        Resources.Warning, MessageBoxButtons.OKCancel);
                if (msg == DialogResult.Cancel) return;
                InputsOutputs.Remove(this);
            }
            else if (!AreArgumentsValid())
            {
                MessageBox.Show(Resources.ActionStartExternalApp_invalidArguments);
                return;
            }
            SideFormManager.Close();
            InputsOutputs.OnInOutListChanged();
        }

        private bool AreArgumentsValid()
        {
            if (RunAfter)
                return true;

            return !Arguments.Contains("@correct") && !Arguments.Contains("@wrong") && !Arguments.Contains("@time");
        }

        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                if (!string.IsNullOrEmpty(Path))
                {
                    if (AreArgumentsValid())
                    {
                        InputsOutputs.Add(this);
                    }
                    else
                    {
                        MessageBox.Show(Resources.ActionStartExternalApp_invalidArguments);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show(Resources.YouHaveToSelectFile);
                    return;
                }
            else
                InputsOutputs.Remove(this);

            SideFormManager.Close();
        }

        private void linkTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkTip.Enabled = false;
            MessageBox.Show(Resources.ActionStartExternalApp_Tip);
            linkTip.Enabled = true;
        }

        public override string ToString()
        {
            return Resources.IOFDescription_RunExternalApplication;
        }
    }
}
