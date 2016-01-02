using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using aGrader.sourceCodes;
using Microsoft.Win32;

namespace aGrader
{
    public class TestJava : Test
    {
        private static string _javaPath = null;
        private string _destinationFolder;
        public TestJava(SourceCode sourceCode, TestProtocol protocol) : base(sourceCode, protocol)
        {
        }

        public override TestResult RunTest()
        {
            var compilation = CreateCompilatonProcess(SourceCode);
            compilation.Start();
            var errorReader = compilation.StandardError;
            var error = "";
            if (!compilation.HasExited && !compilation.WaitForExit(Protocol.Timeout))
            {
                compilation.Kill();
                error += "Aplikace nebyla zkompilována před timeoutem (" + Protocol.Timeout / 1000 + "s)\n";
            }
            error += errorReader.ReadToEnd().Replace("\n","");

            var testResult =base.RunTest();
            testResult.AddErrors(error, true);

            DeleteDestinationFolder();
            return testResult;
        }

        private void DeleteDestinationFolder()
        {
            try
            {
                Directory.Delete(_destinationFolder,true);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override Process CreateProcess(SourceCode code)
        {
            string pathJava = GetPathToJava() + @"\bin\java.exe";
            if (!File.Exists(pathJava))
            {
                MessageBox.Show($"Java nebyla nalezena!\n{pathJava}");
                throw new FileNotFoundException($"Java not found! {pathJava}");
            }
            var app = new Process
            {
                StartInfo =
                {
                    FileName = pathJava,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = BuildRunArguments()
                }
            };
            return app;
        }

        private string BuildRunArguments()
        {
            var pathToFile = Directory.GetFiles(_destinationFolder, Path.GetFileName(SourceCode.Path).Replace(".java",".class"),SearchOption.AllDirectories).First();
            var relativePath = pathToFile.Replace(_destinationFolder, "");
            return "-cp \""+_destinationFolder+"\" "+ relativePath.Replace('/','.');
        }

        private Process CreateCompilatonProcess(SourceCode code)
        {
            string pathJavac = GetPathToJava() + @"\bin\javac.exe";
            CreateDestinationFolder();
            if (!File.Exists(pathJavac))
            {
                MessageBox.Show($"Kompilátor nebyl nalezen!\n{pathJavac}");
                ExceptionsLog.LogException($"Javac not found! {pathJavac}");
                //todo moznost najit javac rucne
            }

            var app = new Process
            {
                StartInfo =
                {
                    FileName = pathJavac,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = BuilCompilationdArguments()
                }
            };
            return app;
        }

        private void CreateDestinationFolder()
        {
            _destinationFolder =
               Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"aGrader",
                    Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
            Directory.CreateDirectory(_destinationFolder);//todo try catch
        }

        private string BuilCompilationdArguments()
        {
            var arguments = new StringBuilder();

            arguments.Append($"-d  \"{_destinationFolder}\" ");
            arguments.Append($"-sourcepath \"{Path.GetDirectoryName(SourceCode.Path)}\" ");
            arguments.Append($"\"{SourceCode.Path}\"");

            if (((SourceCodeJava) SourceCode).Dependencies == null) return arguments.ToString();

            foreach (var dependency in ((SourceCodeJava) SourceCode).Dependencies)
                arguments.Append($" \"{dependency}\"");
            return arguments.ToString();
        }

        public static string GetPathToJava()
        {
            if (_javaPath != null)
                return _javaPath;

            //try to get path from Environment variable
            try
            {
                _javaPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            }
            catch (Exception e)
            {
                ExceptionsLog.LogException(e.ToString());
            }
            if (_javaPath != null && _javaPath.ToLower().Contains("java") && Directory.Exists(_javaPath))
                return _javaPath;

            //try to get path from registry
            _javaPath = GetPathFromRegistry(Registry.CurrentUser) ?? GetPathFromRegistry(Registry.LocalMachine);
            if (_javaPath != null && Directory.Exists(_javaPath))
                return _javaPath;

            return null;
        }

        private static string GetPathFromRegistry(RegistryKey key)
        {
            using (RegistryKey subkey = key.OpenSubKey(@"SOFTWARE\JavaSoft\Java Development Kit"))
            {
                if (subkey == null)
                    return null;

                object value = subkey.GetValue("CurrentVersion", null, RegistryValueOptions.None);
                if (value == null) return null;

                using (RegistryKey currentHomeKey = subkey.OpenSubKey(value.ToString()))
                {
                    if (currentHomeKey == null)
                        return null;

                    value = currentHomeKey.GetValue("JavaHome", null, RegistryValueOptions.None);
                    if (value != null)
                        return value.ToString();
                }
            }

            return null;
        }
       
        public override Tuple<string, int?> GetCompilationError(SourceCode code)
        {
            Process app=CreateProcess(code);

            app.Start();
            if (!app.WaitForExit(300))
                app.Kill();

            string msg = app.StandardError.ReadLine();
            
            if (String.IsNullOrWhiteSpace(msg))
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

            return new Tuple<string, int?>(msg,lineWithError);
        }
    }
    
}
