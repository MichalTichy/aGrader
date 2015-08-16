#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                return true;
            }
            return false;
        }

        public static string GetPath()
        {
            return _sourceDir?.FullName;
        }

        public static bool IsDirectorySet()
        {
            return _sourceDir != null;
        }

        public static void ReloadSourceCodeFiles()
        {
            _sourceCodeFiles.Clear();
            foreach (FileInfo file in _sourceDir.GetFiles("*.c"))
                _sourceCodeFiles.Add(new SourceCode(file.FullName));

            CheckForInvalidFileNames();
        }

        private static void CheckForInvalidFileNames()
        {
            char[] illegalChars = { '-', ' ', '_' }; //todo doplnit
            foreach (SourceCode code in _sourceCodeFiles)
            {
                if (code.Name.IndexOfAny(illegalChars) != -1)
                {
                    MessageBox.Show(code.Name + "obsahuje nepovolené znaky (" + new string(illegalChars) + ")");
                    _sourceCodeFiles.Clear();
                    return;
                }
            }
        }

        public static void GetCompilationErrorsAsync()
        {
            IEnumerable<Task> compilationErrorTaskQuary =
    from sourceCode in SourceCodes.GetSourceCodeFiles() select new Task(sourceCode.GetCompilationError);
            List<Task> testTasks = compilationErrorTaskQuary.ToList();
            testTasks.ForEach(t => t.Start());
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