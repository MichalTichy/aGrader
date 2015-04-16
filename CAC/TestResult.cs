using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAC
{
    public class TestResultArgs : EventArgs
    {
        public TestResult Result { get; set; }
    }

    public class TestResult
    {
        public readonly string FileName;
        public List<KeyValuePair<string, string>> Outputs;
        public List<string> inputs; 
        public readonly int ProcessorTime;
        public string Errors { get; private set; }
        public List<int> LinesWithBadOutput=new List<int>(); 
        public string status="testuje se";


        public static event EventHandler<TestResultArgs> ResultReady;

        protected virtual void OnResultReady(TestResult result)
        {
            if (ResultReady != null)
                ResultReady(this, new TestResultArgs() {Result = result});
        }

        public TestResult(List<string> inputs,string outputs, List<string> expectedOutputs, string errors, int processorTime, string fileName)
        {
            //todo refaktorovat
            Outputs = parseOutputs(outputs, expectedOutputs);
            Errors = errors;
            ProcessorTime = processorTime;
            FileName = fileName;
            this.inputs = inputs;

            FindLinesWithBadOutputs();
            EvaluateResult();
        }

        private void EvaluateResult()
        {
            if (LinesWithBadOutput.Count == 0 && Errors.Length == 0)
                status = "OK";
            else
                status = "Test neproběhl úspěšně";
            OnResultReady(this);
        }

        private List<KeyValuePair<string, string>> parseOutputs(string output, List<string> expectedOutputs)
        {
            //todo asi refaktor
            string[]outputs=output.Replace("\r","").Split('\n');
            List<KeyValuePair<string, string>> outDictionary = new List<KeyValuePair<string, string>>();

            int i = ((expectedOutputs.Count >= outputs.Count()) ? expectedOutputs.Count : outputs.Count());
            for (int a = 0; a < i; a++)
            {//-1 to get index from count
                if (expectedOutputs.Count >i)
                    outDictionary.Add(new KeyValuePair<string, string>(outputs[a], ""));
                else if (outputs.Count() >i)
                    outDictionary.Add(new KeyValuePair<string, string>("", expectedOutputs[a]));
                else
                    outDictionary.Add(new KeyValuePair<string, string>(outputs[a], expectedOutputs[a]));
            }

            return outDictionary;
        }

        private void FindLinesWithBadOutputs()
        {
            foreach (KeyValuePair<string, string> output in Outputs)
            {
                try
                {
                    string value1 = output.Key.Replace('.', ',');
                    string value2 = output.Value.Replace('.', ',');
                    if (System.Math.Abs(decimal.Parse(value1) - decimal.Parse(value2))>(decimal)TestManager.Deviation)
                        LinesWithBadOutput.Add(Outputs.IndexOf(output));
                    continue;
                }
                catch (Exception)
                {
                    // ignored
                }
                if (output.Key != output.Value)
                    LinesWithBadOutput.Add(Outputs.IndexOf(output));
            }
        }

        public void AddError(string errorMsg)
        {
            if (Errors.Length != 0)
                Errors += "\n";
            Errors += errorMsg;
            EvaluateResult();
        }
    }
}
