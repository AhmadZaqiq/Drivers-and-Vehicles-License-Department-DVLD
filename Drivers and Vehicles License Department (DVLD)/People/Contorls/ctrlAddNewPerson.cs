﻿using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            _PopulatePersonFieldsForUpdate();
        }

        private void _UpdateMode()
        {
            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void _RefreshPersonalImage()
        {
            if (pbPersonalImage.Tag?.ToString() != "ImageSet")
            {
                if (rbMale.Checked)
                {
                    pbPersonalImage.BackgroundImage = Resources.MaleAvatar;
                    pbPersonalImage.Tag = "Male";
                }
                else if (rbFemale.Checked)
                {
                    pbPersonalImage.BackgroundImage = Resources.FemaleAvatar;
                    pbPersonalImage.Tag = "Female";
                }
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
            MessageBox.Show("This feature is currently not available :( ", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _PopulatePersonFieldsForUpdate()
        {
            if (_Mode != enMode.Update && !clsPerson.IsPersonExists(_PersonID))
                return;

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

        private bool _VerifyAllInputs()
        {
            return !(string.IsNullOrEmpty(txtFirstName.Text) ||
                     string.IsNullOrEmpty(txtSecondName.Text) ||
                     string.IsNullOrEmpty(txtLastName.Text) ||
                     string.IsNullOrEmpty(txtNationalNO.Text) ||
                     string.IsNullOrEmpty(txtPhone.Text) ||
                     string.IsNullOrEmpty(txtAddress.Text));
        }

        private void _SetDefaultValues()
        {
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            cbCountry.Text = "Jordan";
            pbPersonalImage.Tag = "Male";
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            _UpdateBackgroundImage();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_VerifyAllInputs())
            {
                MessageBox.Show("Some required fields are missing. Please fill in all the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person = (clsPerson.IsPersonExists(_PersonID)) ? clsPerson.GetPersonByID(_PersonID) : new clsPerson(); // To determine whether Add or Update

            _LoadPersonData();

            if (!_Person.Save())
            {
                MessageBox.Show("Data not Saved", "Failed");
                return;
            }

            MessageBox.Show("Data Saved Successfully", "Success");
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
            if (string.IsNullOrWhiteSpace(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "Error, Please enter Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSecondName.Text.Trim()))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Error, Please enter Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecondName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text.Trim()))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Error, Please enter Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                txtNationalNO.Focus();
                errorProvider1.SetError(txtNationalNO, "Error, Please enter National Number");
            }

            else if (clsPerson.IsPersonExists(txtNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                txtNationalNO.Focus();
                errorProvider1.SetError(txtNationalNO, string.Format("Error, {0} Exists", txtNationalNO.Text));
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNO, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Error, Please enter Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = txtEmail.Text;

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!Email.ToLower().EndsWith("@gmail.com") || Email.StartsWith("@"))
                {
                    e.Cancel = true;
                    txtEmail.Focus();
                    errorProvider1.SetError(txtEmail, "Error, Invalid value");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Error, Please enter Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
        }

    }
}