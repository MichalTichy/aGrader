using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CAC
{
    public static class SourceCodes
    {
        private static DirectoryInfo _sourceDir;
        private static List<SourceCode> _sourceCodeFiles=new List<SourceCode>();


        public static bool SetPath()
         {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "Zvolte složku která obsahuje zdrojové kódy."
            };

            DialogResult dialogres = dialog.ShowDialog();

            if (dialogres==DialogResult.OK)
            {
                _sourceDir = new DirectoryInfo(dialog.SelectedPath);
                ReloadSourceCodeFiles();
                return true;
            }

            return false;
         }

        public static string GetPath()
        {
            return _sourceDir.FullName;
        }

        public static bool IsDirectorySet()
        {
            return _sourceDir != null;
        }

        public static void ReloadSourceCodeFiles()
        {
            foreach (FileInfo file in _sourceDir.GetFiles("*.c"))
                _sourceCodeFiles.Add(new SourceCode(file.FullName));
        }

        public static List<SourceCode> GetSourceCodeFiles()
        {
            return _sourceCodeFiles;
        }
        public static SourceCode GetSourceCode(int index)
        {
            return _sourceCodeFiles[index];
        }
    }
}
