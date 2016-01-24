using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;
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
            var dialog = new FolderBrowserDialog {Description = Resources.LanguageSelection_ChoseCFiles};
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
            foreach (var button in Controls.OfType<Button>())
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
            {Description = Resources.LanguageSelection_ChooseFolderSingleJava };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("java", "single");
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
            { Description = Resources.LanguageSelection_ChooseFolderJavaMultiFiles };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("java", "multi");
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