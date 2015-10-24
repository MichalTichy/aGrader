#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace aGrader.sourceCodes
{
    public static partial class SourceCodes
    {
        private static void LoadSourceCodeFilesC()
        {
            _sourceCodeFiles.Clear();
            foreach (FileInfo file in _sourceDir.GetFiles("*.c"))
                _sourceCodeFiles.Add(new SourceCodeC(file.FullName));

            if (!AreAllCFileNamesValid())
            {
                _sourceCodeFiles.Clear();
            }
        }

        private static bool AreAllCFileNamesValid()
        {
            char[] illegalChars = { '-', ' ' }; //todo doplnit
            foreach (SourceCode code in _sourceCodeFiles.Where(code => code.Path.IndexOfAny(illegalChars) != -1))
            {
                MessageBox.Show("Název nebo cesta k souboru " + code.Name + "obsahuje nepovolené znaky (" + new string(illegalChars) + ")");
                return false;
            }
            return true;
        }

    }
}