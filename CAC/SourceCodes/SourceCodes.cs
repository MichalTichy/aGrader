#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace aGrader.sourceCodes
{
    public static class SourceCodes
    {
        private static DirectoryInfo _sourceDir;
        private static List<SourceCode> _sourceCodeFiles = new List<SourceCode>();

        public static void SetPath()
        {
            var dialog = new FolderBrowserDialog
            {
                Description = "Zvolte složku která obsahuje zdrojové kódy."
            };

            DialogResult dialogres = dialog.ShowDialog();

            if (dialogres == DialogResult.OK)
            {
                _sourceDir = new DirectoryInfo(dialog.SelectedPath);
            }
        }

        public static void SetPath(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException(path);
            }
            _sourceDir = directoryInfo;
        }

        public static string GetPath()
        {
            return _sourceDir?.FullName ?? "...";
        }

        public static bool IsDirectorySet()
        {
            return _sourceDir != null;
        }

        public static void ReloadSourceCodeFiles(string extension)
        {
            _sourceCodeFiles.Clear();
            foreach (FileInfo file in _sourceDir.GetFiles("*."+ extension))
                _sourceCodeFiles.Add(new SourceCode(file.FullName));
            
            if (!AreAllFileNamesValid())
            {
                _sourceCodeFiles.Clear();
            }
        }

        private static bool AreAllFileNamesValid()
        {
            char[] illegalChars = { '-', ' '}; //todo doplnit
            foreach (SourceCode code in _sourceCodeFiles.Where(code => code.Path.IndexOfAny(illegalChars) != -1))
            {
                MessageBox.Show("Název nebo cesta k souboru " +code.Name + "obsahuje nepovolené znaky (" + new string(illegalChars) + ")");
                return false;
            }
            return true;
        }

        public static void GetCompilationErrorsAsync()
        {
            IEnumerable<Task> compilationErrorTaskQuary =
    from sourceCode in _sourceCodeFiles select new Task(sourceCode.GetCompilationError);
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

        public static void RemoveResults()
        {
            _sourceCodeFiles.ForEach(t=>t.RemoveTestResult());
        }
    }
}