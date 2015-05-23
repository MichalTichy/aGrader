using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAC.SourceCodes
{
    public class SourceCode
    {
        //todo seradit public a private
        public readonly string Path;
        private TestResult testResult;

        private Process _app;
        private const int timeout = 45000;
        public readonly string Name;
        private string _CompilationErrorMSG;
        private List<string> _testErrors=new List<string>(); 

        public SourceCode(string path)
        {
            string pathToTCC = Directory.GetCurrentDirectory() + @"\tcc\tcc.exe";
            _app = new Process
            {
                StartInfo =
                {
                    FileName = pathToTCC,
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
            _CompilationErrorMSG = GetError();
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
            return _CompilationErrorMSG;
        }
        public int GetIdOfLineWithError()
        {
            //todo remove magic numbers
            if (_CompilationErrorMSG == null)
                return -1;
            Regex newRegex= new Regex(@":(\d):");
            return int.Parse(newRegex.Match(_CompilationErrorMSG).ToString().Replace(":", "")) - 2;
        }

        public bool Exists()
        {
            if (File.Exists(Path))
                return true;
            return false;
        }

        public TestResult RunTest(List<string> inputs,List<KeyValuePair<string, OutputType>> expectedOutputs)
        {
            _app.Start();

            StreamWriter inputWriter = _app.StandardInput;
            StreamReader outputReader = _app.StandardOutput;
            StreamReader errorReader = _app.StandardError;

            foreach (string input in inputs)
                inputWriter.WriteLine(input);

            string output="";
            string error = "";
            if (!_app.WaitForExit(timeout))
            {
                _app.Kill();
                error += "Aplikace nebyla ukonžena před timeoutem (" + timeout/1000 + "s)\n";
            }
            output += outputReader.ReadToEnd();
            error += errorReader.ReadToEnd();
            int processorTime = (int) _app.TotalProcessorTime.TotalMilliseconds;
            TestResult result=new TestResult(inputs,output,expectedOutputs,error,processorTime,Name);
            testResult = result;
            foreach (string testError in _testErrors)
            {
                testResult.AddError(testError);
            }
            return result;
        }

        public TestResult GetResult()
        {
            return testResult;
        }

        public void AddTestError(string error)
        {
            _testErrors.Add(error);
        }
    }
}