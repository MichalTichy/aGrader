#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CAC.Mathematic;

#endregion

namespace CAC
{
    public class TestResultArgs : EventArgs
    {
        public TestResult Result { get; set; }
    }

    public class TestResult
    {
        private List<string> _errors;
        private List<string> _outputs;
        private List<object> _expectedOutputs;
        private List<int> _badOutputs=new List<int>();
        public ReadOnlyCollection<string> Errors

        {
            get { return _errors.AsReadOnly(); }
        }
        public ReadOnlyCollection<string> Outputs
        {
            get { return _outputs.AsReadOnly(); }
        }

        public ReadOnlyCollection<object> ExpectedOutputs
        {
            get { return _expectedOutputs.AsReadOnly(); }
        }
        public ReadOnlyCollection<int> BadOutputs
        {
            get { return _badOutputs.AsReadOnly(); }
        }

        public readonly string FileName;
        public bool? IsOk { get; private set; }
        public readonly double ProcessorTime;
        public readonly TestProtocol Protocol;

        public TestResult(string fileName, TestProtocol protocol, List<string> outputs, List<string> errors, double procesorTime)
        {
            FileName = fileName;
            Protocol = protocol;
            _outputs = outputs;
            _errors = errors;
            _expectedOutputs=new List<object>();
            _expectedOutputs.AddRange(protocol.Outputs);
            ProcessorTime = procesorTime;

            EvaluateResults();
        }

        private void EvaluateResults()
        {
            BalanceNumberOfExpectedAndRealOutputs(); 
            var realOutputs=new Queue<string>(_outputs);
            
            foreach (dynamic expectedOutput in _expectedOutputs)
            {
                var realOutput = realOutputs.Dequeue();
                if (string.IsNullOrEmpty(realOutput) || !CompareRealAndExpectedOutput(realOutput,expectedOutput))
                {
                    _badOutputs.Add(_outputs.Count-realOutputs.Count-1); //add id of last deleted item
                }
            }

            IsOk = (_errors == null || _errors.Count == 0) && (_badOutputs == null || _badOutputs.Count == 0);
        }

        private void BalanceNumberOfExpectedAndRealOutputs()
        {
            while (_outputs.Count>_expectedOutputs.Count)
            {
                _expectedOutputs.Add(new ErrorData());
            }
            while (_expectedOutputs.Count>_outputs.Count)
            {
                _outputs.Add(null);
            }
        }

        private bool CompareRealAndExpectedOutput(string realOutput, TextData expectedOutput)
        {
            return realOutput == expectedOutput.Data;
        }
        private bool CompareRealAndExpectedOutput(string realOutput, NumberData expectedOutput)
        {
            //removes formating
            realOutput = realOutput.Replace('.', ',');
            string expectedFormatedOutput = expectedOutput.Data.ToString().Replace('.', ',');


            NumberFormatInfo numberFormats = CultureInfo.CurrentCulture.NumberFormat;

            if (expectedFormatedOutput.Contains(numberFormats.PositiveInfinitySymbol) ||
                expectedFormatedOutput.Contains(numberFormats.NegativeInfinitySymbol))
                return false;

            return Math.Abs(decimal.Parse(realOutput) - decimal.Parse(expectedFormatedOutput)) <= (decimal) Protocol.MaximumDeviation;
        }

        private bool CompareRealAndExpectedOutput(string realOutput, NumberMatchingConditionsData expectedOutput)
        {
            bool ok = true;
            foreach (string condition in expectedOutput.Conditions)
            {
                var math = new MathExpresion(condition.Split('=')[0].Replace(" ", ""), decimal.Parse(realOutput));
                double d1 = math.Evaluate();
                double d2 = double.Parse(condition.Split('=')[1].Replace(" ", ""));

                if ((Math.Abs(d1 - d2) < Protocol.MaximumDeviation)) continue;
                ok = false;
                break;
            }
            return ok;

        }
        private bool CompareRealAndExpectedOutput(string realOutput, ErrorData expectedOutput)
        {
            return false;
        }

    }
}