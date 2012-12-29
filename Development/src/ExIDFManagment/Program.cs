using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExIDFManagment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new AddCandidateForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exForm = new ExceptionForm(e.ExceptionObject as Exception, DateTime.Now);
            exForm.ShowDialog();
        }
    }
}
