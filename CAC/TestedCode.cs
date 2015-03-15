using System;
using System.Collections.Generic;
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
        private readonly TestInstructions _instructions;

        public TestedCode(string path,TestInstructions instructions)
        {
            string pathToTCC = Directory.GetCurrentDirectory() + @"\tcc\tcc.exe";
            _instructions = instructions;
            _app = new Process
            {
                StartInfo =
                {
                    FileName = pathToTCC,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = "-run " + @"D:\test.c"
                }
            };
        }
    }
}
