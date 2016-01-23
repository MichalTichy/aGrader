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
    public static partial class SourceCodes
    {
        private static DirectoryInfo _sourceDir;
        private static List<SourceCode>_sourceCodeFiles = new List<SourceCode>();
        private static string _lastFileExtension;
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

        public static void LoadSourceCodeFiles(string extension,string aditionalParameter=null)
        {
            _sourceCodeFiles.Clear();
            _lastFileExtension = extension;
            switch (extension)
            {
                case "c":
                    LoadSourceCodeFilesC();
                    break;
                case "java":
                    if (aditionalParameter == "single")
                        LoadSourceCodeFilesJavaSingleFile();
                    else if (aditionalParameter == "multi")
                        LoadSourceCodeFilesJavaMultiFiles();
                    else
                        LoadSourceCodeFilesJava();
                    break;
                default:
                    MessageBox.Show("Unsuported file extension!");
                    ExceptionsLog.LogException($"{extension} is not suported!");
                    _lastFileExtension = null;
                    break;
            }
        }

        public static void ReloadFiles()
        {
            if (_lastFileExtension == null)
                return;
            LoadSourceCodeFiles(_lastFileExtension);
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

        public static void ClearPath()
        {
            _sourceDir = null;
        }
    }
}