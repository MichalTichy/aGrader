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
        public readonly SourceCode SourceCode;
        public readonly TestProtocol Protocol;

        protected List<string> _outputs=new List<string>();
        private List<string> _errors=new List<string>();

        public Test(SourceCode sourceCode, TestProtocol protocol)
        {
            SourceCode = sourceCode;
            Protocol = protocol;

        }

        protected abstract Process CreateProcess(SourceCode code);
        public abstract Tuple<string, int?> GetCompilationError(SourceCode code);

        public virtual TestResult RunTest()
        {
            Process app = CreateProcess(SourceCode);
            CheckSourceCodeForProhibitedCommands();
            CheckSourceCodeForRequiedCommands();
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
            var result=new TestResult(SourceCode.Name,Protocol,_outputs, _errors,app.TotalProcessorTime.TotalMilliseconds);
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

        private void CheckSourceCodeForRequiedCommands()
        {
            foreach (var requiedCommnad in Protocol.RequiedCommnads.Where(requiedCommnad => !SourceCode.GetSourceCodeWithoutComments().Contains(requiedCommnad)))
            {
               _errors.Add(string.Format(Resources.Test_RequiedCommandWasNotFound, requiedCommnad));
            }
        }

        private void CheckSourceCodeForProhibitedCommands()
        {
            foreach (var prohibitedCommnad in Protocol.ProhibitedCommnads.Where(prohibitedCommnad => SourceCode.GetSourceCodeWithoutComments().Contains(prohibitedCommnad)))
            {
                _errors.Add(string.Format(Resources.Test_ProhibitedCommandFound, prohibitedCommnad));
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
