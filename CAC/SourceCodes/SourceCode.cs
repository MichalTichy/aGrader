#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            Name = System.IO.Path.GetFileName(path);
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
            try
            {
                return File.ReadAllText(Path);
            }
#region exception handling
            catch (SecurityException)
            {
                MessageBox.Show("Na čtení {0} nemáte oprávnění!", Name);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Na čtení {0} nemáte oprávnění!", Name);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor {0} nebyl nalezen!", Name);
            }
            catch (IOException)
            {
                MessageBox.Show("Při čtení ze souboru {0} došlo k chybě!", Name);
            }
#endregion
            return null;
        }

        public bool Exists()
        {
            return File.Exists(Path);
        }

        public void AddTestResult(TestResult result)
        {
            _testResult = result;
        }

        public void RemoveTestResult()
        {
            _testResult = null;
        }
    }
}