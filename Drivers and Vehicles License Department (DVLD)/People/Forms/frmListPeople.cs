using DVLD_Business;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            RefreshPeopleDataGrid();

            _FillPeopleComboBox();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillPeopleComboBox()
        {
            DataTable PeopleTable = clsPerson.GetAllPeople();

            dgvPeople.DataSource = PeopleTable;

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn column in PeopleTable.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        public void RefreshPeopleDataGrid()
        {
            dgvPeople.DataSource = clsPerson.GetAllPeople();

            _UpdatePeopleCount();
        }

        private void _UpdatePeopleCount()
        {
            //   lblRecordsCount.Text = clsPerson.GetPeopleCount().ToString();

            lblRecordsCount.Text = (dgvPeople.RowCount).ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshPeopleDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsPerson.GetAllPeople());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvPeople.DataSource = dv;

            _UpdatePeopleCount();
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

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(-1, this);
            frmAddAndUpdatePeople.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

            frmShowPersonDetails FormPersonDetails = new frmShowPersonDetails(PersonID);
            FormPersonDetails.ShowDialog();
        }

        private void AddNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople FormAddAndUpdatePerson = new frmAddAndUpdatePeople(-1, this);
            FormAddAndUpdatePerson.ShowDialog();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(PersonID, this);
            frmAddAndUpdatePeople.ShowDialog();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this Person?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

            if (!clsPerson.DeletePerson(PersonID))
            {
                clsMessageBoxManager.ShowMessageBox("Person was not deleted because it is linked to other transactions in the system...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Person deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshPeopleDataGrid();
        }

        private void CallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessageBoxManager.ShowMessageBox("Coming Soon... (;", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            string emailAddress = selectedRow.Cells["Email"].Value.ToString();

            string mailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={emailAddress}";

            Process.Start(new ProcessStartInfo(mailtoLink) { UseShellExecute = true });
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