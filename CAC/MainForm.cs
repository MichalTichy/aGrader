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
        //todo pocet cisel splnujicich podminky
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
            lErrorMessage.Text = "";
            SourceCodes.ReloadSourceCodeFiles();
            SourceCodes.GetCompilationErrorsAsync();
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
            lErrorMessage.Text = "";
            if (lbCodes.SelectedItem == null) return;
            SourceCode code = SourceCodes.GetSourceCode(lbCodes.SelectedIndex);

            SetListViewToCodeMode(code);

            if (code.Exists())
            {
                rtbCode.Text = code.GetSourceCode() + "\n";
                if (code.NumberOfLineWithError!=null)
                {
                    int lineWithError = (int)code.NumberOfLineWithError;
                    rtbCode.Select(rtbCode.GetFirstCharIndexFromLine(lineWithError), rtbCode.Lines[lineWithError].Length);
                    rtbCode.SelectionBackColor = Color.Red;
                    lErrorMessage.Text = "Kód nemůže být zkompilován!";
                }
                else if (code.CompilationErrorMsg!=null)
                {
                    lErrorMessage.Text = code.CompilationErrorMsg;
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
            CheckIfRequestedCountOfNumbersIsPossible();
            CheckIfLastActionInRepeatersIsValid();
        }

        private void CheckIfRequestedCountOfNumbersIsPossible()
        {
            foreach (OutputCountOfNumbersMatchingConditions form in InputsOutputs.GetList(typeof(OutputCountOfNumbersMatchingConditions)))
            {
                if (form.IsRequestedCountOfNumbersValid()) continue;
                SideFormManager.ShowExisting(form);
                return;
            }
        }

        private void CheckIfMathInOutputRandomNumbersIsValid()
        {
            foreach (OutputNumberBasedOnRandomInput form in InputsOutputs.GetList(typeof(OutputNumberBasedOnRandomInput)))
            {
                if (form.IsMathValid()) continue;
                MessageBox.Show("Požadovaná náhodná čísla nelze nadále použít!");
                SideFormManager.ShowExisting(form);
                return;
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
            CheckIfRequestedCountOfNumbersIsPossible();
            CheckIfLastActionInRepeatersIsValid();
        }

        private void CheckIfLastActionInRepeatersIsValid()
        {
            foreach (ActionRepeatLast repeater in InputsOutputs.GetList(typeof(ActionRepeatLast)))
            {
                if (!repeater.CheckIfPreviousActionIsRepeatable())
                {
                    SideFormManager.ShowExisting(repeater);
                    return;
                }
            }
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

            TestManager.ResultReady += ResultReady;
            lV.ItemSelectionChanged += lV_ItemSelectionChanged;
            lV.Items.Clear();
            lV.Columns.Clear();

            lV.Columns.Add("Jméno souboru", 250);
            lV.Columns.Add("Stav", 249);

            foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
            {
                //todo refaktorovat
                if (code.TestResult != null)
                {
                    var line = new ListViewItem(new[] {code.Name, (code.TestResult.IsOk != null && (bool)code.TestResult.IsOk) ? "OK" : "Error"});
                    line.UseItemStyleForSubItems = false;
                    line.SubItems[1].ForeColor = GetStatusColor(code.TestResult.IsOk);
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

        private void SetListViewToCodeMode(SourceCode code)
        {
            butOpenFile.Visible = true;

            lV.Items.Clear();
            lV.Columns.Clear();
            lV.Groups.Clear();


            lV.Groups.Add(new ListViewGroup("Vstup"));
            lV.Groups.Add(new ListViewGroup("Výstup"));

            lV.Columns.Add("Vstup/Výstup", 250);
            lV.Columns.Add("Očekávaný výstup", 249);

            if (code.TestResult == null)
                return;

            foreach (string input in code.TestResult.Protocol.Inputs)
                lV.Items.Add(new ListViewItem(new[] {input, ""}, lV.Groups[0]));

            for (int i = 0; i < code.TestResult.Outputs.Count; i++)
            {
                var line=new ListViewItem(new[] { code.TestResult.Outputs[i], code.TestResult.ExpectedOutputs[i].ToString() }, lV.Groups[1]);
                if (code.TestResult.BadOutputs.Contains(i))
                    line.BackColor = Color.Red;
                lV.Items.Add(line);
            }

            if (code.TestResult.Errors.Count == 0) return;
            lV.Groups.Add(new ListViewGroup("Errory"));
            foreach (string error in code.TestResult.Errors)
            {
                var line = new ListViewItem(error, lV.Groups[2]) {BackColor = Color.Red};
                lV.Items.Add(line);
            }
        }

        private void ResultReady(object sender, ResultReadyArgs testResultArgs)
        {
            ListViewItem line = lV.FindItemWithText(testResultArgs.Result.FileName);
            line.SubItems[1].Text = (testResultArgs.Result.IsOk != null && (bool)testResultArgs.Result.IsOk) ? "OK" : "Error";

            Color color = GetStatusColor(testResultArgs.Result.IsOk);

            line.SubItems[1].ForeColor = color;
        }

        private static Color GetStatusColor(bool? status)
        {
            Color color=new Color();
            switch (status)
            {
                case true:
                    color = Color.Green;
                    break;
                case null:
                    color = Color.Orange;
                    break;
                case false:
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