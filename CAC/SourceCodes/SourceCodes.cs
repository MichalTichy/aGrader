#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CAC.sourceCodes
{
    public static class SourceCodes
    {
        private static DirectoryInfo _sourceDir;
        private static List<SourceCode> _sourceCodeFiles = new List<SourceCode>();

        public static bool SetPath()
        {
            var dialog = new FolderBrowserDialog
            {
                Description = "Zvolte složku která obsahuje zdrojové kódy."
            };

            DialogResult dialogres = dialog.ShowDialog();

            if (dialogres == DialogResult.OK)
            {
                _sourceDir = new DirectoryInfo(dialog.SelectedPath);
                ReloadSourceCodeFiles();
                return true;
            }

            return false;
        }

        public static bool SetPath(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                _sourceDir = directoryInfo;
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
            //todo spouští se 2x při prvním zvolení cesty
            _sourceCodeFiles.Clear();
            foreach (FileInfo file in _sourceDir.GetFiles("*.c"))
                _sourceCodeFiles.Add(new SourceCode(file.FullName));
        }

        public static ReadOnlyCollection<SourceCode> GetSourceCodeFiles()
        {
            return _sourceCodeFiles.AsReadOnly();
        }

        public static SourceCode GetSourceCode(int index)
        {
            return _sourceCodeFiles[index];
        }

        public static SourceCode GetSourceCode(string filename)
        {
            return _sourceCodeFiles.First(h => h.Name == filename);
        }
    }
}