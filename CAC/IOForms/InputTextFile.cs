using System;
using System.Windows.Forms;

namespace aGrader.IOForms
{
    public partial class InputTextFile : InputOutputForm
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
