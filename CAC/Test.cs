using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using aGrader.Properties;
using aGrader.sourceCodes;

namespace aGrader
{
    public abstract class Test
    {
        protected readonly SourceCode SourceCode;
        protected readonly TestProtocol Protocol;

        protected List<string> _outputs=new List<string>();
        private List<string> _errors=new List<string>();

        protected Test(SourceCode sourceCode, TestProtocol protocol)
        {
            SourceCode = sourceCode;
            Protocol = protocol;

        }

        protected abstract Process CreateProcess(SourceCode code);
        public abstract List<Tuple<string, int?>> GetCompilationError();

        public virtual TestResult RunTest()
        {
            var result = new TestResult();
            if (SourceCode.CompilationErrors.Any())
            {
                result = new TestResult(SourceCode.Name, Protocol, _outputs,
                    SourceCode.CompilationErrors.Select(t => t.Item1).ToList(), 0);
                SourceCode.AddTestResult(result);
                return result;
            }
            Process app = CreateProcess(SourceCode);
            CheckSourceCodeForProhibitedCommands();
            CheckSourceCodeForRequiredCommands();
            RunExternalApps(false,result);
            app.Start();

            StreamWriter inputWriter = app.StandardInput;
            StreamReader outputReader = app.StandardOutput;
            StreamReader errorReader = app.StandardError;


            foreach (string input in Protocol.Inputs)
                inputWriter.WriteLine(input);

            string output = "";
            string error = "";

            if (!app.HasExited && !app.WaitForExit(Protocol.Timeout))
            {
                app.Kill();
                error += string.Format(Resources.Test_AppDidNotEndedBeforeTimeout, Protocol.Timeout/1000); 
            }

            output += outputReader.ReadToEnd();
            error += errorReader.ReadToEnd();

            ParseOutput(output);
            ParseErrors(error);
            BalanceNumberOfExpectedAndRealOutputs();
            ProcessActionsWithFiles();
            BalanceNumberOfExpectedAndRealOutputs();
            _errors.AddRange(result.Errors);
            result =new TestResult(SourceCode.Name,Protocol,_outputs,_errors ,app.TotalProcessorTime.TotalMilliseconds);
            RunExternalApps(true,result);
            SourceCode.AddTestResult(result);
            return result;
        }

        private void RunExternalApps(bool runAfter,TestResult result)
        {
            foreach (ExternalAppData app in Protocol.ExternalApps.Where(t=>t.runAfter==runAfter))
            {
                string arguments = app.runAfter
                    ? app.Arguments.Replace("@name", SourceCode.Name)
                        .Replace("@correct", result.CorrectOutputsCount.ToString())
                        .Replace("@wrong", result.WrongOutputsCount.ToString())
                        .Replace("@time", result.ProcessorTime.ToString())
                    : app.Arguments.Replace("@name", SourceCode.Name);

                var extApp = new Process {StartInfo = new ProcessStartInfo(app.Path, arguments)};
                try
                {
                    extApp.Start();
                    if (!extApp.HasExited && !extApp.WaitForExit(Protocol.Timeout))
                    {
                        extApp.Kill();
                        result.AddErrors(string.Format(Resources.Test_AppDidNotEndedBeforeTimeout, Protocol.Timeout / 1000),true);
                    }
                }
                catch (Exception)
                {
                    result.AddErrors("Could not run external application.",true);
                }
            }
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
            var filteredObjects = Protocol.Outputs.Where(t => t is FileCompareData || t is FileWithOutputsData).ToArray();
            foreach (dynamic data in filteredObjects)
            {
                ProcessFileAction(data);
            }
        }

        private void ProcessFileAction(FileCompareData data)
        {
            string textFilePath = $@"{Path.GetDirectoryName(SourceCode.Path)}\{Path.GetFileNameWithoutExtension(SourceCode.Path)}.txt";
            if (data.ReferenceFileHash!=null)
            {
                _outputs.Add(data.ReferenceFileHash.ToString());
                Protocol.Outputs.Add(new FileHashData(textFilePath));
            }
            else
            {
                var i = 0;
                foreach (var line in data.ReferenceFileLines)
                {
                    _outputs.Add(line);
                    Protocol.Outputs.Add(new LineFromTextFileData(line,i++));
                }
            }
            Protocol.Outputs.Remove(data);
        }

        private void ProcessFileAction(FileWithOutputsData data)
        {
            var textFilePath = Path.GetDirectoryName(SourceCode.Path) + @"\" +
                      Path.GetFileNameWithoutExtension(SourceCode.Path) + ".txt";
            try
            {
                _outputs.AddRange(File.ReadAllLines(textFilePath));
            }
            catch (FileNotFoundException)
            {
                _errors.Add(string.Format(Resources.FileDoesNotExist, Path.GetFileName(textFilePath)));
            }
            catch (IOException ex)
            {
                _errors.Add(string.Format(Resources.CouldNotLoadFile,textFilePath));
                MessageBox.Show(string.Format(Resources.CouldNotLoadFile, textFilePath));
                ExceptionsLog.LogException(ex.ToString());
            }
            Protocol.Outputs.Remove(data);
        }

        private void CheckSourceCodeForRequiredCommands()
        {
            foreach (var requiredCommand in Protocol.RequiedCommnads.Where(requiredCommand => !SourceCode.GetSourceCodeWithoutComments().Contains(requiredCommand)))
            {
               _errors.Add(string.Format(Resources.Test_RequiedCommandWasNotFound, requiredCommand));
            }
        }

        private void CheckSourceCodeForProhibitedCommands()
        {
            foreach (var prohibitedCommand in Protocol.ProhibitedCommnads.Where(prohibitedCommand => SourceCode.GetSourceCodeWithoutComments().Contains(prohibitedCommand)))
            {
                _errors.Add(string.Format(Resources.Test_ProhibitedCommandFound, prohibitedCommand));
            }
        }

        private void ParseErrors(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                return;
            }
            _errors.AddRange(error.Split('\n'));
            var toRemove= _errors.Where(string.IsNullOrWhiteSpace).ToList();
            toRemove.ForEach(t => _outputs.Remove(t));
        }

        private void ParseOutput(string output)
        {
            output=output.Replace("\r", "");
            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }
            _outputs.AddRange(output.Split('\n'));
            var toRemove = _outputs.Where(string.IsNullOrWhiteSpace).ToList();
            toRemove.ForEach(t=>_outputs.Remove(t));

        }
    }

    
}
