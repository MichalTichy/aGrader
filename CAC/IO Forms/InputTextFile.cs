using System;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class InputTextFile : Form
    {
        public string Path;
        public string Lineformat;

        public bool Exists = false;

        public InputTextFile()
        {
            InitializeComponent();
        }

        public InputTextFile(string path,string lineformat)
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
            IOs.UpdateSelectedLbItem();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!Exists)
                IOs.Add(this);
            else
                IOs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: soubor "+System.IO.Path.GetFileName(Path);
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
            OpenFileDialog selectFile = new OpenFileDialog();
            if (selectFile.ShowDialog()==DialogResult.OK)
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
