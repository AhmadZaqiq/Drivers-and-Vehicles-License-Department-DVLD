using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private DataTable _UsersTable = clsUser.GetAllUsers();

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshUsersDataGrid();

            _FillFilterComboBox();
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

        private void _FillFilterComboBox()
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

        public void RefreshUsersDataGrid()
        {
            dgvUsers.DataSource = _UsersTable;

            _UpdateUsersCount();
        }

        private void _UpdateUsersCount()
        {
            lblRecordsCount.Text = (dgvUsers.RowCount).ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshUsersDataGrid(); // Return the complete data in the table after clearing the search box.
            }
            else
            {
                DataView dv = new DataView(_UsersTable);
                dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
                dgvUsers.DataSource = dv;

                _UpdateUsersCount();
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUsersDataGrid();

            if (cbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
                cbIsActive.Visible = false;
            }

            if (cbFilter.SelectedItem.ToString() == "UserID" || cbFilter.SelectedItem.ToString() == "PersonID")
            {
                txtFilter.Mask = "0000000000";
                txtFilter.PromptChar = ' ';
            }

            else if (cbFilter.SelectedItem.ToString() == "IsActive")
            {
                _FillIsActiveComboBox();
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
            }

            else
            {
                txtFilter.Mask = "";
            }

            txtFilter.Focus();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IsActiveFilter = cbIsActive.SelectedItem.ToString();

            DataView dv = new DataView(_UsersTable);

            if (IsActiveFilter == "Yes")
            {
                dv.RowFilter = "[IsActive] = true";
            }
            else if (IsActiveFilter == "No")
            {
                dv.RowFilter = "[IsActive] = false";
            }

            dgvUsers.DataSource = dv;

            _UpdateUsersCount();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewUser AddNewUserForm = new frmAddNewUser();
            AddNewUserForm.ShowDialog();
        }
    }
}
