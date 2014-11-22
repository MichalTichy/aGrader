using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CAC
{
    public partial class CaC : Form
    {
        public CaC()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (SourceCodes.setPath()) //shows folder browser dialog and if dialog result is OK than it will change path to sourcecodes and reloads list of them.
            {
                tbpath.Text = SourceCodes.getPath();
                UpdateLbCodes();
            }
        }

        private void UpdateLbCodes()
        {
            lbCodes.Items.Clear();
            foreach (SourceCode code in SourceCodes.getSourceCodeFiles())
            {
                lbCodes.Items.Add(code);
            }
            rtbCode.Clear();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            if (SourceCodes.isdirectoryset())
                UpdateLbCodes();                
            else
                MessageBox.Show("Nejdříve musíte zvolit adresář obsahující zdrojové kódy.");
        }

        private void lbCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCodes.SelectedIndex >= 0) //if no item is selected index would be -1
            {
                SourceCode code = SourceCodes.getSourceCode(lbCodes.SelectedIndex);
                if (code.Exists())
                    rtbCode.Text = code.GetSourceCode();
                else
                {
                    MessageBox.Show("Soubor se nepovedlo otevřít./nSeznam souborů bude nyní aktualizován.");
                    SourceCodes.ReloadSourceCodeFiles();
                    UpdateLbCodes();
                }
            }
        }

        private void cbobjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * VSTUP: TEXT
             * VSTUP: ČÍSLO
             * VSTUP: NÁHODNÉ ČÍSLO
             * VSTUP: SOUBOR
             */
            
            switch (cbobjects.SelectedIndex)
            {
                case 0:
                    SideFormManager.Show(new InputString());
                    break;
                case 1:
                    SideFormManager.Show(new InputNumber());
                    break;
                case 2:
                    SideFormManager.Show(new InputRandomNumber());
                    break;
                case 3:
                    SideFormManager.Show(new InputFile());
                    break;
                default:
                    SideFormManager.Close();
                    break;
            }
        }

        private void CaC_Move(object sender, EventArgs e)
        {
            SideFormManager.UpdatePosition();
        }
    }
}
