﻿#region

using System;
using System.Windows.Forms;

#endregion

namespace aGrader
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
                Application.Run(new WelcomeForm());
                Application.Run(new aGrader());
            }
            catch (Exception exception)
            {
                ExceptionsLog.LogException(exception.ToString());
                throw;
            }
        }
    }
}