using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExIDFManagment
{
    public partial class ExceptionForm : Form
    {
        private Exception mException;
        private DateTime mExceptionTime;

        public ExceptionForm(Exception ex, DateTime exTime)
        {
            this.mException = ex;
            this.mExceptionTime = exTime;

            InitializeComponent();

            this.lblDate.Text = mExceptionTime.ToString("dd/mm/yyyy HH:MM:ss");
            this.txtExceptionDetails.Text = mException.Message;
            this.txtInnerException.Text = mException.InnerException.Message;
        }

        public ExceptionForm() : this(null, DateTime.MinValue)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveToLog_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
