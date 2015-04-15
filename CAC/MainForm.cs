using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAC.SourceCodes;

namespace CAC
{
    public partial class CaC : Form
    {
        //todo dát související věci k sobě
        public CaC()
        {
            InitializeComponent();
            FillCbObjects();
            cbobjects.SelectedIndexChanged+=cbobjects_SelectedIndexChanged;
            InputsOutputs.InOutListChanged +=InputsOutputsOnInOutListChanged;
        }

        private void InputsOutputsOnInOutListChanged(object sender, EventArgs eventArgs)
        {
            lbObjects.Items.Clear();
            InputsOutputs.GetList().ToList().ForEach(i=> lbObjects.Items.Add(i.ToString()));
        }

        private void FillCbObjects()
        {
            Dictionary<string, int> sideFormsList = new Dictionary<string, int>();

            foreach (SideFormManager.SideForms enumValue in
                Enum.GetValues(typeof (SideFormManager.SideForms)))
            {
                sideFormsList.Add(enumValue.GetDescription(), (int) enumValue);
            }


            cbobjects.DisplayMember = "Key";
            cbobjects.ValueMember = "Value";
            cbobjects.DataSource = new BindingSource(sideFormsList, null);
            cbobjects.SelectedIndex = -1;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (SourceCodes.SourceCodes.SetPath())
            {
                tbpath.Text = SourceCodes.SourceCodes.GetPath();
                UpdateLbCodes();
            }
        }

        private void UpdateLbCodes()
        {
            SourceCodes.SourceCodes.ReloadSourceCodeFiles();
            lbCodes.Items.Clear();
            if (SourceCodes.SourceCodes.GetSourceCodeFiles().Count != 0)
            {
                foreach (SourceCode code in SourceCodes.SourceCodes.GetSourceCodeFiles())
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
            if (SourceCodes.SourceCodes.IsDirectorySet())
                UpdateLbCodes();
            else
                MessageBox.Show("Nejdříve musíte zvolit adresář obsahující zdrojové kódy.");
        }

        private void lbCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lErrorMessage.Text = "";
            if (lbCodes.SelectedItem==null) return;
            SourceCode code = SourceCodes.SourceCodes.GetSourceCode(lbCodes.SelectedIndex);
            
            SetListViewToBananaMode(code.GetResult());

            if (code.Exists())
            {
                rtbCode.Text = code.GetSourceCode()+"\n";
                if (code.GetErrorMessage()!=null)
                {
                    int lineWithError = code.GetIdOfLineWithError();
                    rtbCode.Select(rtbCode.GetFirstCharIndexFromLine(lineWithError), rtbCode.Lines[lineWithError].Length);
                    rtbCode.SelectionBackColor = Color.Red;
                    lErrorMessage.Text = "Kód nemůže být zkompilován! "+code.GetErrorMessage();
                }
            }
            else
            {
                MessageBox.Show("Soubor se nepovedlo otevřít./nSeznam souborů bude nyní aktualizován.");
                SourceCodes.SourceCodes.ReloadSourceCodeFiles();
                UpdateLbCodes();
            }
        }

        private void cbobjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbobjects.SelectedValue != null)
                SideFormManager.Show((SideFormManager.SideForms) cbobjects.SelectedValue);
            else
                SideFormManager.Close();
        }

        private void CaC_LocationChanged(object sender, EventArgs e)
        {
            SideFormManager.UpdatePosition();
        }

        private void butMoveUp_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != 0)
                //if theres any selected item and it isnt top one;
            {
                InputsOutputs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex - 1);
            }
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != lbObjects.Items.Count - 1)
                //if theres any selected item and it isnt bottom one;
            {
                InputsOutputs.Swap(lbObjects.SelectedIndex, lbObjects.SelectedIndex + 1);
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
                        InOutXmlManager.ExportToXml(saveXml.FileName);
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
            if (lbObjects.SelectedItem != null)
            {
                InputsOutputs.GetIOForm(lbObjects.SelectedIndex).Exists = true;
                SideFormManager.ShowExisting(InputsOutputs.GetIOForm(lbObjects.SelectedIndex));
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (lbObjects.Items.Count != 0)
                if (
                    MessageBox.Show("Budou přepsány stávající vstupy/výstupy!", "Upozornění", MessageBoxButtons.OKCancel) ==
                    DialogResult.Cancel)
                    return;

            InputsOutputs.Clear();

            OpenFileDialog openXml = new OpenFileDialog();
            openXml.Filter = "XML soubory (*.xml)|*.xml";
            if (openXml.ShowDialog() == DialogResult.OK)
            {
                InOutXmlManager.AddIOsFromXml(openXml.FileName);
            }
        }

        private void butRunTest_Click(object sender, EventArgs e)
        {
            //todo mozna vypnout UI?
            SetListViewToGrepMode(); //todo GREP!

            lbCodes.ClearSelected();
            rtbCode.Clear();

            TestManager.TestAllSourceCodes();
        }

        private void SetListViewToGrepMode() //todo GREP!
        {
            TestResult.ResultReady += ResultReady; //otestovat!
            lV.Items.Clear();
            lV.Columns.Clear();

            lV.Columns.Add("Jméno souboru",250);
            lV.Columns.Add("Stav",249);

            foreach (SourceCode code in SourceCodes.SourceCodes.GetSourceCodeFiles())
            {
                //todo refaktorovat
                if (code.GetResult() != null)
                {
                    ListViewItem line = new ListViewItem(new[] { code.Name, code.GetResult().status });
                    line.UseItemStyleForSubItems = false;
                    line.SubItems[1].ForeColor = GetStatusColor(code.GetResult().status);
                    lV.Items.Add(line);
                }
                else
                {
                    ListViewItem line = new ListViewItem(new[] { code.Name, "testuje se" });
                    line.UseItemStyleForSubItems = false;
                    line.SubItems[1].ForeColor = Color.Orange;
                    lV.Items.Add(line);
                }
            }
        }

        private void SetListViewToBananaMode(TestResult result) //todo BANANA!
        {
            lV.Items.Clear();
            lV.Columns.Clear();
            lV.Groups.Clear();

            lV.Groups.Add(new ListViewGroup("Vstup"));
            lV.Groups.Add(new ListViewGroup("Výstup"));

            lV.Columns.Add("Vstup/Výstup",250);
            lV.Columns.Add("Očekávaný výstup",249);

            if (result == null)
                return;

            foreach (string input in result.inputs)
                lV.Items.Add(new ListViewItem(new[] {input, ""}));

            foreach (KeyValuePair<string, string> output in result.Outputs)
            {
                ListViewItem line=new ListViewItem(new[] {output.Key, output.Value});
                if (output.Key != output.Value)
                    line.BackColor = Color.Red;
                lV.Items.Add(line);
            }
        }

        private delegate void UpdateResultInvoker(TestResult result);

        private void ResultReady(object sender, TestResultArgs testResultArgs)
        {
            Invoke(new UpdateResultInvoker(UpdateRusult), testResultArgs.Result);
        }

        private void UpdateRusult(TestResult result)
        {
            ListViewItem line = lV.FindItemWithText(result.FileName);
            line.SubItems[1].Text = result.status;

            Color color = GetStatusColor(result.status);

            line.SubItems[1].ForeColor = color;
        }

        private static Color GetStatusColor(string status)
        {
            Color color;
            if (status == "OK")
                color = Color.Green;
            else if (status == "testuje se")
                color = Color.Orange;
            else
                color = Color.Red;
            return color;
        }

        private void butShowTestProgress_Click(object sender, EventArgs e)
        {
            SetListViewToGrepMode();
        }
    }
}