#region

using System;
using System.Windows.Forms;

#endregion

namespace CAC
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CaC());
            }
            catch (Exception exception)
            {
                ExceptionsLog.LogException(exception.ToString());
                throw;
            }
        }
    }
}