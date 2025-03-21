using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using System.Text.RegularExpressions;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlAddNewPerson : UserControl
    {
        public event Action DataAdded;

        private clsPerson _Person;

        private clsCountry _Country;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode = enMode.AddNew;

        private int _PersonID = -1;

        public ctrlAddNewPerson()
        {
            InitializeComponent();
        }

        public string Mode
        {
            get
            {
                return _Mode == enMode.AddNew ? "Add New Person" : "Update Person";
            }
        }

        public int PersonID
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
                _UpdateMode();
            }
        }

        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {
            _FillCountriesComboBox();
            _SetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _PopulatePersonFieldsForUpdate();
            }
        }

        private void _UpdateMode()
        {
            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void _RefreshPersonalImage()
        {
            if (pbPersonalImage.Tag?.ToString() == "ImageSet")
            {
                return;
            }

            if (rbMale.Checked)
            {
                pbPersonalImage.BackgroundImage = Resources.MaleAvatar;
                pbPersonalImage.Tag = "Male";
                return;
            }

            if (rbFemale.Checked)
            {
                pbPersonalImage.BackgroundImage = Resources.FemaleAvatar;
                pbPersonalImage.Tag = "Female";
            }
        }

        private void _FillCountriesComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            cbCountry.DataSource = Countries;
            cbCountry.DisplayMember = "CountryName";
        }

        private void _UpdateGender()
        {
            rbMale.Checked = _Person.Gender == 0;
            rbFemale.Checked = _Person.Gender == 1;
        }

        private void _UpdateBackgroundImage()
        {
            clsMessageBoxManager.ShowMessageBox("This feature is currently not available :( ", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _PopulatePersonFieldsForUpdate()
        {
            if (!clsPerson.IsPersonExists(_PersonID))
            {
                return;
            }

            _Person = clsPerson.GetPersonByID(_PersonID);
            _Country = clsCountry.GetCountryByPersonID(_PersonID);

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNO.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            _UpdateGender();
            cbCountry.Text = _Country.CountryName;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
        }

        private bool _AreAllInputsFilled()
        {
            string[] InputFields = {
                                    txtFirstName.Text,
                                    txtSecondName.Text,
                                    txtLastName.Text,
                                    txtNationalNO.Text,
                                    txtPhone.Text
                                     };

            for (int i = 0; i < InputFields.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(InputFields[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool _IsValidPhoneAndEmail()
        {
            string Email = txtEmail.Text.Trim();

            if (!Regex.IsMatch(txtPhone.Text.Trim(), clsUtil.ValidPhonePattern))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(Email) && !Regex.IsMatch(Email, clsUtil.ValidGmailPattern))
            {
                return false;
            }

            return true;
        }

        private void _SetDefaultValues()
        {
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            cbCountry.Text = "Jordan";
            pbPersonalImage.Tag = "Male";
        }

        private void _LoadPersonData()
        {
            _Person.NationalNo = txtNationalNO.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = rbMale.Checked ? 0 : 1;
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.NationalityCountryID = clsCountry.GetCountryID(cbCountry.Text);
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            _UpdateBackgroundImage();
        }

        private bool _IsValidNationalNO()
        {
            string NationalNO = txtNationalNO.Text.Trim();

            if (_Person.NationalNo != NationalNO)
            {
                return !clsPerson.IsPersonExists(NationalNO);
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_AreAllInputsFilled())
            {
                clsMessageBoxManager.ShowMessageBox("Some required fields are missing. Please fill in all the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_IsValidPhoneAndEmail())
            {
                clsMessageBoxManager.ShowMessageBox("Invalid phone number or email. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person = (clsPerson.IsPersonExists(_PersonID)) ? clsPerson.GetPersonByID(_PersonID) : new clsPerson(); // To determine whether Add or Update

            if (!_IsValidNationalNO())
            {
                clsMessageBoxManager.ShowMessageBox("A person with this national ID is already registered. Please verify the information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadPersonData();

            if (!_Person.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _UpdateBackgroundImage();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            _RefreshPersonalImage();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
                return;
            }

            e.Cancel = true;
            txtFirstName.Focus();
            errorProvider1.SetError(txtFirstName, "Error, Please enter Name");
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSecondName.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecondName, "");
                return;
            }

            e.Cancel = true;
            txtSecondName.Focus();
            errorProvider1.SetError(txtSecondName, "Error, Please enter Name");
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLastName.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
                return;
            }

            e.Cancel = true;
            txtLastName.Focus();
            errorProvider1.SetError(txtLastName, "Error, Please enter Name");
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNO.Text.Trim()) || !_IsValidNationalNO())
            {
                e.Cancel = true;
                txtNationalNO.Focus();
                errorProvider1.SetError(txtNationalNO, string.IsNullOrWhiteSpace(txtNationalNO.Text.Trim())
                    ? "Error, Please enter National Number"
                    : $"Error, {txtNationalNO.Text.Trim()} Exists");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtNationalNO, "");
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string PhoneNumber = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(PhoneNumber) || !Regex.IsMatch(PhoneNumber, clsUtil.ValidPhonePattern))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Error, Please enter a valid Phone Number");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtPhone, "");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = txtEmail.Text.Trim();

            if (!string.IsNullOrWhiteSpace(Email) && !Regex.IsMatch(Email, clsUtil.ValidGmailPattern))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Error, Invalid value");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtEmail, "");
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAddress.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
                return;
            }

            e.Cancel = true;
            txtAddress.Focus();
            errorProvider1.SetError(txtAddress, "Error, Please enter Address");
        }


    }
}