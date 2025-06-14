using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Users.Controls;
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
        clsUser _User;
        int _UserID;

        private bool _IsChangingPassword = false;

        public frmUpdateUsername(int UserID, bool IsChangingPassword)
        {
            InitializeComponent();

            _UserID = UserID;
            _User = clsUser.GetUserByID(_UserID);

            _IsChangingPassword = IsChangingPassword;
        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
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

                return;
            }

            lblUsername.Visible = true;
            txtUsername.Visible = true;
            chkIsActive.Visible = true;
            _PopulateUserFields();

            txtCurrentPassword.Visible = false;
            txtNewPassword.Visible = false;
            txtConfirmPassword.Visible = false;
        }

        private void _ResetDefaultValues()
        {
            ctrlUserCard1.LoadUserData(_UserID);

            lblTitle.Text = (_IsChangingPassword ? "Change Password" : "Update User");

            _UpdateVisibility();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Some fields are not valid, Put the mouse over the red icon to see the error.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_IsChangingPassword)
            {
                _User.Password = clsUtil.ComputeHash(txtNewPassword.Text.Trim());

                if (!_User.Save())
                {
                    clsMessageBoxManager.ShowMessageBox("Failed to change password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsMessageBoxManager.ShowMessageBox("Password updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                _User.Username = txtUsername.Text.Trim();
                _User.IsActive = chkIsActive.Checked;

                if (!_User.Save())
                {
                    clsMessageBoxManager.ShowMessageBox("Failed to update", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsMessageBoxManager.ShowMessageBox("Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (_IsChangingPassword)
            {
                return;
            }

            string Username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(Username))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Error, Username cannot be blank");
                return;
            }

            if (clsUser.IsUserExists(Username))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, $"Error, {Username} exists");
                return;
            }

            errorProvider1.SetError(txtUsername, "");
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_IsChangingPassword)
            {
                return;
            }

            string CurrentPassword = txtCurrentPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(CurrentPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Error, Please enter current password");
                return;
            }

            if (_User.Password != clsUtil.ComputeHash(CurrentPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Error, Incorrect current password");
                return;
            }

            errorProvider1.SetError(txtCurrentPassword, "");
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_IsChangingPassword)
            {
                return;
            }

            string CurrentPassword = txtCurrentPassword.Text.Trim();
            string NewPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Please enter a password");
                return;
            }

            if (NewPassword.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Password must be at least 4 characters long");
                return;
            }

            if (NewPassword == CurrentPassword)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, The new password cannot be the same as the current password");
                return;
            }

            errorProvider1.SetError(txtNewPassword, "");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_IsChangingPassword)
            {
                return;
            }

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
