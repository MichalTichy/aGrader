using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CAC.sourceCodes;

namespace CAC
{
    public class Test
    {
        private const int Timeout = 20000;

        public readonly SourceCode SourceCode;
        public readonly TestProtocol Protocol;

        private List<string> _outputs=new List<string>();
        private List<string> _errors=new List<string>();
        private readonly Process _app;
        public Test(SourceCode sourceCode, TestProtocol protocol)
        {
            SourceCode = sourceCode;
            Protocol = protocol;
            _app = CreateProcess(sourceCode);

        }
        private static Process CreateProcess(SourceCode code)
        {
            string pathToTcc = Directory.GetCurrentDirectory() + @"\tcc\tcc.exe";
            var app = new Process
            {
                StartInfo =
                {
                    FileName = pathToTcc,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = "-run " + code.Path
                }
            };
            return app;
        }
        public static Tuple<string,int?> GetCompilationError(SourceCode code)
        {
            Process app=CreateProcess(code);

            app.Start();
            if (!app.WaitForExit(300))
                app.Kill();

            string msg = app.StandardError.ReadLine();
            
            if (string.IsNullOrWhiteSpace(msg))
                return new Tuple<string, int?>(null,null);

            var newRegex = new Regex(@":(\d*):");

            int? lineWithError=null;
            try
            {
                lineWithError = int.Parse(newRegex.Match(msg).ToString().Replace(":", "")) - 2;
            }
            catch
            {
                // ignored
            }

            return new Tuple<string,int?>(msg,lineWithError);
        }

        public TestResult RunTest()
        {
            CheckSourceCodeForProhibitedCommands();
            CheckSourceCodeForRequiedCommands();
            _app.Start();

            StreamWriter inputWriter = _app.StandardInput;
            StreamReader outputReader = _app.StandardOutput;
            StreamReader errorReader = _app.StandardError;


            foreach (string input in Protocol.Inputs)
                inputWriter.WriteLine(input);

            string output = "";
            string error = "";

            if (!_app.WaitForExit(Timeout))
            {
                _app.Kill();
                error += "Aplikace nebyla ukonžena před timeoutem (" + Timeout / 1000 + "s)\n"; 
            }

            output += outputReader.ReadToEnd();
            error += errorReader.ReadToEnd();

            ParseOutput(output);
            ParseErrors(error);
            var result=new TestResult(SourceCode.Name,Protocol,_outputs, _errors,_app.TotalProcessorTime.TotalMilliseconds);
            SourceCode.AddTestResult(result);
            return result;
        }

        private void CheckSourceCodeForRequiedCommands()
        {
            foreach (string requiedCommnad in Protocol.RequiedCommnads.Where(requiedCommnad => SourceCode.GetSourceCode().Contains(requiedCommnad)))
            {
               _errors.Add("Nenalezen vyžadovaný příkaz: " + requiedCommnad);
            }
        }

        private void CheckSourceCodeForProhibitedCommands()
        {
            foreach (string prohibitedCommnad in Protocol.ProhibitedCommnads.Where(prohibitedCommnad => SourceCode.GetSourceCode().Contains(prohibitedCommnad)))
            {
                _errors.Add("Nalezen nepovolený příkaz: " + prohibitedCommnad);
            }
        }

        private void ParseErrors(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                return;
            }
            _errors.AddRange(error.Split('\n'));
        }

        private void ParseOutput(string output)
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }
            _outputs.AddRange(output.Split('\n'));
        }
    }
}
