#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using aGrader.Mathematic;

#endregion

namespace aGrader
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
        private Queue<string> _realOutputs; 
        public ReadOnlyCollection<string> Errors

        {
            get { return _errors.AsReadOnly(); }
        }
        public ReadOnlyCollection<string> Outputs
        {
            get { return _outputs.AsReadOnly(); }
        }

        public int CorrectOutputsCount => _errors.Count == 0
            ? _expectedOutputs.Count - _badOutputs.Count
            : 0;
        public int WrongOutputsCount => _errors.Count == 0
            ? _badOutputs.Count
            : _expectedOutputs.Count;

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
            _realOutputs=new Queue<string>(_outputs);
            
            foreach (dynamic expectedOutput in _expectedOutputs)
            {
                var realOutput = _realOutputs.Dequeue();
                if (string.IsNullOrEmpty(realOutput) || !CompareRealAndExpectedOutput(realOutput,expectedOutput))
                {
                    _badOutputs.Add(_outputs.Count-_realOutputs.Count-1); //add id of last deleted item
                }
            }

            IsOk = (_errors == null || _errors.Count == 0) && (_badOutputs == null || _badOutputs.Count == 0);
        }

        private bool CompareRealAndExpectedOutput(string realOutput, TextData expectedOutput)
        {
            return realOutput == expectedOutput.Data;
        }
        private bool CompareRealAndExpectedOutput(string realOutput, NumberData expectedOutput)
        {
            //removes formating
            realOutput = realOutput.Replace('.', ',');


            NumberFormatInfo numberFormats = CultureInfo.CurrentCulture.NumberFormat;

            if (expectedOutput.ToString().Contains(numberFormats.PositiveInfinitySymbol) ||
                expectedOutput.ToString().Contains(numberFormats.NegativeInfinitySymbol))
                return false;

            return Math.Abs(decimal.Parse(realOutput) - decimal.Parse(expectedOutput.ToString())) <= (decimal) Protocol.MaximumDeviation;
        }

        private bool CompareRealAndExpectedOutput(string realOutput, NumberMatchingConditionsData expectedOutput)
        {
            //removes formating
            realOutput = realOutput.Replace('.', ',');
            var value = decimal.Parse(realOutput);

            return expectedOutput.Conditions.All(condition => new BooleanExpresion(condition, value).Evaluate());
        }
        private bool CompareRealAndExpectedOutput(string realOutput, FileHashData data)
        {
            return realOutput == data.ToString();
        }

        private bool CompareRealAndExpectedOutput(string realOutput, LineFromTextFileData data)
        {
            return realOutput == data.ToString();
        }


        private bool CompareRealAndExpectedOutput(string realOutput, ErrorData expectedOutput)
        {
            return false;
        }

        public void AddErrors(string error, bool insertAtTheBegining=false)
        {
            if (string.IsNullOrEmpty(error))
                return;
            if (insertAtTheBegining)
            {
                _errors.InsertRange(0,error.Split('\n'));
            }
            else
            {
                _errors.AddRange(error.Split('\n'));
            }
            IsOk = (_errors == null || _errors.Count == 0) && (_badOutputs == null || _badOutputs.Count == 0);
        }
    }
}