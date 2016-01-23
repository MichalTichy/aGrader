#region

using System.IO;

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