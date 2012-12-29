using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExIDFManagment.DataModel;
using ExIDFManagment.Interface;
using ExIDFManagment.StubModel;
using Timer = System.Timers.Timer;

namespace ExIDFManagment
{
    public partial class AddCandidateForm : Form
    {
        private DateTime mLastFilterTextChanged;
        private System.Timers.Timer mLazyLoadingFilteringTimer;

        ICandidateManagment mCandidateManagment = new CandidatesManagment();
        //ICandidateManagment mCandidateManagment = new StubCandidateMangment();
        ILocationManagment mLocationManagment = new LocationsManagment();
        //ILocationManagment mLocationManagment = new StubLocationManagement();
        ICompaniesManagment mCompaniesManagment = new CompaniesManagment();
        //ICompaniesManagment mCompaniesManagment = new StubCompaniesManagment();
        ICandidateCompanyStatusMangment mStatusesManagment = new CandidateCompanyStatusMangment();
        ContextMenuStrip mCandidateDgvMenu = new ContextMenuStrip();

        public AddCandidateForm()
        {
            InitializeComponent();
            columnOnGridPicker1.SetLayoutSize(tpCandidates.Size);
            columnOnGridPicker2.SetLayoutSize(tpCompanies.Size);
            columnOnGridPicker3.SetLayoutSize(tpLocations.Size);
            columnOnGridPicker4.SetLayoutSize(tpCandidateToCompany.Size);
            ChangeDataSourceByTab(tabControl1.SelectedTab);

            // initialize LogWindowWriter
            LogWindowWriter.LogBackColor = Color.DimGray;
            LogWindowWriter.LogTextColor = Color.Ivory;
            LogWindowWriter.LogExceptionColor = Color.IndianRed;
            LogWindowWriter.InitWriter(rtbLogWindow);

            InitCandidateToolStripMenu();
        }

        private void InitCandidateToolStripMenu()
        {
            ToolStripMenuItem mnuHelloMail = new ToolStripMenuItem("Send Hello Mail");
            mnuHelloMail.Click += new EventHandler(mnuHelloMail_Click);
            //Add to main context menu
            mCandidateDgvMenu.Items.AddRange(new ToolStripItem[] { mnuHelloMail });
        }

        void mnuHelloMail_Click(object sender, EventArgs e)
        {
            try
            {
                // Ask for confirmation from the user to send the mail.
                var dialogResult = MessageBox.Show(
                    String.Format("Are you sure you want to send WELCOME MAIL to {0} ", dgv.SelectedRows[0].Cells["Name"].Value),
                    "Confirm WELCOME MAIL", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == dialogResult)
                {
                    // TODO: Need to make this call from other thread!
                    // Call the API to send WELCOME MAIL to the candidate.
                    mCandidateManagment.SendWelcomeMail(dgv.SelectedRows[0].Cells["PK"].Value as String);
                    LogWindowWriter.WriteLog("Mail sent successfully!");
                }
                else
                {
                    LogWindowWriter.WriteLog("Mail wasn't sent!");
                }
            }
            catch (Exception ex)
            {
                LogWindowWriter.WriteLog("Error sending mail");
                LogWindowWriter.WriteExceptionLog(ex);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                ChangeDataSourceByTab(e.TabPage);
            }
            catch(Exception ex)
            {
                LogWindowWriter.FormatWriteLog("Error while selecting tab ({0})", e.TabPage.Text);
                LogWindowWriter.WriteExceptionLog(ex);
            }
        }

        private void SetDataGridViewProperties(bool isAllowEditing, bool isAllowInsertingRows, 
                                                                            bool isAllowDeletingRows)
        {
            dgv.ReadOnly = (!(isAllowEditing));
            dgv.AllowUserToAddRows = isAllowInsertingRows;
            dgv.AllowUserToDeleteRows = isAllowDeletingRows;
            this.bindingNavigatorDeleteItem.Enabled = isAllowDeletingRows;
            this.bindingNavigatorAddNewItem.Enabled = isAllowInsertingRows;
        }

        private void ChangeDataSourceByTab(TabPage tb)
        {
            SetDataGridViewProperties(true, true, true);
            BindingSource bs = new BindingSource();
            bs.DataSource = null;
            if (tb.Text.Equals("Candidates"))
            {
                bs.DataSource = mCandidateManagment.GetAllCandidates();
                dgv.DataSource = bs;
                bs.Sort = "Name";
                this.columnOnGridPicker1.Refresh();
            }
            else if (tb.Text.Equals("Companies"))
            {
                bs.DataSource = mCompaniesManagment.GetCompanies();
                dgv.DataSource = bs;
                this.columnOnGridPicker2.Refresh();
            }
            else if (tb.Text.Equals("Locations"))
            {
                bs.DataSource = mLocationManagment.GetLocations();
                dgv.DataSource = bs;
                this.columnOnGridPicker3.Refresh();
            }
            else if (tb.Text.Equals("Candidate / Company"))
            {
                SetDataGridViewProperties(true, false, false);

                // Bind Candidate to combo box
                this.cmbCandidate.DataSource = mCandidateManagment.GetAllCandidates();
                this.cmbCandidate.DisplayMember = "Name";
                // Bind Companies to combo box
                this.cmbCompany.DataSource = mCompaniesManagment.GetCompanies();
                this.cmbCompany.DisplayMember = "CompanyName";
                // Bind CandidateStatus Combobox
                this.cmbCandidateStatus.DataSource = mStatusesManagment.GetAllStatuses();

                // Set the BindingSource by the the first value of the Candidate's ComboBox.
                if (rbFilterByCandidate.Checked)
                {
                    ICandidate selectedCandidate =(cmbCandidate.SelectedValue as ICandidate);
                    if (selectedCandidate != null)
                    {
                        bs.DataSource = mCandidateManagment.GetCandidateComapnies(selectedCandidate.ID);
                    }
                }
                else
                {
                    ICompany selectedCompany = (cmbCompany.SelectedValue as ICompany);
                    if (selectedCompany != null)
                    {
                        bs.DataSource = mCompaniesManagment.GetCompanyCandidates(selectedCompany.ID);
                    }
                }
                dgv.DataSource = bs;
                columnOnGridPicker4.Refresh();
            }
            else
            {
                bs.DataSource = null;
            }
            bindingNavigator1.BindingSource = bs;
        }

        private void ConvertCellsToSpecificCellType(string cellType)
        {
            if (dgv.Columns.Contains(cellType))
            {
                foreach (var row in dgv.Rows)
                {
                    DataGridViewRow dgvRow = row as DataGridViewRow;
                    if (dgvRow != null)
                    {
                        DataGridViewCell newSpecificCell = null;
                        if (cellType.Equals("Candidate"))
                        {
                            newSpecificCell = new CandidateCell(dgvRow.Cells[cellType].Value as ICandidate);
                        }
                        else if (cellType.Equals("Company"))
                        {
                            newSpecificCell = new CompanyCell(dgvRow.Cells[cellType].Value as ICompany);
                        }
                        else
                        {
                            break;
                        }
                        dgvRow.Cells[cellType] = newSpecificCell;
                    }
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settingsFrom = new frmSettings();
            settingsFrom.Show();
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv.Columns.Contains("Location") && e.ColumnIndex == dgv.Columns["Location"].Index)
            {
                this.dgv[e.ColumnIndex, e.RowIndex] = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell locationCell = this.dgv[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                if (locationCell != null)
                {
                    locationCell.DataSource = mLocationManagment.GetLocations();
                    locationCell.ValueMember = "LocationName";
                    locationCell.DisplayMember = "LocationName";
                }
            }
            else if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Equals(typeof(DateTime?)) ||
                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Equals(typeof(DateTime)))
            {
                // Convert the cell type to calander cell
                this.dgv[e.ColumnIndex, e.RowIndex] = new CalendarCell();
                CalendarCell datepickerCell = this.dgv[e.ColumnIndex, e.RowIndex] as CalendarCell;
            }
            else if ((dgv.Columns[e.ColumnIndex].Name == "Status") &&
                            tabControl1.SelectedTab == tpCandidateToCompany)
            {
                object currentVal = this.dgv[e.ColumnIndex, e.RowIndex].Value;
                this.dgv[e.ColumnIndex, e.RowIndex] = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell statusCell = this.dgv[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                statusCell.DataSource = mStatusesManagment.GetAllStatuses();
                statusCell.Value = currentVal;
            }
        }

        private void tsbCommit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.IsCurrentCellInEditMode) // Check if we did commit in edit mode
                {
                    dgv.EndEdit(); // call end edit in datagridview
                    if (dgv.DataSource is BindingSource)
                    {
                        (dgv.DataSource as BindingSource).EndEdit(); // call end edit in the binding source
                    }
                }
                mCandidateManagment.CommitChanges();
                LogWindowWriter.WriteLog("Commited!");
            }
            catch (Exception ex)
            {
                LogWindowWriter.WriteLog("Error in commit!");
                LogWindowWriter.WriteExceptionLog(ex);
                ChangeDataSourceByTab(tabControl1.SelectedTab); // On error load the Datagridview bindings again
            }
            finally
            {
                mCandidateManagment.Refresh();
                mCompaniesManagment.Refresh();
                mLocationManagment.Refresh();
            }
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns.Contains("PK"))
            {
                if (String.IsNullOrEmpty((string) dgv.Rows[e.RowIndex].Cells["PK"].Value))
                {
                    dgv.Rows[e.RowIndex].Cells["PK"].Value = Guid.NewGuid().ToString();
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && dgv.Columns[e.ColumnIndex].Name == "CV_Path")
            {
                // opens file dialog.
                OpenFileDialog fileDialog = new OpenFileDialog();
                DialogResult results = fileDialog.ShowDialog();
                if (results == DialogResult.OK)
                {
                    // sets the cv path to the chosen file
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fileDialog.FileName;
                }
            }
        }

        private void cmbCandidate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.rbFilterByCandidate.Checked)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = mCandidateManagment.GetCandidateComapnies(
                                                (cmbCandidate.SelectedValue as ICandidate).ID);
                this.dgv.DataSource = bs;
                this.bindingNavigator1.BindingSource = bs;
            }
        }

        private void cmbCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.rbFilterByCompany.Checked)
            {
                BindingSource bs =new BindingSource();
                bs.DataSource = mCompaniesManagment.GetCompanyCandidates(
                                                (cmbCompany.SelectedValue as ICompany).ID);
                this.dgv.DataSource = bs;
                this.bindingNavigator1.BindingSource = bs;
            }
        }

        private void rbFilterByCandidate_CheckedChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            if (rbFilterByCandidate.Checked)
            {
                ICandidate selectedCandidate = (cmbCandidate.SelectedValue as ICandidate);
                if (selectedCandidate != null)
                {
                    bs.DataSource = mCandidateManagment.GetCandidateComapnies(selectedCandidate.ID);
                }
            }
            else
            {
                ICompany selectedCompany = (cmbCompany.SelectedValue as ICompany);
                if (selectedCompany != null)
                {
                    bs.DataSource = mCompaniesManagment.GetCompanyCandidates(selectedCompany.ID);
                }
            }
            this.dgv.DataSource = bs;
            this.columnOnGridPicker4.Refresh();
        }

        private void btnConnectCandToComp_Click(object sender, EventArgs e)
        {
            ICandidate selectedCandidate = cmbCandidate.SelectedValue as ICandidate;
            if (selectedCandidate == null)
            {
                LogWindowWriter.WriteLog("Attach Failed");
                LogWindowWriter.WriteLog("Please select specific candidate from the combobox.");
                return;
            }
            if (cmbCompany.SelectedValue as ICompany == null)
            {
                LogWindowWriter.WriteLog("Attach Failed");
                LogWindowWriter.WriteLog("Please select specific company from the combobox.");
                return;
            }

            var candidateCompanies = mCandidateManagment.GetCandidateComapnies(selectedCandidate.ID);
            foreach (var candidateCompany in candidateCompanies)
            {
                if (candidateCompany.Company.ID == (cmbCompany.SelectedValue as ICompany).ID)
                {
                    return;
                }
            }

            mCandidateManagment.AttachCandidateToCompany(
                selectedCandidate.ID,
                (cmbCompany.SelectedValue as ICompany).ID,
                dtpCandToComp.Value,
                cmbCandidateStatus.SelectedValue as String);

            BindingSource bs = new BindingSource();
            if (rbFilterByCandidate.Checked)
            {
                if (selectedCandidate != null)
                {
                    bs.DataSource = mCandidateManagment.GetCandidateComapnies(selectedCandidate.ID);
                }
            }
            else
            {
                ICompany selectedCompany = (cmbCompany.SelectedValue as ICompany);
                if (selectedCompany != null)
                {
                    bs.DataSource = mCompaniesManagment.GetCompanyCandidates(selectedCompany.ID);
                }
            }
            this.dgv.DataSource = bs;
            this.bindingNavigator1.BindingSource = bs;
            this.columnOnGridPicker4.Refresh();
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgv.Columns[e.ColumnIndex].Name == "Status") &&
                tabControl1.SelectedTab == tpCandidateToCompany)
            {
                mCandidateManagment.UpdateCandidateToCompanyStatus(
                    ((CandidateCell)dgv.Rows[e.RowIndex].Cells["Candidate"]).Candidate.ID,
                    ((CompanyCell)dgv.Rows[e.RowIndex].Cells["Company"]).Company.ID,
                    (DateTime)dgv.Rows[e.RowIndex].Cells["ExposeTime"].Value,
                    dgv.Rows[e.RowIndex].Cells["Status"].Value as string);
            }
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            ConvertCellsToSpecificCellType("Candidate");
            ConvertCellsToSpecificCellType("Company");
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                if (dgv.Rows[i] != null)
                {
                    if (i % 2 == 0)
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Thistle;
                    }
                    else
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
        }

        private void txtFilterByName_Click(object sender, EventArgs e)
        {
            txtFilterByName.ForeColor = Color.Black;
            txtFilterByName.Text = String.Empty;
        }

        private void txtFilterByName_Leave(object sender, EventArgs e)
        {
            if (txtFilterByName.Text.Equals(String.Empty))
            {
                txtFilterByName.ForeColor = Color.DarkGray;
                txtFilterByName.Text = "Filter By Name";
            }
        }
            
        private void txtFilterByName_TextChanged(object sender, EventArgs e)
        {
            if (mLazyLoadingFilteringTimer == null)
            {
                mLazyLoadingFilteringTimer =  new System.Timers.Timer(500);
                mLazyLoadingFilteringTimer.Elapsed += 
                    new System.Timers.ElapsedEventHandler(mLazyLoadingFilteringTimer_Elapsed);
            }

            if (txtFilterByName.Text != String.Empty && txtFilterByName.Text != "Filter By Name")
            {
                if (txtFilterByName.Text.Length > 2)
                {
                    mLazyLoadingFilteringTimer.Enabled = true;
                    mLazyLoadingFilteringTimer.Start();
                }
            }
            else
            {
                mLazyLoadingFilteringTimer.Enabled = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = mCandidateManagment.GetAllCandidates();
                SetDataGridViewDataSource(dgv, bs);
            }
        }

        void mLazyLoadingFilteringTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock(mLazyLoadingFilteringTimer)
            {
                mLazyLoadingFilteringTimer.Enabled = false;
            }
            if (DateTime.Now.Subtract(mLastFilterTextChanged).Seconds > TimeSpan.FromSeconds(1).Seconds)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource =  mCandidateManagment.GetCandidateContainsName(txtFilterByName.Text);
                dgv.BeginInvoke(new ChangeDataGridViewDataSourceDelegate(SetDataGridViewDataSource), dgv, bs);
            }
            mLastFilterTextChanged = DateTime.Now;
        }
    
        delegate void ChangeDataGridViewDataSourceDelegate(DataGridView dataGridView, BindingSource bs);
        public void SetDataGridViewDataSource(DataGridView dataGridView, BindingSource bs)
        {
            dataGridView.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
        }

        private void txtFilterByCompany_Leave(object sender, EventArgs e)
        {
            if (txtFilterByCompany.Text.Equals(String.Empty))
            {
                txtFilterByCompany.ForeColor = Color.DarkGray;
                txtFilterByCompany.Text = "Filter By Company Name";
            }
        }

        private void txtFilterByCompany_Enter(object sender, EventArgs e)
        {
            txtFilterByCompany.ForeColor = Color.Black;
            txtFilterByCompany.Text = String.Empty;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            mCandidateManagment.Refresh();
            mCompaniesManagment.Refresh();
            mLocationManagment.Refresh();
            LogWindowWriter.WriteLog("Refreshed!");
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgv.Rows[e.RowIndex].Selected = true;
                if (tabControl1.SelectedTab.Text.Equals("Candidates"))
                {
                    Rectangle r = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    mCandidateDgvMenu.Show((Control) sender, r.Left + e.X, r.Top + e.Y);
                }
            }
        }
    }
}
    