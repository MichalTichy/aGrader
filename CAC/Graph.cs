using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAC.sourceCodes;

namespace CAC
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            LoadGraph();
        }

        private void LoadGraph()
        {
            chartResults.Series[0].Points.Clear();
            chartResults.Series[1].Points.Clear();
            chartResults.Series[2].Points.Clear();
            foreach (SourceCode code in SourceCodes.GetSourceCodeFiles())
            {
                string name= code.Name;
                int correct;
                int wrong;
                double processorTime;
                Correct(code, out correct, out wrong, out processorTime);

                chartResults.Series[0].Points.AddXY(name, correct);
                chartResults.Series[1].Points.AddXY(name, wrong);
                chartResults.Series[2].Points.AddXY(name, processorTime);
            }
        }

        private static void Correct(SourceCode code, out int correct, out int wrong, out double processorTime)
        {
            if (code.TestResult == null)
            {
                correct = 0;
                wrong = 0;
                processorTime = 0;
            }
            else
            {
                correct = code.TestResult.Errors.Count == 0
                    ? code.TestResult.ExpectedOutputs.Count - code.TestResult.BadOutputs.Count
                    : 0;
                wrong = code.TestResult.Errors.Count == 0
                    ? code.TestResult.BadOutputs.Count
                    : code.TestResult.ExpectedOutputs.Count;
                processorTime = code.TestResult.ProcessorTime;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chartResults.Series[0].Enabled = cbCorrect.Checked;
            chartResults.Series[1].Enabled = cbWrong.Checked;
            chartResults.Series[2].Enabled = cbProcessorTime.Checked;

            LoadGraph();
            
        }
    }
}
