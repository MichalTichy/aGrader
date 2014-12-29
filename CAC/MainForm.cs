﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace CAC
{
    public partial class CaC : Form
    {
        public CaC()
        {
            InitializeComponent();
            PopulateCbObjects();
        }

        private void PopulateCbObjects()
        {
            Dictionary<string, int> SideFormsList = new Dictionary<string, int>();

            foreach (SideFormManager.SideForms enumValue in
                       Enum.GetValues(typeof(SideFormManager.SideForms)))
            {
                SideFormsList.Add(enumValue.GetDescription(), (int)enumValue);
            }


            cbobjects.DisplayMember = "Key";
            cbobjects.ValueMember = "Value";
            cbobjects.DataSource = new BindingSource(SideFormsList,null);
            cbobjects.SelectedIndex = -1;
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

        private void UpdateLbObjects()
        {
            lbObjects.Items.Clear();
            foreach (dynamic SideForm in IOs.getList())
            {
                lbObjects.Items.Add(SideForm.ToString());
            }
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
                    SideFormManager.Show(SideFormManager.SideForms.InputString);
                    break;
                case 1:
                    SideFormManager.Show(SideFormManager.SideForms.InputNumber);
                    break;
                case 2:
                    SideFormManager.Show(SideFormManager.SideForms.InputRandomNumber);
                    break;
                case 3:
                    SideFormManager.Show(SideFormManager.SideForms.InputFile);
                    break;
                default:
                    SideFormManager.Close();
                    break;
            }
        }

        private void CaC_LocationChanged(object sender, EventArgs e)
        {
            SideFormManager.UpdatePosition();
        }

        private void CaC_Activated(object sender, EventArgs e)
        {
            UpdateLbObjects();
        }

        private void butMoveUp_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != 0) //if theres any selected item and it isnt top one;
            {
                int selectedindex = lbObjects.SelectedIndex;
                IOs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex - 1);
                UpdateLbObjects();
                lbObjects.SelectedIndex = selectedindex - 1;
            }
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != lbObjects.Items.Count - 1) //if theres any selected item and it isnt bottom one;
            {
                int selectedindex = lbObjects.SelectedIndex;
                IOs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex + 1);
                UpdateLbObjects();
                lbObjects.SelectedIndex = selectedindex + 1;
            }
        }

        private void butExport_Click(object sender, EventArgs e)
        {

            if (lbObjects.Items.Count > 0)
            {
                SaveFileDialog saveXML = new SaveFileDialog();
                saveXML.Filter = "XML files (*.xml)|*.xml";
                if (saveXML.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument doc = IOs.GenerateXMLDocument();
                    doc.Save(saveXML.FileName);
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
                SideFormManager.Show(IOs.getIOForm(lbObjects.SelectedIndex));
            }
        }
    }
}
