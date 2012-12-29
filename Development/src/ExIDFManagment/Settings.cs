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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnBrowseDropboxFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            DialogResult results = browserDialog.ShowDialog();
            if (results == DialogResult.OK)
            {
                txtDropboxFolder.Text = browserDialog.SelectedPath;
            }
        }
    }
}
