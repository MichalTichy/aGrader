using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class ActionCompareFiles : CAC.IO_Forms.InputOutputForm
    {
        public string Path;
        public ActionCompareFiles()
        {
            InitializeComponent();
        }

        public ActionCompareFiles(string path,bool compareHashOnly = false)
        {
            InitializeComponent();
            Path = path;
            radioHash.Checked = compareHashOnly;
            toolTipPath.SetToolTip(tbPath, tbPath.Text);
        }
        public override string ToString()
        {
            return "AKCE: porovnání souborů " + System.IO.Path.GetFileName(Path) +"a vygenerovaného souboru";
        }
        private void Form_Activated(object sender, EventArgs e)
        {
            if (Exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            var selectFile = new OpenFileDialog();
            if (selectFile.ShowDialog() == DialogResult.OK)
            {
                Path = selectFile.FileName;
                tbPath.Text = Path;
                toolTipPath.SetToolTip(tbPath, Path);
            }
        }
        protected override void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
            {
                if (string.IsNullOrWhiteSpace(tbPath.Text))
                {
                    MessageBox.Show("Musíte vybrat soubor!");
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
