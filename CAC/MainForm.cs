﻿#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aGrader.IOForms;
using aGrader.Properties;
using aGrader.sourceCodes;

#endregion

namespace aGrader
{
    public partial class aGrader : Form
    {
        public aGrader()
        {
            InitializeComponent();
            FillCbObjects();
            cbobjects.SelectedIndexChanged += cbobjects_SelectedIndexChanged;
            LocationChanged += aGrader_LocationChanged;
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
            var languageSelect = new LanguageSelection {Location = new Point(Location.X + 525, Location.Y + 45)};
            if (languageSelect.ShowDialog() == DialogResult.OK)
                UpdateLbCodes();
            tbpath.Text = SourceCodes.GetPath();
        }

        private void UpdateLbCodes()
        {
            butShowTests.Visible = false;
            lV.Clear();
            ResetProgressBar();
            lErrorMessage.Text = "";
            ErrorTooltip.SetToolTip(lErrorMessage,lErrorMessage.Text);
            lbCodes.Items.Clear();
            if (SourceCodes.GetSourceCodeFiles().Count != 0)
            {
                foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
                {
                    lbCodes.Items.Add(code);
                }
                SourceCodes.GetCompilationErrorsAsync();
            }
            else
                MessageBox.Show(Resources.NoValidFilesFound);
            rtbCode.Clear();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            lErrorMessage.Text = "";
            if (!Directory.Exists(SourceCodes.GetPath()))
            {
                MessageBox.Show(Resources.DirectoryDoesNotExist);
                SourceCodes.ClearPath();
                return;
            }
            SourceCodes.ReloadFiles();
            if (SourceCodes.IsDirectorySet())
                UpdateLbCodes();
            else
                MessageBox.Show(Resources.MainForm_YouHaveToSelectDirectoryWithSourceCodes);
        }

        private void lbCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lErrorMessage.Text = "";
            ErrorTooltip.SetToolTip(lErrorMessage, lErrorMessage.Text);
            if (lbCodes.SelectedItem == null) return;
            SourceCode code = SourceCodes.GetSourceCode(lbCodes.SelectedIndex);

            SetListViewToCodeMode(code);

            if (code.Exists())
            {
                rtbCode.Text = $"{code.GetSourceCode()} \n";
                foreach (var compilationError in code.CompilationErrors)
                {
                    lErrorMessage.Text = Resources.CannotCompile;
                    if (compilationError.Item2!=null)
                    {
                        rtbCode.Select(rtbCode.GetFirstCharIndexFromLine((int)compilationError.Item2), rtbCode.Lines[(int)compilationError.Item2].Length);
                        rtbCode.SelectionBackColor = Color.Red;
                    }
                    ErrorTooltip.SetToolTip(lErrorMessage, $"{ErrorTooltip.GetToolTip(lErrorMessage)}\n{compilationError.Item1}");
                }
            }
            else
            {
                MessageBox.Show(Resources.MainForm_CannotOpenFile);
                SourceCodes.ReloadFiles();
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

        private void aGrader_LocationChanged(object sender, EventArgs e)
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
                MessageBox.Show(Resources.MainForm_CantUseRequestedGeneratedNumbers);
                SideFormManager.ShowExisting(form);
                return;
            }
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
            if (lbObjects.Items.Count == 0)
            {
                MessageBox.Show(Resources.MainForm_NothingToExport);
                return;
            }
            var saveXml = new SaveFileDialog {Filter = @"XML files (*.xml)|*.xml"};
            if (saveXml.ShowDialog() == DialogResult.OK)
            {
                XmlManager.Export(saveXml.FileName);
            }
        }

        private void lbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbObjects.SelectedItem != null)
            {
                SideFormManager.ShowExisting(InputsOutputs.GetIOForm(lbObjects.SelectedIndex));
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (lbObjects.Items.Count != 0 &&
                MessageBox.Show(Resources.MainForm_InputsAndOutputsWillBeOverwriten, Resources.Warning, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

            InputsOutputs.Clear();

            var openXml = new OpenFileDialog {Filter = Resources.FileFilter_XML};
            if (openXml.ShowDialog() == DialogResult.OK)
                XmlManager.Import(openXml.FileName);

        }

        private void butRunTest_Click(object sender, EventArgs e)
        {
            if (!SourceCodes.GetSourceCodeFiles().Any())
            {
                MessageBox.Show(Resources.MainForm_NoSourceCodesInSelectedDirectory);
                Tabs.SelectedIndex = 0;
                return;
            }

            if (!InputsOutputs.GetList().Any())
            {
                MessageBox.Show(Resources.MainForm_YouNeedToCreateTestProtocolFirst);
                Tabs.SelectedIndex = 1;
                return;
            }

            //todo It would be maybe good to turn down UI
            butChart.Enabled = false;
            butChart.Visible = true;
            butSaveLog.Enabled = false;
            butSaveLog.Visible = true;
            butRunTest.Enabled = false;
            Tabs.SelectedIndex = 0;
            SetListViewToTestMode();
            butShowTests.Visible = true;
            lbCodes.ClearSelected();
            rtbCode.Clear();
            ResetProgressBar();
            SetListViewToTestMode();
            SourceCodes.RemoveResults();
            AddLineToLog(Resources.MainForm_StartingTests);
            AddLineToLog(string.Format(Resources.MainForm_NumberOfFiles, SourceCodes.GetSourceCodeFiles().Count));
            TestManager.TestAllSourceCodes();
        }

        private void ResetProgressBar()
        {
            progressBar.Maximum = SourceCodes.GetSourceCodeFiles().Count;
            progressBar.Value = 0;
        }

        private void AddLineToLog(string text)
        {
            rtbCode.AppendText($"\n {DateTime.Now.ToLongTimeString()} | {text}");
        }

        private void SetListViewToTestMode()
        {
            butChart.Visible = true;
            butSaveLog.Visible = true;
            butOpenFile.Visible = false;
            TestManager.ResultReady -= ResultReady;
            TestManager.ResultReady += ResultReady;
            lV.ItemSelectionChanged += lV_ItemSelectionChanged;
            lV.Items.Clear();
            lV.Columns.Clear();

            lV.Columns.Add(Resources.NameOfFile, 250);
            lV.Columns.Add(Resources.Status, 249);

            foreach (var code in SourceCodes.GetSourceCodeFiles())
            {
                if (code.TestResult != null)
                {
                    var line =
                        new ListViewItem(new[]
                        {code.Name, (code.TestResult.IsOk != null && (bool) code.TestResult.IsOk) ? "OK" : "Error"})
                        {
                            UseItemStyleForSubItems = false
                        };
                    line.SubItems[1].ForeColor = GetStatusColor(code.TestResult.IsOk);
                    lV.Items.Add(line);
                }
                else
                {
                    var line = new ListViewItem(new[] {code.Name, Resources.TestInProgress}) {UseItemStyleForSubItems = false};
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
            butChart.Visible = false;
            butSaveLog.Visible = false;

            lV.Items.Clear();
            lV.Columns.Clear();
            lV.Groups.Clear();


            lV.Groups.Add(new ListViewGroup(Resources.Input));
            lV.Groups.Add(new ListViewGroup(Resources.Output));

            lV.Columns.Add(Resources.InputOutput, 250);
            lV.Columns.Add(Resources.ExpectedOutput, 249);

            if (code.TestResult == null)
                return;

            foreach (var input in code.TestResult.Protocol.Inputs)
                lV.Items.Add(new ListViewItem(new[] {input, ""}, lV.Groups[0]));

            for (var i = 0; i < code.TestResult.Outputs.Count; i++)
            {
                var line=new ListViewItem(new[] { code.TestResult.Outputs[i], code.TestResult.ExpectedOutputs[i].ToString() }, lV.Groups[1]);
                if (code.TestResult.BadOutputs.Contains(i))
                    line.BackColor = Color.Red;
                lV.Items.Add(line);
            }

            if (code.TestResult.Errors.Count == 0) return;
            lV.Groups.Add(new ListViewGroup(Resources.Errors));
            foreach (var error in code.TestResult.Errors)
            {
                var line = new ListViewItem(error, lV.Groups[2]) {BackColor = Color.Red};
                lV.Items.Add(line);
            }
        }

        private void ResultReady(object sender, ResultReadyArgs testResultArgs)
        {
            SetListViewToTestMode();
            ListViewItem line = lV.FindItemWithText(testResultArgs.Result.FileName);
            line.SubItems[1].Text = (testResultArgs.Result.IsOk != null && (bool)testResultArgs.Result.IsOk) ? "OK" : "Error";

            Color color = GetStatusColor(testResultArgs.Result.IsOk);

            line.SubItems[1].ForeColor = color;
            progressBar.PerformStep();
            AddLineToLog(string.Format(Resources.MainForm_FileWasSuccessfulyTested, testResultArgs.Result.FileName));
            CheckIfAllTestsAreDone();
        }

        private void CheckIfAllTestsAreDone()
        {
            if (progressBar.Value==progressBar.Maximum)
            {
                rtbCode.Clear();
                AddLineToLog(Resources.MainForm_AllTestsWereFinnished);
                rtbCode.Text = BuildTestResultsString();
                butRunTest.Enabled = true;
                butChart.Enabled = true;
                butSaveLog.Enabled = true;

            }
        }

        private static Color GetStatusColor(bool? status)
        {
            var color=new Color();
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
            rtbCode.Text = BuildTestResultsString();
            lbCodes.ClearSelected();
            SetListViewToTestMode();
        }

        private string BuildTestResultsString()
        {
            var sb=new StringBuilder();
            
            foreach (var result in SourceCodes.GetSourceCodeFiles().Where(t=>t.TestResult!=null).Select(t=>t.TestResult))
            {
                var name = result.FileName;
                var correctOutputsCount = result.CorrectOutputsCount.ToString();
                var wrongOutputsCount = result.WrongOutputsCount.ToString();
                sb.AppendFormat(Resources.MainForm_TestResultLine, correctOutputsCount, wrongOutputsCount, result.ProcessorTime.ToString().PadRight(15 - result.ProcessorTime.ToString().Length), name);
                
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void butOpenFile_Click(object sender, EventArgs e)
        {
            Process.Start(SourceCodes.GetSourceCode(lbCodes.SelectedIndex).Path);
        }

        private Graph _graphForm;

        private void butChart_Click(object sender, EventArgs e)
        {
            _graphForm?.Close();
            _graphForm=new Graph();
            _graphForm.Show();

        }

        private void butSaveLog_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".txt",
                Filter = Resources.FileFilter_TXT
            };

            if (saveFile.ShowDialog() != DialogResult.OK) return;
            try
            {
                using (var sw=new StreamWriter(saveFile.FileName,false,Encoding.Unicode))
                {
                    sw.Write(rtbCode.Text.Replace("  "," "));
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(string.Format(Resources.MainForm_CouldNotCreateTextFile, Path.GetFileName(saveFile.FileName)));
                ExceptionsLog.LogException(ex.ToString());
            }
        }
    }
}