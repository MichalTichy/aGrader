using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using aGrader.Properties;
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
            string pathToTcc = $@"{Directory.GetCurrentDirectory()}\tcc\tcc.exe";
            if (!File.Exists(pathToTcc))
            {
                var messageBoxResult = MessageBox.Show(Resources.Test_CompilatorNotFoundWannaDownload, pathToTcc,MessageBoxButtons.YesNo);
                if (messageBoxResult == DialogResult.Yes)
                {
                    new Task(DownloadTcc).Start();
                }
                else
                {
                    MessageBox.Show(Resources.TestsCannotBeRunWithoutCompiler);
                    throw new FileNotFoundException(Resources.Test_CompilatorNotFound, pathToTcc);
                }
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
                    Arguments = $"-run \"{code.Path}\""
                }
            };

            if (Protocol?.StartupArguments != null)
                app.StartInfo.Arguments +=$" {Protocol.StartupArguments}";
            return app;
        }

        private static void DownloadTcc()
        {
            try
            {
                string pathToTcc = GetTccPath();
                using (var wc = new WebClient())
                {
                    wc.DownloadFile(@"http://www.tichymichal.net/Downloads/tcc.zip", Environment.CurrentDirectory + @"/tcc.zip");
                }
                ZipFile.ExtractToDirectory(Environment.CurrentDirectory + @"/tcc.zip", Environment.CurrentDirectory);
                File.Delete(Environment.CurrentDirectory + @"/tcc.zip");
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.TestC_DownloadFailed);
                throw;

            }
        }

        public override Tuple<string,int?> GetCompilationError(SourceCode code)
        {
            var app=CreateProcess(code);

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

        public static string GetTccPath()
        {
            string pathToTcc = $@"{Directory.GetCurrentDirectory()}\tcc\tcc.exe";
            if (!File.Exists(pathToTcc))
            {
                var messageBoxResult = MessageBox.Show(Resources.Test_CompilatorNotFoundWannaDownload, pathToTcc, MessageBoxButtons.YesNo);
                if (messageBoxResult == DialogResult.Yes)
                {
                    new Task(DownloadTcc).Start();
                }
                else
                {
                    MessageBox.Show(Resources.TestsCannotBeRunWithoutCompiler);
                    throw new FileNotFoundException(Resources.Test_CompilatorNotFound, pathToTcc);
                }
            }
            return pathToTcc;
        }
    }
    
}
