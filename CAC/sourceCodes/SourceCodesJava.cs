using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aGrader.sourceCodes
{
    partial class SourceCodes
    {
        private static void LoadSourceCodeFilesJava()
        {
            if (_sourceDir.GetFiles().Any() && !_sourceDir.GetDirectories().Any())
                LoadSourceCodeFilesJavaSingleFile();
            else if (!_sourceDir.GetFiles().Any() && _sourceDir.GetDirectories().Any())
                LoadSourceCodeFilesJavaMultiFiles();
            else
                MessageBox.Show(
                    "Složka obsahuje samostatné soubory i skupiny souborů.\nBuď odstraňte složky se skupinami souborů nebo samostatné soubory.");
        }

        private static void LoadSourceCodeFilesJavaMultiFiles()
        {
            foreach (DirectoryInfo directory in _sourceDir.GetDirectories())
            {

                var mainJavaFiles = new List<string>();
                var dependencies = new List<string>();

                foreach (FileInfo file in directory.GetFiles("*.java"))
                {
                    if (
                        new SourceCodeJava(file.FullName).GetSourceCodeWithoutComments()
                            .Contains("public static void main("))
                        mainJavaFiles.Add(file.FullName);
                    else
                        dependencies.Add(file.FullName);
                }

                _sourceCodeFiles.Add(new SourceCodeJava(directory.Name,mainJavaFiles.ToArray(),dependencies.ToArray()));
            }
        }

        private static void LoadSourceCodeFilesJavaSingleFile()
        {
            foreach (FileInfo fileInfo in _sourceDir.GetFiles("*.java"))
            {
                _sourceCodeFiles.Add(new SourceCodeJava(fileInfo.FullName));
            }
        }
    }
}
