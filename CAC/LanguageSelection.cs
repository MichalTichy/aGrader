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
            DialogResult=DialogResult.Cancel;
            Close();
        }

        private void butC_Click(object sender, EventArgs e)
        {
            ChangeEnabledStateOfButtons();
            var dialog = new FolderBrowserDialog {Description = "Zvolte složku která obsahuje soubory s příponou .c"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceCodes.SetPath(dialog.SelectedPath);
                SourceCodes.LoadSourceCodeFiles("c");
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
    }
}
