using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAC
{
    public class TestedCode
    {
        private Process _app;

        public event ProgressChangedEventHandler ProgressChanged;

        protected virtual void OnProgressChanged(string message)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, new ProgressChangedEventArgs(0, message));
        }

        private BackgroundWorker bw = new BackgroundWorker()
        {
            WorkerSupportsCancellation = true,
            WorkerReportsProgress = true
        };

        public TestedCode(string path)
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
            bw.ProgressChanged += bw_ProgressChanged;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressChanged((string) e.UserState);
        }

        public string GetError()
        {
            _app.Start(); //todo narvat do jineho vlakna (background workeru)
            string output = _app.StandardError.ReadLine();
            if(!_app.HasExited)
                _app.Kill();
            return output;
        }
    }
}