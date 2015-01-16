using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAC
{
    public partial class CaC : Form
    {
        public CaC()
        {
            InitializeComponent();
            FillCbObjects();
        }

        private void FillCbObjects()
        {
            Dictionary<string, int> sideFormsList = new Dictionary<string, int>();

            foreach (SideFormManager.SideForms enumValue in
                       Enum.GetValues(typeof(SideFormManager.SideForms)))
            {
                sideFormsList.Add(enumValue.GetDescription(), (int)enumValue);
            }


            cbobjects.DisplayMember = "Key";
            cbobjects.ValueMember = "Value";
            cbobjects.DataSource = new BindingSource(sideFormsList, null);
            cbobjects.SelectedIndex = -1;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (SourceCodes.SetPath()) //shows folder browser dialog and if dialog result is OK than it will change path to sourcecodes and reloads list of them.
            {
                tbpath.Text = SourceCodes.GetPath();
                UpdateLbCodes();
            }
        }

        private void UpdateLbCodes()
        {
            lbCodes.Items.Clear();
            if (SourceCodes.GetSourceCodeFiles().Count != 0)
            {
                foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
                {
                    lbCodes.Items.Add(code);
                }
            }
            else
                MessageBox.Show("Nebyly nalezeny žádné platné soubory.");
            rtbCode.Clear();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            if (SourceCodes.IsDirectorySet())
                UpdateLbCodes();
            else
                MessageBox.Show("Nejdříve musíte zvolit adresář obsahující zdrojové kódy.");
        }

        private void lbCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCodes.SelectedIndex >= 0) //if no item is selected index would be -1
            {
                SourceCode code = SourceCodes.GetSourceCode(lbCodes.SelectedIndex);
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
            if (cbobjects.SelectedValue != null)
                SideFormManager.Show((SideFormManager.SideForms)cbobjects.SelectedValue);
            else
                SideFormManager.Close();
        }

        private void CaC_LocationChanged(object sender, EventArgs e)
        {
            SideFormManager.UpdatePosition();
        }

        private void butMoveUp_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != 0) //if theres any selected item and it isnt top one;
            {
                IOs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex - 1);
            }
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != lbObjects.Items.Count - 1) //if theres any selected item and it isnt bottom one;
            {
                IOs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex + 1);
            }
        }

        private void butExport_Click(object sender, EventArgs e)
        {

            if (lbObjects.Items.Count > 0)
            {
                SaveFileDialog saveXml = new SaveFileDialog();
                saveXml.Filter = @"XML files (*.xml)|*.xml";
                if (saveXml.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        IOsXmlManager.ExportToXml(saveXml.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nepodařilo se exportovat data do XML souboru.");
                    }
                    MessageBox.Show("Soubor byl úspěšně vyexportován.");
                }
            }
            else
                MessageBox.Show("Není co exportovat. Nejprve musíte přidat alespoň jeden vstup/výstup.");
        }

        private void lbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex >= 0)
            {
                IOs.getIOForm(lbObjects.SelectedIndex).exists = true;
                SideFormManager.ShowExisting(IOs.getIOForm(lbObjects.SelectedIndex));
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (lbObjects.Items.Count != 0)
                if (MessageBox.Show("Budou přepsány stávající vstupy/výstupy!", "Upozornění", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

            IOs.Clear();

            OpenFileDialog openXml=new OpenFileDialog();
            openXml.Filter="XML soubory (*.xml)|*.xml";
            if (openXml.ShowDialog() == DialogResult.OK)
            {
                IOsXmlManager.AddIOsFromXml(openXml.FileName);
            }
        }
    }
}
