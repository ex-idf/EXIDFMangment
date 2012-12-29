using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExIDFManagment
{
    public static class LogWindowWriter
    {
        private static RichTextBox mWindowLog;
        public static Color LogTextColor { get; set; }
        public static Color LogExceptionColor { get; set; }
        public static Color LogBackColor { get; set; }

        public static void InitWriter(RichTextBox logWindow)
        {
            mWindowLog = logWindow;
            mWindowLog.BackColor = LogBackColor;
        }

        public static void WriteLog(string log)
        {
            InnerWriteLog(log, LogTextColor);
        }

        private static void InnerWriteLog(string log, Color foreColor)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendLine(String.Format("{0}   {1}", DateTime.Now, log));
            mWindowLog.AppendText(sBuilder.ToString(), foreColor);
            mWindowLog.SelectionStart = mWindowLog.Text.Length;
            mWindowLog.ScrollToCaret();
        }

        public static void FormatWriteLog(string log, params object[] objs)
        {
            WriteLog(String.Format(log, objs));
        }

        public static void WriteExceptionLog(Exception ex)
        {
            if (ex != null)
            {
                if (!(String.IsNullOrEmpty(ex.Message)))
                {
                    string formattedString = String.Format("{0}", ex.Message);
                    if (ex.InnerException != null)
                    {
                        if (!(String.IsNullOrEmpty(ex.InnerException.Message)))
                        {
                            formattedString = String.Format("{0}. Inner Exception: {1}", formattedString,
                                                            ex.InnerException.Message);
                        }
                    }
                    InnerWriteLog(formattedString, LogExceptionColor);
                }
            }
        }
    }
}
