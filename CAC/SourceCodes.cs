using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CAC
{
    public static class SourceCodes
    {
        private static DirectoryInfo SourceDir;
        private static List<SourceCode> SourceCodeFiles=new List<SourceCode>();


        public static bool setPath()
         {
             FolderBrowserDialog dialog = new FolderBrowserDialog();
             dialog.Description="Zvolte složku která obsahuje zdrojové kódy.";

             DialogResult dialogres = dialog.ShowDialog();

            if (dialogres==DialogResult.OK)
            {
                SourceDir = new DirectoryInfo(dialog.SelectedPath);
                ReloadSourceCodeFiles();
                return true;
            }

            return false;
         }

        public static string getPath()
        {
            return SourceDir.FullName;
        }

        public static bool isdirectoryset()
        {
            if (SourceDir != null)
                return true;
            else
                return false;
        }

        public static void ReloadSourceCodeFiles()
        {
            foreach (FileInfo file in SourceDir.GetFiles("*.c"))
                SourceCodeFiles.Add(new SourceCode(file.FullName));
        }

        public static List<SourceCode> getSourceCodeFiles()
        {
            return SourceCodeFiles;
        }
        public static SourceCode getSourceCode(int index)
        {
            return SourceCodeFiles[index];
        }
    }
}
