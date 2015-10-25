#region

using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace aGrader.sourceCodes
{
    public abstract class SourceCode
    {

        public string CompilationErrorMsg;
        public int? NumberOfLineWithError;
        public readonly string Name;
        public readonly string Path;

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

        public abstract void GetCompilationError();

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

        public string GetSourceCodeWithoutComments()
        {

            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";

            string noComments = Regex.Replace(GetSourceCode(),
                blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
                me =>
                {
                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                        return me.Value.StartsWith("//") ? Environment.NewLine : "";
                    // Keep the literal strings
                    return me.Value;
                },
                RegexOptions.Singleline);

            return Regex.Replace(noComments, @"^\s+$[\r\n]*", "", RegexOptions.Multiline); //removes blank lines
        }
    }
}