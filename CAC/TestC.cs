using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using aGrader.sourceCodes;

namespace aGrader
{
    public class TestC : Test
    {
        public TestC(SourceCode sourceCode, TestProtocol protocol) : base(sourceCode, protocol)
        {
        }

        protected override Process CreateProcess(SourceCode code)
        {
            string pathToTcc = Directory.GetCurrentDirectory() + @"\tcc\tcc.exe";
            if (!File.Exists(pathToTcc))
            {
                MessageBox.Show("Kompilátor nebyl nalezen! \n {0}", pathToTcc);
                throw new FileNotFoundException("TCC not found! {0}", pathToTcc);
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
                    Arguments = "-run \"" + code.Path+"\""
                }
            };

            if (Protocol?.StartupArguments != null)
                app.StartInfo.Arguments +=" " + Protocol.StartupArguments;
            return app;
        }

        public override Tuple<string,int?> GetCompilationError(SourceCode code)
        {
            Process app=CreateProcess(code);

            app.Start();
            if (!app.HasExited && !app.WaitForExit(300))
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
    }
    
}
