using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms
{
    public partial class frmListUsers : Form
    {
        private DataTable _UsersTable = clsUser.GetAllUsers();

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _FillUsersFilterComboBox();

            _RefreshUsersDataGrid();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _FillUsersFilterComboBox()
        {
            dgvUsers.DataSource = _UsersTable;

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn Column in _UsersTable.Columns)
            {
                cbFilter.Items.Add(Column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateUsersCount()
        {
            lblRecordsCount.Text = (dgvUsers.RowCount).ToString();
        }

        private void _RefreshUsersDataGrid()
        {
            _UsersTable = clsUser.GetAllUsers();

            dgvUsers.DataSource = _UsersTable;

            _UpdateUsersCount();
        }

        private void _FillIsActiveComboBox()
        {
            dgvUsers.DataSource = _UsersTable;

            cbIsActive.Items.Clear();

            cbIsActive.Items.Add("None");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");

            cbIsActive.SelectedIndex = 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem?.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                _RefreshUsersDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsUser.GetAllUsers());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvUsers.DataSource = dv;

            _UpdateUsersCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshUsersDataGrid();

            string FilterColumn = cbFilter.SelectedItem.ToString();

            switch (FilterColumn)
            {
                case "None":
                    txtFilter.Visible = false;
                    cbIsActive.Visible = false;
                    break;

                case "UserID":
                case "PersonID":
                    txtFilter.Mask = "0000000000";
                    txtFilter.PromptChar = ' ';
                    break;

                case "IsActive":
                    _FillIsActiveComboBox();
                    txtFilter.Visible = false;
                    cbIsActive.Visible = true;
                    break;

                default:
                    break;
            }

            txtFilter.Focus();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IsActiveFilter = cbIsActive.SelectedItem?.ToString();
            DataView dv = new DataView(clsUser.GetAllUsers());

            switch (IsActiveFilter)
            {
                case "Yes":
                    dv.RowFilter = "[IsActive] = true";
                    break;

                case "No":
                    dv.RowFilter = "[IsActive] = false";
                    break;

                default:
                    dgvUsers.DataSource = dv;
                    _UpdateUsersCount();
                    return;
            }

            dgvUsers.DataSource = dv;
            _UpdateUsersCount();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUser AddNewUserForm = new frmAddUser();
            AddNewUserForm.ShowDialog();

            _RefreshUsersDataGrid();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmShowUserDetails FormUserDetails = new frmShowUserDetails(UserID);
            FormUserDetails.ShowDialog();

            _RefreshUsersDataGrid();
        }

        private void AddNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUser FormAddandUpdateUser = new frmAddUser();
            FormAddandUpdateUser.ShowDialog();

            _RefreshUsersDataGrid();
        }

        private void EditUsernameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, false);
            FormUpdateUsername.ShowDialog();

            _RefreshUsersDataGrid();
        }

        private void ChangePasswordStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, true);
            FormUpdateUsername.ShowDialog();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this User?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (UserID == clsCurrentUser.CurrentUser.ID)
            {
                clsMessageBoxManager.ShowMessageBox("You cannot delete the account you are currently logged into.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!clsUser.DeleteUser(UserID))
            {
                clsMessageBoxManager.ShowMessageBox("User was not deleted because it is linked to other transactions in the system...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _RefreshUsersDataGrid();
        }

        private void SendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvUsers.SelectedRows[0];

            int PersonID = Convert.ToInt32(SelectedRow.Cells["PersonID"].Value);

            clsPerson Person1 = clsPerson.GetPersonByID(PersonID);

            string MailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={Person1.Email}";

            Process.Start(new ProcessStartInfo(MailtoLink) { UseShellExecute = true });
        }

        private void CallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMessageBoxManager.ShowMessageBox("Coming Soon... (;", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUsers_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvUsers_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
