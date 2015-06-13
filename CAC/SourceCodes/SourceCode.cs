#region

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace CAC.sourceCodes
{
    public class SourceCode
    {
        private const int Timeout = 45000;
        public readonly string Name;
        //todo seradit public a private
        public readonly string Path;
        private Process _app;
        private string _compilationErrorMsg;
        private List<string> _testErrors = new List<string>();
        private TestResult _testResult;

        public SourceCode(string path)
        {
            string pathToTcc = Directory.GetCurrentDirectory() + @"\tcc\tcc.exe";
            _app = new Process
            {
                StartInfo =
                {
                    FileName = pathToTcc,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = "-run " + path
                }
            };
            Path = path;
            Name = System.IO.Path.GetFileName(path);
            _compilationErrorMsg = GetError();
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetSourceCode()
        {
            return File.ReadAllText(Path);
        }

        private string GetError()
        {
            _app.Start(); //todo narvat do jineho vlakna (background workeru)
            if (!_app.WaitForExit(300))
                _app.Kill();
            string errors = _app.StandardError.ReadLine();

            return errors;
        }

        public string GetCompilationErrorMessage()
        {
            return _compilationErrorMsg;
        }

        public int GetIdOfLineWithError()
        {
            //todo remove magic numbers
            if (_compilationErrorMsg == null)
                return -1;
            var newRegex = new Regex(@":(\d*):");
            return int.Parse(newRegex.Match(_compilationErrorMsg).ToString().Replace(":", "")) - 2;
        }

        public bool Exists()
        {
            if (File.Exists(Path))
                return true;
            return false;
        }

        public TestResult RunTest(List<string> inputs, List<KeyValuePair<string, OutputType>> expectedOutputs)
        {
            _app.Start();

            StreamWriter inputWriter = _app.StandardInput;
            StreamReader outputReader = _app.StandardOutput;
            StreamReader errorReader = _app.StandardError;

            foreach (string input in inputs)
                inputWriter.WriteLine(input);

            string output = "";
            string error = "";
            if (!_app.WaitForExit(Timeout))
            {
                _app.Kill();
                error += "Aplikace nebyla ukonžena před timeoutem (" + Timeout/1000 + "s)\n";
            }
            output += outputReader.ReadToEnd();
            error += errorReader.ReadToEnd();
            int processorTime = (int) _app.TotalProcessorTime.TotalMilliseconds;
            var result = new TestResult(inputs, output, expectedOutputs, error, processorTime, Name);
            _testResult = result;
            foreach (string testError in _testErrors)
            {
                _testResult.AddError(testError);
            }
            return result;
        }

        public TestResult GetResult()
        {
            return _testResult;
        }

        public void AddTestError(string error)
        {
            _testErrors.Add(error);
        }
    }
}