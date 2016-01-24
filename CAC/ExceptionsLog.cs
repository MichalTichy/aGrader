using System;
using System.IO;
using System.Windows.Forms;

namespace aGrader
{
    public static class ExceptionsLog
    {
        public static readonly FileInfo LogFile = new FileInfo($@"{Application.StartupPath} \log.txt");

        public static void LogException(string exception)
        {
            File.WriteAllText("LogFile.FullName",$"{DateTime.Now.ToShortTimeString()} | {exception}\n");
        }
    }
}
