﻿#region

using System;
using System.Windows.Forms;

#endregion

namespace CAC.IO_Forms
{
    public partial class InputTextFile : Form
    {
        public bool Exists = false;
        public string Lineformat;
        public string Path;

        public InputTextFile()
        {
            InitializeComponent();
        }

        public InputTextFile(string path, string lineformat)
        {
            InitializeComponent();
            Path = path;
            Lineformat = lineformat;
            tbPath.Text = path;
            tBLineFormat.Text = lineformat;
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

        private void tBLineFormat_TextChanged(object sender, EventArgs e)
        {
            Lineformat = tBLineFormat.Text;
        }
    }
}