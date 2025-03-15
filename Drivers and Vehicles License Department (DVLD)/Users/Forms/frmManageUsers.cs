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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshUsersDataGrid();

            _FillUsersFilterComboBox();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillIsActiveComboBox()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();

            cbIsActive.Items.Clear();

            cbIsActive.Items.Add("None");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");

            cbIsActive.SelectedIndex = 0;
        }

        private void _FillUsersFilterComboBox()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn Column in clsUser.GetAllUsers().Columns)
            {
                cbFilter.Items.Add(Column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        public void RefreshUsersDataGrid()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();

            _UpdateUsersCount();
        }

        private void _UpdateUsersCount()
        {
            lblRecordsCount.Text = (dgvUsers.RowCount).ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem?.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                RefreshUsersDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsUser.GetAllUsers());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvUsers.DataSource = dv;

            _UpdateUsersCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUsersDataGrid();

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
            frmAddUser AddNewUserForm = new frmAddUser(this);
            AddNewUserForm.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmShowUserDetails FormUserDetails = new frmShowUserDetails(UserID);
            FormUserDetails.ShowDialog();
        }

        private void AddNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUser FormAddandUpdateUser = new frmAddUser(this);
            FormAddandUpdateUser.ShowDialog();
        }

        private void EditUsernameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, false, this);
            FormUpdateUsername.ShowDialog();
        }

        private void ChangePasswordStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, true, this);
            FormUpdateUsername.ShowDialog();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this User?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            if (UserID == clsCurrentUser.CurrentUser.UserID)
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
            RefreshUsersDataGrid();
        }

        private void SendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

            clsPerson Person1 = clsPerson.GetPersonByID(PersonID);

            string mailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={Person1.Email}";

            Process.Start(new ProcessStartInfo(mailtoLink) { UseShellExecute = true });
        }

        private void CallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon... (;", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
