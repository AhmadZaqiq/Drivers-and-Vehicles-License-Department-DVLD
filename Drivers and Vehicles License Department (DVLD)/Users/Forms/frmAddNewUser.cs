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
    public partial class frmAddNewUser : Form
    {

        private frmPeople _frmPeople = new frmPeople();
        private clsUser _User= new clsUser();
        private int _PersonID = 0;

        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _FillComboBox();
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
            if (!String.IsNullOrEmpty((txtFilter.Text)))
            {

                _PersonID = Convert.ToInt32(txtFilter.Text.Trim());

                if (clsPerson.IsPersonExists(_PersonID))
                {
                    ctrlShowPersonDetails1.PersonID = _PersonID;
                    btnNext.Enabled = true;
                    _SetUserInputFieldsState(true);
                }

                else
                {
                    MessageBox.Show($"There is No Person with ID: {_PersonID}",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ctrlShowPersonDetails1.PersonID = -1;
                    btnNext.Enabled = false;
                    _SetUserInputFieldsState(false);
                }
            }
        }

        private void _GetPersonDetailsByNationalNo()
        {
            if (!String.IsNullOrEmpty((txtFilter.Text)))
            {
                string NationalNo = txtFilter.Text.Trim();

                if (clsPerson.IsPersonExists(NationalNo))
                {
                    _PersonID = clsPerson.GetPersonIDByNationalNO(NationalNo);
                    ctrlShowPersonDetails1.PersonID = _PersonID;
                    btnNext.Enabled = true;
                    _SetUserInputFieldsState(true);
                }

                else
                {
                    MessageBox.Show($"There is No Person with NationalNo: {NationalNo}",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ctrlShowPersonDetails1.PersonID = -1;
                    btnNext.Enabled = false;
                    _SetUserInputFieldsState(false);
                }
            }
        }

        private void _SetUserInputFieldsState(bool IsEnabled)
        {
            txtUsername.Enabled = IsEnabled;
            txtPassword.Enabled = IsEnabled;
            txtConfirmPassword.Enabled = IsEnabled;
            chkIsActive.Enabled = IsEnabled;
            btnShowHidePassword.Enabled = IsEnabled;
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                _GetPersonDetailsByID();
            }

            if (cbFilter.SelectedItem.ToString() == "NationalNO.")
            {
                _GetPersonDetailsByNationalNo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            tabControl1.SelectedTab = tabLoginInfo;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople AddNewPersonForm = new frmAddAndUpdatePeople(-1, _frmPeople);
            AddNewPersonForm.ShowDialog();
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnShowHidePassword.Text = "Hide Password";
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }

            else
            {
                btnShowHidePassword.Text = "Show Password";
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void _FillUserInfo()
        {
            _User.Username = txtUsername.Text;
            _User.Password= txtPassword.Text;
            _User.IsActive= chkIsActive.Checked;
            _User.PersonID=_User.PersonID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillUserInfo();

            if (_User.Save())
            {
                MessageBox.Show("User Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Data not Saved", "Failed");
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

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Error, Please enter Password");
            }

            else if (txtPassword.Text.Length < 4)
            {
                e.Cancel = true;
                txtPassword.Focus();
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
                txtPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Error, Password confirmation does not match");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }
    }
}
