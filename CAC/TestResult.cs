﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using CAC.Math;

#endregion

namespace CAC
{
    public class TestResultArgs : EventArgs
    {
        public TestResult Result { get; set; }
    }

    public class TestResult
    {
        public readonly string FileName;
        public readonly int ProcessorTime;
        public List<string> inputs;
        public List<int> LinesWithBadOutput = new List<int>();
        public List<KeyValuePair<string, string>> Outputs;
        public string status = "testuje se";

        public TestResult(List<string> inputs, string outputs, List<KeyValuePair<string, OutputType>> expectedOutputs,
            string errors, int processorTime, string fileName)
        {
            //todo refaktorovat
            Outputs = parseOutputs(outputs, expectedOutputs);
            Errors = errors;
            ProcessorTime = processorTime;
            FileName = fileName;
            this.inputs = inputs;

            EvaluateResult();
        }

        public string Errors { get; private set; }
        public static event EventHandler<TestResultArgs> ResultReady;

        protected virtual void OnResultReady(TestResult result)
        {
            if (ResultReady != null)
                ResultReady(this, new TestResultArgs {Result = result});
        }

        private void EvaluateResult()
        {
            if (LinesWithBadOutput.Count == 0 && Errors.Length == 0)
                status = "OK";
            else
                status = "Test neproběhl úspěšně";
            OnResultReady(this);
        }

        private List<KeyValuePair<string, string>> parseOutputs(string output,
            List<KeyValuePair<string, OutputType>> expectedOutputs)
        {
            //todo asi refaktor
            string[] outputs = output.Replace("\r", "").Split('\n');
            var outDictionary = new List<KeyValuePair<string, string>>();

            int i = ((expectedOutputs.Count >= outputs.Count()) ? expectedOutputs.Count : outputs.Count());
            for (int a = 0; a < i; a++)
            {
//-1 to get index from count
                if (expectedOutputs.Count > i)
                    outDictionary.Add(EvaluateOutput(outputs[a],
                        new KeyValuePair<string, OutputType>("", OutputType.None), a));
                else if (outputs.Count() > i)
                    outDictionary.Add(EvaluateOutput("", expectedOutputs[a], a));
                else
                    outDictionary.Add(EvaluateOutput(outputs[a], expectedOutputs[a], a));
            }

            return outDictionary;
        }

        private KeyValuePair<string, string> EvaluateOutput(string output,
            KeyValuePair<string, OutputType> expectedOutput, int line)
        {
            if (output == "")
            {
                LinesWithBadOutput.Add(line);
                return new KeyValuePair<string, string>("", expectedOutput.Key);
            }

            switch (expectedOutput.Value)
            {
                case OutputType.None:
                    LinesWithBadOutput.Add(line);
                    return new KeyValuePair<string, string>(output, "");
                case OutputType.Number:
                    EvaluateNumericOutput(output, expectedOutput.Key, line);
                    break;
                case OutputType.Text:
                    EvaluateTextOutput(output, expectedOutput.Key, line);
                    break;
                case OutputType.Math:
                    EvaluateMathOutput(output, expectedOutput.Key.Replace("X", output), line);
                    return new KeyValuePair<string, string>(output, expectedOutput.Key.Replace("\n", " && "));
                default:
                    LinesWithBadOutput.Add(line);
                    break;
            }
            return new KeyValuePair<string, string>(output, expectedOutput.Key);
        }

        private void EvaluateMathOutput(string output, string expectedOutput, int line)
        {
            bool ok = true;
            foreach (string condition in expectedOutput.Split('\n'))
            {
                var math = new Equation(condition.Split('=')[0].Replace(" ", ""), decimal.Parse(output));
                double d1 = math.Evaluate();
                double d2 = double.Parse(condition.Split('=')[1].Replace(" ", ""));

                if ((System.Math.Abs(d1 - d2) < TestManager.Deviation)) continue;
                ok = false;
                break;
            }
            if (!ok)
                LinesWithBadOutput.Add(line);
        }

        private void EvaluateTextOutput(string output, string expectedOutput, int line)
        {
            if (output != expectedOutput)
            {
                LinesWithBadOutput.Add(line);
            }
        }

        private void EvaluateNumericOutput(string output, string expectedOutput, int line)
        {
            output = output.Replace('.', ',');
            expectedOutput = expectedOutput.Replace('.', ',');
            if (System.Math.Abs(decimal.Parse(output) - decimal.Parse(expectedOutput)) > (decimal) TestManager.Deviation)
                LinesWithBadOutput.Add(line);
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