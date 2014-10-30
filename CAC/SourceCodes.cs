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

        public static bool setpath()
         {
             FolderBrowserDialog dialog = new FolderBrowserDialog();
             DialogResult dialogres = dialog.ShowDialog();

            if (dialogres==DialogResult.OK)
            {
                SourceDir = new DirectoryInfo(dialog.SelectedPath);
                return true;
            }

            return false;
         }

        public static string getpath()
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

    }
}
