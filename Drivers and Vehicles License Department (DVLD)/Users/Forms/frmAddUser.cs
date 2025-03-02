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

        private frmPeople _frmPeople = new frmPeople();

        private clsUser _User = new clsUser(); //Unlike with 'People Addition', here we only create the object because there is no 'Update User' operation.
        private int _PersonID = -1;

        public frmAddUser(frmManageUsers FormManageUsers)
        {
            InitializeComponent();

            this.DataAdded += FormManageUsers.RefreshUsersDataGrid;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("NationalNO.");
            cbFilter.Items.Add("PersonID");

            cbFilter.SelectedIndex = 0;
        }

        private void _GetPersonDetailsByID()
        {
            if (String.IsNullOrEmpty((txtFilter.Text)))
                return;

            _PersonID = Convert.ToInt32(txtFilter.Text.Trim());

            if (!clsPerson.IsPersonExists(_PersonID))
            {
                MessageBox.Show($"There is No Person with ID: {_PersonID}",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ctrlShowPersonDetails1.PersonID = -1;
                btnNext.Enabled = false;
                _SetUserInputFieldsState(false);

                return;
            }

            ctrlShowPersonDetails1.PersonID = _PersonID;
            btnNext.Enabled = true;
            _SetUserInputFieldsState(true);
        }

        private void _GetPersonDetailsByNationalNo()
        {
            if (String.IsNullOrEmpty((txtFilter.Text)))
                return;

            string NationalNo = txtFilter.Text.Trim();

            if (!clsPerson.IsPersonExists(NationalNo))
            {
                MessageBox.Show($"There is No Person with NationalNo: {NationalNo}",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ctrlShowPersonDetails1.PersonID = -1;
                btnNext.Enabled = false;
                _SetUserInputFieldsState(false);

                return;
            }

            _PersonID = clsPerson.GetPersonIDByNationalNO(NationalNo);
            ctrlShowPersonDetails1.PersonID = _PersonID;
            btnNext.Enabled = true;
            _SetUserInputFieldsState(true);
        }

        private void _SetUserInputFieldsState(bool IsEnabled)
        {
            txtUsername.Enabled = IsEnabled;
            txtPassword.Enabled = IsEnabled;
            txtConfirmPassword.Enabled = IsEnabled;
            chkIsActive.Enabled = IsEnabled;
            btnShowHidePassword.Enabled = IsEnabled;
        }

        private void _FillUserInfo()
        {
            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = _PersonID;
        }

        private bool _CheckInputsValidity()
        {
            return string.IsNullOrWhiteSpace(txtUsername.Text.Trim()) ||
                             clsUser.IsUserExists(txtUsername.Text.Trim()) ||
                             string.IsNullOrWhiteSpace(txtPassword.Text) ||
                             txtPassword.Text.Length < 4 ||
                             txtConfirmPassword.Text != txtPassword.Text;
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            string SelectedFilter = cbFilter.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "PersonID":
                    _GetPersonDetailsByID();
                    break;

                case "NationalNO.":
                    _GetPersonDetailsByNationalNo();
                    break;

                default:
                    MessageBox.Show("Invalid filter selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
            }

            else
            {
                txtFilter.Visible = true;
            }


            if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                txtFilter.Mask = "0000000000";
                txtFilter.PromptChar = ' ';
            }

            else
            {
                txtFilter.Mask = "";
            }

            txtFilter.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabLoginInfo;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople AddNewPersonForm = new frmAddAndUpdatePeople(-1, _frmPeople);
            AddNewPersonForm.ShowDialog();
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
                MessageBox.Show("One or more inputs are invalid...", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_User.Save())
            {
                MessageBox.Show("Data not Saved...", "Failed");
                return;
            }

            MessageBox.Show("User Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Error, Username connot be Blank");
            }

            else if (clsUser.IsUserExists(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, string.Format("Error, {0} Exists", txtUsername.Text));
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Error, Please enter Password");
            }

            else if (txtPassword.Text.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Error, Password must be at least 4 characters long");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
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
