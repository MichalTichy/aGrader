using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAC.IO_Forms;
using CAC.Math;

namespace CAC
{
    public class TestedCode
    {
        private Process _app;
        private const int timeout = 30000; //in ms
        private List<string> _inputs = new List<string>();
        private List<string> _outputs = new List<string>();
        private Dictionary<string, decimal> _randomNumbers = new Dictionary<string, decimal>();

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
            bw.DoWork += bw_DoWork;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] inputs = (string[]) e.Argument;
            

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

        public void RunTests()
        {
            GetInputsAndOutputs();
        }

        private void GetInputsAndOutputs()
        {
            foreach (var InOut in InputsOutputs.GetList())
                GetData(InOut);
        }

        private void GetData(InputString input)
        {
            _inputs.Add(input.Text);
        }
        private void GetData(InputNumber input)
        {
            _inputs.Add(input.Value.ToString());
        }
        private void GetData(InputRandomNumber input)
        {
            Random random=new Random(DateTime.Now.Millisecond);
            decimal num;
            if (input.Decimal)
            {
                decimal next = (decimal)random.NextDouble();
                num= input.Min + (next * (input.Max - input.Min));
            }
            else
            {
                num = random.Next((int) input.Min, (int) input.Max);
            }
            _inputs.Add(num.ToString());
            _randomNumbers.Add('X'+input.ID.ToString(),num);
            Thread.Sleep(1); //to ensure random numbers
        }
        private void GetData(InputTextFile input)//todo dodělat
        {
            throw new NotImplementedException();
        }

        private void GetData(OutputNumber output)
        {
            _outputs.Add(output.Value.ToString());
        }
        private void GetData(OutputNumberBasedOnRandomInput output)
        {
            Equation equation=new Equation(output.jahoda,_randomNumbers);
            _outputs.Add(equation.Evaluate().ToString());
        }
    }
}