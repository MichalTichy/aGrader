using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CAC.sourceCodes;

namespace CAC
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            cbSort.SelectedIndex = 0;
            SetupGrapth();
            LoadGraph();
        }

        public void LoadGraph()
        {
            IOrderedEnumerable<SourceCode> codes = GetSortedCodes();
            chartResults.Series[0].Points.Clear();
            chartResults.Series[1].Points.Clear();
            chartResults.Series[2].Points.Clear();

            chartBIG.Series[0].Points.Clear();
            chartBIG.Series[1].Points.Clear();
            chartBIG.Series[2].Points.Clear();

            foreach (SourceCode code in codes)
            {
                string name= code.Name;
                int correct;
                int wrong;
                double processorTime;
                GetData(code, out correct, out wrong, out processorTime);

                chartResults.Series[0].Points.AddXY(name, correct);
                chartResults.Series[1].Points.AddXY(name, wrong);
                chartResults.Series[2].Points.AddXY(name, processorTime);

                chartBIG.Series[0].Points.AddXY(name, correct);
                chartBIG.Series[1].Points.AddXY(name, wrong);
                chartBIG.Series[2].Points.AddXY(name, processorTime);
            }
        }

        private IOrderedEnumerable<SourceCode> GetSortedCodes()
        {
            switch (cbSort.SelectedIndex)
            {
                case 0: return SourceCodes.GetSourceCodeFiles().OrderBy(t=>t.Name);
                case 1: return SourceCodes.GetSourceCodeFiles().OrderByDescending(t=>t.TestResult.CorrectOutputsCount);
                case 2: return SourceCodes.GetSourceCodeFiles().OrderByDescending(t=>t.TestResult.WrongOutputsCount);
                case 3: return SourceCodes.GetSourceCodeFiles().OrderBy(t=>t.TestResult.ProcessorTime);
                default: return SourceCodes.GetSourceCodeFiles().OrderBy(t=>t.Name);
            }
        }

        private void SetupGrapth()
        {
            chartResults.ChartAreas.First().AxisX.ScrollBar.Size = 10;
            chartResults.ChartAreas.First().AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartResults.ChartAreas.First().AxisX.ScrollBar.IsPositionedInside = true;
            chartResults.ChartAreas.First().AxisX.ScrollBar.Enabled = true;
            
            chartResults.ChartAreas.First().AxisX.ScaleView.Zoom(0, 8);
        }

        private static void GetData(SourceCode code, out int correct, out int wrong, out double processorTime)
        {
            if (code.TestResult == null)
            {
                correct = 0;
                wrong = 0;
                processorTime = 0;
            }
            else
            {
                correct = code.TestResult.CorrectOutputsCount;
                wrong = code.TestResult.WrongOutputsCount;
                processorTime = code.TestResult.ProcessorTime;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chartResults.Series[0].Enabled = cbCorrect.Checked;
            chartResults.Series[1].Enabled = cbWrong.Checked;
            chartResults.Series[2].Enabled = cbProcessorTime.Checked;

            chartBIG.Series[0].Enabled = cbCorrect.Checked;
            chartBIG.Series[1].Enabled = cbWrong.Checked;
            chartBIG.Series[2].Enabled = cbProcessorTime.Checked;

            LoadGraph();
            
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGraph();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (saveImage.ShowDialog()==DialogResult.OK)
            {
                chartBIG.SaveImage(saveImage.FileName,ChartImageFormat.Bmp);
            }
        }
    }
}
