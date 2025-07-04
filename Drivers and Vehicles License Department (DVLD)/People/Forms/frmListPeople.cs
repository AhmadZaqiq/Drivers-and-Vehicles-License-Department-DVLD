﻿using DVLD_Business;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.People.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmListPeople : Form
    {
        private DataTable _PeopleTable = clsPerson.GetAllPeople();

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _FillPeopleComboBox();

            _RefreshPeopleDataGrid();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _FillPeopleComboBox()
        {
            dgvPeople.DataSource = _PeopleTable;

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn column in _PeopleTable.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdatePeopleCount()
        {
            //   lblRecordsCount.Text = clsPerson.GetPeopleCount().ToString();

            lblRecordsCount.Text = (dgvPeople.RowCount).ToString();
        }

        private void _RefreshPeopleDataGrid()
        {
            _PeopleTable = clsPerson.GetAllPeople();

            dgvPeople.DataSource = _PeopleTable;

            _UpdatePeopleCount();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople FormAddAndUpdatePeople = new frmAddAndUpdatePeople();
            FormAddAndUpdatePeople.ShowDialog();

            _RefreshPeopleDataGrid();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            frmShowPersonDetails FormPersonDetails = new frmShowPersonDetails(PersonID);
            FormPersonDetails.ShowDialog();

            _RefreshPeopleDataGrid();
        }

        private void AddNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople FormAddAndUpdatePerson = new frmAddAndUpdatePeople();
            FormAddAndUpdatePerson.ShowDialog();

            _RefreshPeopleDataGrid();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(PersonID);
            frmAddAndUpdatePeople.ShowDialog();

            _RefreshPeopleDataGrid();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this Person?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            if (!clsPerson.DeletePerson(PersonID))
            {
                clsMessageBoxManager.ShowMessageBox("Person was not deleted because it is linked to other transactions in the system...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Person deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _RefreshPeopleDataGrid();
        }

        private void CallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessageBoxManager.ShowMessageBox("Coming Soon... (;", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvPeople.SelectedRows[0];

            string EmailAddress = SelectedRow.Cells["Email"].Value.ToString();

            string MailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={EmailAddress}";

            Process.Start(new ProcessStartInfo(MailtoLink) { UseShellExecute = true });
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (!(FilterColumn == "PersonID" || FilterColumn == "DateOfBirth" || FilterColumn == "Phone"))
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "0000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                _RefreshPeopleDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsPerson.GetAllPeople());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvPeople.DataSource = dv;

            _UpdatePeopleCount();
        }

        private void dgvPeople_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvPeople_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


    }
}