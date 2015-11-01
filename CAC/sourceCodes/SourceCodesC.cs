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
            foreach (FileInfo file in _sourceDir.GetFiles("*.c"))
                _sourceCodeFiles.Add(new SourceCodeC(file.FullName));
        }

    }
}