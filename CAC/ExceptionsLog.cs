using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC
{
    public static class ExceptionsLog
    {
        public static readonly FileInfo LogFile = new FileInfo(Application.StartupPath+@"\log.txt");

        public static void LogException(string exception)
        {
            File.WriteAllText(LogFile.FullName, DateTime.Now.ToShortTimeString() + " | " + exception+"\n");
        }
    }
}
