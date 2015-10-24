using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aGrader.sourceCodes;

namespace aGrader
{
    public partial class LanguageSelection : Form
    {
        public LanguageSelection()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void butC_Click(object sender, EventArgs e)
        {
            ShowJavaAdvancedButtons(false);
            ChangeEnabledStateOfButtons();
            var dialog = new FolderBrowserDialog {Description = "Zvolte složku která obsahuje soubory s příponou .c"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("c");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ChangeEnabledStateOfButtons();
            }
        }

        private void ChangeEnabledStateOfButtons()
        {
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Enabled = !button.Enabled;
            }
        }

        private void butJava_Click(object sender, EventArgs e)
        {
            ShowJavaAdvancedButtons(true);
        }

        private void ShowJavaAdvancedButtons(bool show)
        {
            butJavaMultipleFiles.Visible = show;
            butJavaOneFile.Visible = show;
            Size = show? new Size(311, 140) : new Size(311,75);
        }

        private void butJavaOneFile_Click(object sender, EventArgs e)
        {
            ChangeEnabledStateOfButtons();
            var dialog = new FolderBrowserDialog
            {Description = "  Zvolte složku která obsahuje jednotlivé soubory s příponou \"*.java\" (jeden soubor jeden test)" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("java");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ChangeEnabledStateOfButtons();
            }
        }

        private void butJavaMultipleFiles_Click(object sender, EventArgs e)
        {
            ChangeEnabledStateOfButtons();
            var dialog = new FolderBrowserDialog
            { Description = "Zvolte složku která obsahuje složky které obsahují soubory s příponou \"*.java\"   (jedna složka jeden test)" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("java");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ChangeEnabledStateOfButtons();
            }
        }
    }
}