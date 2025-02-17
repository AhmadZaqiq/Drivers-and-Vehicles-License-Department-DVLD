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

        private clsPerson _Person = new clsPerson();
        private clsCountry _Country = new clsCountry();

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
            _FillPersonInformation(); //For Update
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
            rbMale.Checked = _Person.Gender == 0 ? true : false;
            rbFemale.Checked = _Person.Gender == 1 ? true : false;
        }

        private void _UpdateBackgroundImage()
        {
            MessageBox.Show("This feature is currently not available :( ", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _FillPersonInformation()
        {
            if (_Mode == enMode.Update && _PersonID != -1)
            {
                if (clsPerson.IsPersonExists(_PersonID))
                {
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
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_VerifyAllInputs())
            {
                int CountryID = clsCountry.GetCountryID(cbCountry.Text);

                _Person.NationalNo = txtNationalNO.Text;
                _Person.FirstName = txtFirstName.Text;
                _Person.SecondName = txtSecondName.Text;
                _Person.ThirdName = txtThirdName.Text;
                _Person.LastName = txtLastName.Text;
                _Person.DateOfBirth = dtpDateOfBirth.Value;
                _Person.Gender = rbMale.Checked ? 0 : 1;
                _Person.Address = txtAddress.Text;
                _Person.Phone = txtPhone.Text;
                _Person.Email = txtEmail.Text;
                _Person.NationalityCountryID = CountryID;

                if (_Person.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Success");
                    DataAdded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Data not Saved", "Failed");
                }
            }

            else
            {
                MessageBox.Show("Some required fields are missing. Please fill in all the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.ToLower().EndsWith("@gmail.com"))
                {
                    e.Cancel = true;
                    txtEmail.Focus();
                    errorProvider1.SetError(txtEmail, "Error, Invalid value");
                    btnSave.Enabled = false;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                    btnSave.Enabled = true;
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
                btnSave.Enabled = true;
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