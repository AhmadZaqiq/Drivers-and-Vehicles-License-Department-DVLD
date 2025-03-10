﻿using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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
                this.DataAdded += FormManageUsers.RefreshUsersDataGrid;
        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _SetDefaultValues()
        {
            ctrlUserDetails1.UserID = _UserID;

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
                MessageBox.Show("Username cannot be empty.", "Error");
                return false;
            }

            return true;
        }

        private bool _IsPasswordValid()
        {
            string CurrentPassword = txtCurrentPassword.Text.Trim();
            string NewPassword = txtNewPassword.Text.Trim();
            string ConfirmPassword = txtConfirmPassword.Text.Trim();

            if (_User.Password != CurrentPassword)
            {
                MessageBox.Show("Incorrect current password.", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                MessageBox.Show("Password cannot be blank.", "Error");
                return false;
            }

            if (NewPassword == CurrentPassword)
            {
                MessageBox.Show("The new password cannot be the same as the current password.", "Error");
                return false;
            }

            if (ConfirmPassword != NewPassword)
            {
                MessageBox.Show("The confirmation password does not match the new password.", "Error");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsChangingPassword)
            {
                if (!_IsPasswordValid())
                    return;

                _User.Password = txtNewPassword.Text.Trim();

                if (!_User.Save())
                {
                    MessageBox.Show("Failed to change password", "Failed");
                    return;
                }

                MessageBox.Show("Password updated successfully", "Success");
                DataAdded?.Invoke();
            }

            else
            {
                if (!_IsUsernameValid())
                    return;

                _User.Username = txtUsername.Text.Trim();
                _User.IsActive = chkIsActive.Checked;

                if (!_User.Save())
                {
                    MessageBox.Show("Failed to update", "Failed");
                    return;
                }

                MessageBox.Show("Updated successfully", "Success");
                DataAdded?.Invoke();
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Error, Username connot be Blank");
            }

            else if (clsUser.IsUserExists(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, string.Format("Error, {0} Exists", txtUsername.Text));
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Please enter Password");
            }

            else if (txtNewPassword.Text.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Error, Password must be at least 4 characters long");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Error, Password confirmation does not match");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

    }
}
