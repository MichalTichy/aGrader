﻿using System;
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
                MessageBox.Show("Složka obsahuje samostatné soubory i skupiny souborů.\nBuď odstraňte složky se skupinami souborů nebo samostatné soubory.");
        }

        private static void LoadSourceCodeFilesJavaMultiFiles()
        {
            foreach (DirectoryInfo directory in _sourceDir.GetDirectories())
            {

                string mainJavaFile = null;
                var dependencies = new List<string>();

                foreach (FileInfo file in directory.GetFiles())
                {
                    if(mainJavaFile==null && new SourceCodeJava(file.FullName).GetSourceCodeWithoutComments().Contains("public static void main("))
                    {
                        mainJavaFile = file.FullName;
                    }
                    else
                    {
                        dependencies.Add(file.FullName);
                    }
                }

                _sourceCodeFiles.Add(new SourceCodeJava(mainJavaFile,dependencies.ToArray()));
            }
        }

        private static void LoadSourceCodeFilesJavaSingleFile()
        {
            foreach (FileInfo fileInfo in _sourceDir.GetFiles())
            {
                _sourceCodeFiles.Add(new SourceCodeJava(fileInfo.FullName));
            }
        }
    }
}
