using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputTextFile : CAC.IO_Forms.InputOutputForm
    {
        public string Path;

        public InputTextFile()
        {
            InitializeComponent();
        }

        public InputTextFile(string path)
        {
            InitializeComponent();
            Path = path;
            tbPath.Text = path;
            FullPathToolTip.SetToolTip(tbPath, Path);
        }

        public override string ToString()
        {
            return "VSTUP: soubor " + System.IO.Path.GetFileName(Path);
        }

        private void InputFile_Activated(object sender, EventArgs e)
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
                FullPathToolTip.SetToolTip(tbPath, Path);
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
