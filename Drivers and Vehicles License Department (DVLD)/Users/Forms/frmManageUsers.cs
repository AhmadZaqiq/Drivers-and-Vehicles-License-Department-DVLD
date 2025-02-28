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

            _FillFilterComboBox();

            _MakeRoundedCorners(30); //to make the form rounded

            _OpenFormEffect();
        }

        private void _MakeRoundedCorners(int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcSize = borderRadius * 2;

            // Create rounded rectangle
            path.AddArc(new Rectangle(0, 0, arcSize, arcSize), 180, 90);
            path.AddArc(new Rectangle(Width - arcSize, 0, arcSize, arcSize), 270, 90);
            path.AddArc(new Rectangle(Width - arcSize, Height - arcSize, arcSize, arcSize), 0, 90);
            path.AddArc(new Rectangle(0, Height - arcSize, arcSize, arcSize), 90, 90);
            path.CloseFigure();

            // Apply region
            this.Region = new Region(path);
        }

        private void _OpenFormEffect()
        {
            int startY = this.Top - 50;
            this.Top = startY;
            this.Opacity = 0;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                if (this.Top < startY + 50) this.Top += 2;
                else timer.Stop();
            };
            timer.Start();
        }

        private void _CloseFormEffect()
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (this.Opacity > 0) this.Opacity -= 0.05;
                if (this.Width > 10) this.Width -= 20;
                if (this.Height > 10) this.Height -= 15;
                if (this.Opacity <= 0) { timer.Stop(); this.Close(); }
            };
            timer.Start();
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

        private void _FillFilterComboBox()
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
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshUsersDataGrid(); // Return the complete data in the table after clearing the search box.
            }
            else
            {
                DataView dv = new DataView(clsUser.GetAllUsers());
                dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
                dgvUsers.DataSource = dv;

                _UpdateUsersCount();
            }
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

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IsActiveFilter = cbIsActive.SelectedItem.ToString();

            DataView dv = new DataView(clsUser.GetAllUsers());

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
            frmAddUser AddNewUserForm = new frmAddUser();
            AddNewUserForm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmShowUserDetails FormUserDetails = new frmShowUserDetails(UserID);
            FormUserDetails.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUser FormAddandUpdateUser = new frmAddUser();
            FormAddandUpdateUser.ShowDialog();
        }

        private void editUsernameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, false);
            FormUpdateUsername.ShowDialog();
        }

        private void changePasswordStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            frmUpdateUsername FormUpdateUsername = new frmUpdateUsername(UserID, true);
            FormUpdateUsername.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            if (MessageBox.Show("Are You Sure you want to delete this User?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                MessageBox.Show("User was not deleted because it is linked to other transactions in the system...", "Alert");
                return;
            }

            int UserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            if (!clsUser.DeleteUser(UserID))
                return;

            MessageBox.Show("User deleted successfully.", "Done");
            RefreshUsersDataGrid();
        }

        private void sendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

            clsPerson Person1 = clsPerson.GetPersonByID(PersonID);

            string mailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={Person1.Email}";

            Process.Start(new ProcessStartInfo(mailtoLink) { UseShellExecute = true });
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
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
