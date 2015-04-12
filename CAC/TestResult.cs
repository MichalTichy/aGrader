using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAC
{
    public class TestResult
    {
        public readonly string FileName;
        public readonly string Outputs;
        public readonly int ProcessorTime;
        public string Errors { get; private set; }
        public int[] LinesWithBadOutputs;
        public string[] expectedOutputs;
        public string status="testuje se";

        public TestResult(string outputs, string errors, int processorTime, string fileName)
        {
            Outputs = outputs;
            Errors = errors;
            ProcessorTime = processorTime;
            FileName = fileName;
        }

        public void AddError(string errorMsg)
        {
            if (Errors.Length != 0)
                Errors += "\n";
            Errors += errorMsg;
        }
    }
}
