using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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
    public partial class frmUpdateUsername : Form
    {
        public event Action DataAdded;

        clsUser _User;
        int _UserID;
        private bool _IsChangingPassword = false;


        public frmUpdateUsername(int UserID, bool IsChangingPassword, frmManageUsers FormManageUsers)
        {
            InitializeComponent();

            _UserID = UserID;

            _User = clsUser.GetUserByID(_UserID);

            _IsChangingPassword = IsChangingPassword;

            if (FormManageUsers != null)
            {
                this.DataAdded += FormManageUsers.RefreshUsersDataGrid;
            }
        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _SetDefaultValues()
        {
            ctrlUserCard1.UserID = _UserID;

            lblTitle.Text = (_IsChangingPassword ? "Change Password" : "Update User");

            _UpdateVisibility();
        }

        private void _PopulateUserFields()
        {
            txtUsername.Text = _User.Username;
            chkIsActive.Checked = _User.IsActive;
        }

        private void _UpdateVisibility()
        {
            if (_IsChangingPassword)
            {
                txtCurrentPassword.Visible = true;
                txtNewPassword.Visible = true;
                txtConfirmPassword.Visible = true;

                lblUsername.Visible = false;
                txtUsername.Visible = false;
                chkIsActive.Visible = false;
            }

            else
            {
                lblUsername.Visible = true;
                txtUsername.Visible = true;
                chkIsActive.Visible = true;
                _PopulateUserFields();

                txtCurrentPassword.Visible = false;
                txtNewPassword.Visible = false;
                txtConfirmPassword.Visible = false;
            }
        }

        private bool _IsUsernameValid()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                clsMessageBoxManager.ShowMessageBox("Username cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool _IsPasswordValid()
        {
            string CurrentPassword = txtCurrentPassword.Text.Trim();
            string NewPassword = txtNewPassword.Text.Trim();
            string ConfirmPassword = txtConfirmPassword.Text.Trim();

            if (_User.Password != clsUtil.ComputeHash(CurrentPassword))
            {
                clsMessageBoxManager.ShowMessageBox("Incorrect current password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                clsMessageBoxManager.ShowMessageBox("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (NewPassword == CurrentPassword)
            {
                clsMessageBoxManager.ShowMessageBox("The new password cannot be the same as the current password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ConfirmPassword != NewPassword)
            {
                clsMessageBoxManager.ShowMessageBox("The confirmation password does not match the new password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsChangingPassword)
            {
                if (!_IsPasswordValid())
                {
                    return;
                }

                _User.Password = clsUtil.ComputeHash(txtNewPassword.Text.Trim());

                if (!_User.Save())
                {
                    clsMessageBoxManager.ShowMessageBox("Failed to change password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsMessageBoxManager.ShowMessageBox("Password updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataAdded?.Invoke();
            }

            else
            {
                if (!_IsUsernameValid())
                {
                    return;
                }

                _User.Username = txtUsername.Text.Trim();
                _User.IsActive = chkIsActive.Checked;

                if (!_User.Save())
                {
                    clsMessageBoxManager.ShowMessageBox("Failed to update", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsMessageBoxManager.ShowMessageBox("Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataAdded?.Invoke();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Error, Username cannot be blank");
                return;
            }

            if (clsUser.IsUserExists(username))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, $"Error, {username} exists");
                return;
            }

            errorProvider1.SetError(txtUsername, "");
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(password))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Please enter a password");
                return;
            }

            if (password.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Password must be at least 4 characters long");
                return;
            }

            errorProvider1.SetError(txtNewPassword, "");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Error, Password confirmation does not match");
                return;
            }

            errorProvider1.SetError(txtConfirmPassword, "");
        }


    }
}
