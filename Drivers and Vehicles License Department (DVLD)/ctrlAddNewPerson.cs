using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlAddNewPerson : UserControl
    {
        private clsPerson _Person = new clsPerson();
        private clsCountry _Country = new clsCountry();

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _PersonID = -1;

        public ctrlAddNewPerson()
        {
            InitializeComponent();

        }

        private void _UpdateMode()
        {
            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
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

        private void _FillCountriesComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            cbCountry.DataSource = Countries;
            cbCountry.DisplayMember = "CountryName";
        }

        private void UpdateGender()
        {
            rbMale.Checked = _Person.Gender == 0 ? true : false;
            rbFemale.Checked = _Person.Gender == 1 ? true : false;
        }

        private void FillPersonInformation()
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
                    UpdateGender();
                    cbCountry.Text = _Country.CountryName;
                    txtPhone.Text = _Person.Phone;
                    txtEmail.Text = _Person.Email;
                    txtAddress.Text = _Person.Address;
                }
            }
        }

        private void _SetDefaultValues()
        {
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            cbCountry.Text = "Jordan";
        }

        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {
            _FillCountriesComboBox();
            _SetDefaultValues();
            FillPersonInformation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbPersonalImage.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                    pbPersonalImage.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _UpdatePersonalImage();
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
                errorProvider1.SetError(txtNationalNO, "Error, Please txtNationalNO");
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

        private void _UpdatePersonalImage()
        {
            {
                if (rbMale.Checked)
                {
                    pbPersonalImage.BackgroundImage = Resources.MaleAvatar;
                }
                else if (rbFemale.Checked)
                {
                    pbPersonalImage.BackgroundImage = Resources.FemaleAvatar;
                }
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            _UpdatePersonalImage();
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
                errorProvider1.SetError(txtAddress, "Error, Please Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
        }
    }
}
