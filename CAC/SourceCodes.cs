using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CAC
{
    public static class SourceCodes
    {
        private static DirectoryInfo SourceDir;

        public static void setpath(string path)
         {
             SourceDir = new DirectoryInfo(path);
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
