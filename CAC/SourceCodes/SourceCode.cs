#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace CAC.sourceCodes
{
    public class SourceCode
    {

        public readonly string Name;
        public readonly string Path;
        public string CompilationErrorMsg;
        public int? NumberOfLineWithError;

        private Process _app;
        private TestResult _testResult;
        
        public TestResult TestResult
        {
            get { return _testResult; }
        }
        public SourceCode(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(path); //todo exception on IO fail
        }

        public void GetCompilationError()
        {
            Tuple<string, int?> compilationError = Test.GetCompilationError(this);

            if (compilationError.Item1 != null)
            {
                CompilationErrorMsg = compilationError.Item1;
                NumberOfLineWithError = compilationError.Item2;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetSourceCode()
        {
            return File.ReadAllText(Path);
        }

        public bool Exists()
        {
            return File.Exists(Path);
        }

        public void AddTestResult(TestResult result)
        {
            _testResult = result;
        }
    }
}