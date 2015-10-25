using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using aGrader.sourceCodes;

namespace aGrader
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
            if (!File.Exists(pathToTcc))
            {
                MessageBox.Show("Kompilátor nebyl nalezen! \n {0}", pathToTcc);
                throw new FileNotFoundException("TCC not found! {0}",pathToTcc);
            }
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
                // error does not contain line number
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
                error += "Aplikace nebyla ukončena před timeoutem (" + Timeout / 1000 + "s)\n"; 
            }

            output += outputReader.ReadToEnd();
            error += errorReader.ReadToEnd();

            ParseOutput(output);
            ParseErrors(error);
            BalanceNumberOfExpectedAndRealOutputs();
            ProcessActionsWithFiles();
            BalanceNumberOfExpectedAndRealOutputs();
            var result=new TestResult(SourceCode.Name,Protocol,_outputs, _errors,_app.TotalProcessorTime.TotalMilliseconds);
            SourceCode.AddTestResult(result);
            return result;
        }
        private void BalanceNumberOfExpectedAndRealOutputs()
        {
            while (_outputs.Count > Protocol.Outputs.Count(t => !(t is FileCompareData) && !(t is FileWithOutputsData)))
            {
                Protocol.Outputs.Add(new ErrorData());
            }
            while (Protocol.Outputs.Count(t => !(t is FileCompareData) && !(t is FileWithOutputsData)) > _outputs.Count)
            {
                _outputs.Add(null);
            }
        }

        private void ProcessActionsWithFiles()
        {
            object[] filteredObjects = Protocol.Outputs.Where(t => t is FileCompareData || t is FileWithOutputsData).ToArray();
            foreach (dynamic data in filteredObjects)
            {
                ProcessFileAction(data);
            }
        }

        private void ProcessFileAction(FileCompareData data)
        {
            string textFilePath = Path.GetDirectoryName(SourceCode.Path) + @"\" +
                                  Path.GetFileNameWithoutExtension(SourceCode.Path) + ".txt";
            if (data.ReferenceFileHash!=null)
            {
                _outputs.Add(data.ReferenceFileHash.ToString());
                Protocol.Outputs.Add(new FileHashData(textFilePath));
            }
            else
            {
                int i = 0;
                foreach (string line in data.ReferenceFileLines)
                {
                    _outputs.Add(line);
                    Protocol.Outputs.Add(new LineFromTextFileData(line,i++));
                }
            }
            Protocol.Outputs.Remove(data);
        }

        private void ProcessFileAction(FileWithOutputsData data)
        {
            string textFilePath = Path.GetDirectoryName(SourceCode.Path) + @"\" +
                      Path.GetFileNameWithoutExtension(SourceCode.Path) + ".txt";
            try
            {

                _outputs.AddRange(File.ReadAllLines(textFilePath));
            }
            catch (FileNotFoundException ex)
            {
                _errors.Add("Soubor " + Path.GetFileName(textFilePath)+" neexistuje.");
            }
            catch (IOException ex)
            {
                _errors.Add("Soubor " + Path.GetFileName(textFilePath)+" se nepodařilo načíst.");
                MessageBox.Show("Soubor " + Path.GetFileName(textFilePath) + " se nepodařilo načíst.");
                ExceptionsLog.LogException(ex.ToString());
            }
            Protocol.Outputs.Remove(data);
        }

        private void CheckSourceCodeForRequiedCommands()
        {
            foreach (string requiedCommnad in Protocol.RequiedCommnads.Where(requiedCommnad => !SourceCode.GetSourceCodeWithoutComments().Contains(requiedCommnad)))
            {
               _errors.Add("Nenalezen vyžadovaný příkaz: " + requiedCommnad);
            }
        }

        private void CheckSourceCodeForProhibitedCommands()
        {
            foreach (string prohibitedCommnad in Protocol.ProhibitedCommnads.Where(prohibitedCommnad => SourceCode.GetSourceCodeWithoutComments().Contains(prohibitedCommnad)))
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
