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
        private clsUser _User = new clsUser(); //Unlike with 'People Addition', here we only create the object because there is no 'Update User' operation here.

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _CollectUserInfoFromForm()
        {
            _User.Username = txtUsername.Text;
            _User.Password = clsUtil.ComputeHash(txtPassword.Text);
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            bool IsPasswordHidden = (txtPassword.PasswordChar == '*');

            txtPassword.UseSystemPasswordChar = !IsPasswordHidden;
            txtConfirmPassword.UseSystemPasswordChar = !IsPasswordHidden;

            txtPassword.PasswordChar = IsPasswordHidden ? '\0' : '*';
            txtConfirmPassword.PasswordChar = IsPasswordHidden ? '\0' : '*';

            btnShowHidePassword.BackgroundImage = IsPasswordHidden ? Resources.eye_46_512 : Resources.eye_50_512;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Some fileds are not valid!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
            {
                clsMessageBoxManager.ShowMessageBox("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.IsUserExists(txtUsername.Text.Trim()))
            {
                clsMessageBoxManager.ShowMessageBox("Username already exists", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a person first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _CollectUserInfoFromForm();

            if (!_User.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data not Saved...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabLoginInfo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
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
