using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAC.IO_Forms;
using CAC.Math;
using CAC.SourceCodes;

namespace CAC
{
    public class TestResultArgs : EventArgs
    {
        public TestResult Result { get; set; }
        public List<string> ExpectedOutputs { get; set; }
    }
    public static class TestManager
    {
        public static EventHandler<TestResultArgs> TestFinished;

        private static void OnTestFinished(TestResult result)
        {
            if (TestFinished != null)
                TestFinished(typeof (TestManager), new TestResultArgs() {Result = result,ExpectedOutputs = _outputs});
        }
        private static List<string> _inputs = new List<string>();
        private static List<string> _outputs = new List<string>();
        private static Dictionary<string, decimal> _randomNumbers = new Dictionary<string, decimal>();
        private static BackgroundWorker bw=new BackgroundWorker(){WorkerSupportsCancellation = true};

        static TestManager()
        {
            bw.DoWork+=bw_DoWork;
        }

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (SourceCode code in SourceCodes.SourceCodes.GetSourceCodeFiles())
            {
                if (bw.CancellationPending)
                    return;
                TestResult result = code.RunTest(_inputs);
                EvaluateResult(result);
                OnTestFinished(result);
            }
        }

        private static void EvaluateResult(TestResult result)
        {
            string[]outputs=result.Outputs.Split('\n');
            List<int> linesWithBadOutput=new List<int>();

            if (_outputs.Count != outputs.Count())
                result.AddError("Neshodujese počet očekávaných a skutečných výstupů!");

            if (_outputs.Count>=outputs.Count())
            {
                for (int i = 0; i < _outputs.Count; i++)
                {
                    if (outputs.Count()<i || _outputs[i] != outputs[i]) //if is diferent or dont exist than the output is bad
                        linesWithBadOutput.Add(i);
                }
            }
            else
            {
                for (int i = 0; i < outputs.Count(); i++)
                {
                    if (_outputs.Count < i || outputs[i] != _outputs[i]) //if is diferent or dont exist than the output is bad
                        linesWithBadOutput.Add(i);
                }
            }
            
            result.LinesWithBadOutputs = linesWithBadOutput.ToArray();
        }

        public static void TestAllSourceCodes()
        {
            GetInputsAndOutputs();
            bw.RunWorkerAsync(); //todo osetrit aby nebylo mozne pokusit se spustit BW vícekrát (mozná predelat na thread)
        }

        private static void GetInputsAndOutputs()
        {
            _inputs.Clear();
            _outputs.Clear();
            _randomNumbers.Clear();
            foreach (var InOut in InputsOutputs.GetList())
                GetData(InOut);
        }

        private static void GetData(InputString input)
        {
            _inputs.Add(input.Text);
        }
        private static void GetData(InputNumber input)
        {
            _inputs.Add(input.Value.ToString());
        }
        private static void GetData(InputRandomNumber input)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            decimal num;
            if (input.Decimal)
            {
                decimal next = (decimal)random.NextDouble();
                num = input.Min + (next * (input.Max - input.Min));
            }
            else
            {
                num = random.Next((int)input.Min, (int)input.Max);
            }
            _inputs.Add(num.ToString());
            _randomNumbers.Add('X' + input.ID.ToString(), num);
            Thread.Sleep(1); //to ensure random numbers
        }
        private static void GetData(InputTextFile input)//todo dodělat
        {
            throw new NotImplementedException();
        }

        private static void GetData(OutputNumber output)
        {
            _outputs.Add(output.Value.ToString());
        }
        private static void GetData(OutputNumberBasedOnRandomInput output)
        {
            Equation equation = new Equation(output.jahoda, _randomNumbers);
            _outputs.Add(equation.Evaluate().ToString());
        }
        private static void GetData(OutputString output)
        {
            _outputs.Add(output.Text);
        }
    }
}
