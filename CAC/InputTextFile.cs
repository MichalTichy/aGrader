using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC
{
    public partial class InputTextFile : Form
    {
        public string path;
        public string lineformat;

        public bool exists = false;

        public InputTextFile()
        {
            InitializeComponent();
        }

        public InputTextFile(string path,string lineformat)
        {
            InitializeComponent();
            this.path = path;
            this.lineformat = lineformat;
            tbPath.Text = path;
            tBLineFormat.Text = lineformat;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            if (!exists)
                IOs.Add(this);
            else
                IOs.Remove(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: soubor "+Path.GetFileName(path);
        }

        private void InputFile_Activated(object sender, EventArgs e)
        {
            if (exists)
            {
                butAddOrDelete.Text = "Smazat";
            }
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            if (selectFile.ShowDialog()==DialogResult.OK)
            {
                path = selectFile.FileName;
                tbPath.Text = path;
                FullPathToolTip.SetToolTip(tbPath, path);
            }
        }

        private void tBLineFormat_TextChanged(object sender, EventArgs e)
        {
            lineformat = tBLineFormat.Text;
        }
    }
}
