#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CAC.IO_Forms;
using CAC.Mathematic;
using CAC.sourceCodes;

#endregion

namespace CAC
{
    public partial class CaC : Form
    {
        //todo grafy
        //todo JSON misto XML?
        //todo použít indexery
        //todo dát související věci k sobě
        public CaC()
        {
            InitializeComponent();
            FillCbObjects();
            cbobjects.SelectedIndexChanged += cbobjects_SelectedIndexChanged;
            InputsOutputs.InOutListChanged += InputsOutputsOnInOutListChanged;
        }

        private void InputsOutputsOnInOutListChanged(object sender, EventArgs eventArgs)
        {
            lbObjects.Items.Clear();
            InputsOutputs.GetList().ToList().ForEach(i => lbObjects.Items.Add(i.ToString()));
        }

        private void FillCbObjects()
        {
            var sideFormsList = new Dictionary<string, int>();

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
            if (SourceCodes.SetPath())
            {
                tbpath.Text = SourceCodes.GetPath();
                UpdateLbCodes();
            }
        }

        private void UpdateLbCodes()
        {
            SourceCodes.ReloadSourceCodeFiles();
            lbCodes.Items.Clear();
            if (SourceCodes.GetSourceCodeFiles().Count != 0)
            {
                foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
                {
                    lbCodes.Items.Add(code);
                }
                CheckForIllegalFilenames();
            }
            else
                MessageBox.Show("Nebyly nalezeny žádné platné soubory.");
            rtbCode.Clear();
        }

        private void CheckForIllegalFilenames()
        {
            char[] illegalChars = {'-',' ','_'}; //todo doplnit
            foreach (object name in lbCodes.Items)
            {
                if (name.ToString().IndexOfAny(illegalChars)!=-1)
                {
                    MessageBox.Show(name + "obsahuje nepovolené znaky (" + new string(illegalChars) + ")");
                    lbCodes.Items.Clear();
                    return;
                }
            }
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
            lErrorMessage.Text = "";
            if (lbCodes.SelectedItem == null) return;
            SourceCode code = SourceCodes.GetSourceCode(lbCodes.SelectedIndex);

            SetListViewToBananaMode(code.GetResult());

            if (code.Exists())
            {
                rtbCode.Text = code.GetSourceCode() + "\n";
                if (code.GetCompilationErrorMessage() != null) //todo BUG?
                {
                    int lineWithError = code.GetIdOfLineWithError();
                    rtbCode.Select(rtbCode.GetFirstCharIndexFromLine(lineWithError), rtbCode.Lines[lineWithError].Length);
                    rtbCode.SelectionBackColor = Color.Red;
                    lErrorMessage.Text = "Kód nemůže být zkompilován!";
                }
            }
            else
            {
                MessageBox.Show("Soubor se nepovedlo otevřít./nSeznam souborů bude nyní aktualizován.");
                SourceCodes.ReloadSourceCodeFiles();
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
                int newIndex = lbObjects.SelectedIndex - 1;
                InputsOutputs.Swap(lbObjects.SelectedIndex, newIndex);
                InputsOutputsOnInOutListChanged(this, new EventArgs());
                lbObjects.SelectedIndex = newIndex;
            }
            CheckIfMathInOutputRandomNumbersIsValid();
        }

        private void CheckIfMathInOutputRandomNumbersIsValid()
        {
            foreach (OutputNumberBasedOnRandomInput form in InputsOutputs.GetList(typeof(OutputNumberBasedOnRandomInput)))
            {
                if (form.IsMathValid()) continue;
                MessageBox.Show("Požadovaná náhodná čísla nelze nadále použít!");
                SideFormManager.ShowExisting(form);
            }
        }

        private void butMoveDown_Click(object sender, EventArgs e)
        {
            if (lbObjects.SelectedIndex != -1 && lbObjects.SelectedIndex != lbObjects.Items.Count - 1)
                //if theres any selected item and it isnt bottom one;
            {
                int newIndex = lbObjects.SelectedIndex + 1;
                InputsOutputs.Swap(lbObjects.SelectedIndex, newIndex);
                InputsOutputsOnInOutListChanged(this, new EventArgs());
                lbObjects.SelectedIndex = newIndex;
            }
            CheckIfMathInOutputRandomNumbersIsValid();
        }

        private void butExport_Click(object sender, EventArgs e)
        {
            if (lbObjects.Items.Count > 0)
            {
                var saveXml = new SaveFileDialog();
                saveXml.Filter = @"XML files (*.xml)|*.xml";
                if (saveXml.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XmlManager.Export(saveXml.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nepodařilo se exportovat data do XML souboru."); //todo catching general Exception is bad idea
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

            var openXml = new OpenFileDialog();
            openXml.Filter = "XML soubory (*.xml)|*.xml";
            if (openXml.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                XmlManager.Import(openXml.FileName);
            }
            #region expetion handling
            catch (FormatException)
            {
                MessageBox.Show("Zvolený XML soubor není podporován.");
            }
            catch (InvalidDataException exception)
            {
                MessageBox.Show(exception.Message + "není podporován a nebyl importován.");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor nebyl nalezen");
            }
            catch (Exception)
            {
                MessageBox.Show("Během importu se vyskytla chyba!");
                InputsOutputs.Clear();
            }
            #endregion

        }

        private void butRunTest_Click(object sender, EventArgs e)
        {
            if (!SourceCodes.GetSourceCodeFiles().Any())
            {
                MessageBox.Show("Ve zvolené složce nejsou žádné zdrojové kódy!");
                Tabs.SelectedIndex = 0;
                return;
            }

            if (!InputsOutputs.GetList().Any())
            {
                MessageBox.Show("Musíte nejdříve vytvořit testovací protokol!");
                Tabs.SelectedIndex = 1;
                return;
            }

            //todo mozna vypnout UI?
            Tabs.SelectedIndex = 0;
            SetListViewToGrepMode(); //todo GREP!
            butShowTestProgress.Visible = true;
            lbCodes.ClearSelected();
            rtbCode.Clear();

            TestManager.TestAllSourceCodes();
        }

        private void SetListViewToGrepMode() //todo GREP!
        {
            butOpenFile.Visible = false;

            TestResult.ResultReady += ResultReady;
            lV.ItemSelectionChanged += lV_ItemSelectionChanged;
            lV.Items.Clear();
            lV.Columns.Clear();

            lV.Columns.Add("Jméno souboru", 250);
            lV.Columns.Add("Stav", 249);

            foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
            {
                //todo refaktorovat
                if (code.GetResult() != null)
                {
                    var line = new ListViewItem(new[] {code.Name, code.GetResult().Status});
                    line.UseItemStyleForSubItems = false;
                    line.SubItems[1].ForeColor = GetStatusColor(code.GetResult().Status);
                    lV.Items.Add(line);
                }
                else
                {
                    var line = new ListViewItem(new[] {code.Name, "testuje se"});
                    line.UseItemStyleForSubItems = false;
                    line.SubItems[1].ForeColor = Color.Orange;
                    lV.Items.Add(line);
                }
            }
        }

        private void lV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            lV.ItemSelectionChanged -= lV_ItemSelectionChanged;
            lbCodes.SelectedIndex = e.ItemIndex;
        }

        private void SetListViewToBananaMode(TestResult result) //todo BANANA!
        {
            butOpenFile.Visible = true;

            lV.Items.Clear();
            lV.Columns.Clear();
            lV.Groups.Clear();


            lV.Groups.Add(new ListViewGroup("Vstup"));
            lV.Groups.Add(new ListViewGroup("Výstup"));

            lV.Columns.Add("Vstup/Výstup", 250);
            lV.Columns.Add("Očekávaný výstup", 249);

            if (result == null)
                return;

            foreach (string input in result.Inputs)
                lV.Items.Add(new ListViewItem(new[] {input, ""}, lV.Groups[0]));

            foreach (KeyValuePair<string, string> output in result.Outputs)
            {
                var line = new ListViewItem(new[] {output.Key, output.Value}, lV.Groups[1]);
                if (result.LinesWithBadOutput.Contains(lV.Items.Count - result.Inputs.Count))
                    line.BackColor = Color.Red;
                lV.Items.Add(line);
            }

            if (result.Errors.Length != 0)
            {
                lV.Groups.Add(new ListViewGroup("Errory"));
                foreach (string s in result.Errors.Split(new[] {Environment.NewLine}, StringSplitOptions.None))
                {
                    var line = new ListViewItem(s, lV.Groups[2]);
                    line.BackColor = Color.Red;
                    lV.Items.Add(line);
                }
            }
        }

        private void ResultReady(object sender, TestResultArgs testResultArgs)
        {
            Invoke(new UpdateResultInvoker(UpdateRusult), testResultArgs.Result);
        }

        private void UpdateRusult(TestResult result)
        {
            ListViewItem line = lV.FindItemWithText(result.FileName);
            line.SubItems[1].Text = result.Status;

            Color color = GetStatusColor(result.Status);

            line.SubItems[1].ForeColor = color;
        }

        private static Color GetStatusColor(string status)
        {
            Color color;
            switch (status)
            {
                case "OK":
                    color = Color.Green;
                    break;
                case "testuje se":
                    color = Color.Orange;
                    break;
                default:
                    color = Color.Red;
                    break;
            }
            return color;
        }

        private void butShowTestProgress_Click(object sender, EventArgs e)
        {
            lbCodes.ClearSelected();
            SetListViewToGrepMode();
        }

        private delegate void UpdateResultInvoker(TestResult result);

        private void butOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SourceCodes.GetSourceCode(lbCodes.SelectedIndex).Path);
        }
    }
}