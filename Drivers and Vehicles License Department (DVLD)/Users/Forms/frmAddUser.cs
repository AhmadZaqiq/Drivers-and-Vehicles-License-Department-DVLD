using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms
{
    public partial class frmAddUser : Form
    {
        public event Action DataAdded;

        private frmListPeople _frmPeople = new frmListPeople();

        private clsUser _User = new clsUser(); //Unlike with 'People Addition', here we only create the object because there is no 'Update User' operation here.

        public frmAddUser(frmManageUsers FormManageUsers)
        {
            InitializeComponent();

            this.DataAdded += FormManageUsers.RefreshUsersDataGrid;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillUserInfo()
        {
            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
        }

        private bool _CheckInputsValidity()
        {
            return string.IsNullOrWhiteSpace(txtUsername.Text.Trim()) ||
                             clsUser.IsUserExists(txtUsername.Text.Trim()) ||
                             string.IsNullOrWhiteSpace(txtPassword.Text) ||
                             txtPassword.Text.Length < 4 ||
                             txtConfirmPassword.Text != txtPassword.Text;
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            bool IsPasswordHidden = txtPassword.PasswordChar == '*';

            txtPassword.UseSystemPasswordChar = !IsPasswordHidden;
            txtConfirmPassword.UseSystemPasswordChar = !IsPasswordHidden;

            txtPassword.PasswordChar = IsPasswordHidden ? '\0' : '*';
            txtConfirmPassword.PasswordChar = IsPasswordHidden ? '\0' : '*';

            btnShowHidePassword.BackgroundImage = IsPasswordHidden ? Resources.eye_46_512 : Resources.eye_50_512;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillUserInfo();

            if (_CheckInputsValidity())
            {
                clsMessageBoxManager.ShowMessageBox("One or more inputs are invalid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a person first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_User.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data not Saved...", "Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabLoginInfo;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text.Trim()) && !clsUser.IsUserExists(txtUsername.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
                return;
            }

            e.Cancel = true;
            errorProvider1.SetError(txtUsername, string.IsNullOrWhiteSpace(txtUsername.Text.Trim())
                ? "Error, Username cannot be blank"
                : string.Format("Error, {0} Exists", txtUsername.Text));
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) && txtPassword.Text.Length >= 4)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
                return;
            }

            e.Cancel = true;
            errorProvider1.SetError(txtPassword, string.IsNullOrWhiteSpace(txtPassword.Text.Trim())
                ? "Error, Please enter Password"
                : "Error, Password must be at least 4 characters long");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() == txtPassword.Text.Trim())
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
                return;
            }

            e.Cancel = true;
            errorProvider1.SetError(txtConfirmPassword, "Error, Password confirmation does not match");
        }


    }
}
