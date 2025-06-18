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
using Microsoft.Win32;
using SiticoneNetFrameworkUI;

namespace Drivers_and_Vehicles_License_Department__DVLD_.People.Forms
{
    public partial class frmAddAndUpdatePeople : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        private clsPerson _Person;

        public enum enMode { AddNew = 0, Update = 1 };

        public enum enGender { Male = 0, Female = 1 };


        private enMode _Mode = enMode.AddNew;

        private int _PersonID = -1;

        public frmAddAndUpdatePeople()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddAndUpdatePeople(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void frmAddAndUpdatePeople2_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _FillPersonFieldsForUpdate();
            }

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesComboBox();

            lblTitle.Text = (_Mode == enMode.AddNew) ? "Add New Person" : "Update Person";

            _Person = (_Mode == enMode.AddNew) ? new clsPerson() : null;

            rbMale.Checked = true;

            _RefreshDefaultPersonImage();

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            btnRemoveImage.Enabled = (pbPersonImage.ImageLocation != null);
        }

        private void _FillCountriesComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            cbCountry.DataSource = Countries;
            cbCountry.DisplayMember = "CountryName";
        }

        private void _RefreshDefaultPersonImage()
        {
            string ImagePath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");

            if (pbPersonImage.ImageLocation != null) 
            {
                return;
            }

            if (rbMale.Checked)
            {
                pbPersonImage.Image = Image.FromFile(Path.Combine(ImagePath, "MaleAvatar.png"));
                return;
            }

            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Image.FromFile(Path.Combine(ImagePath, "FemaleAvatar.png"));
            }
        }

        private void _FillPersonFieldsForUpdate()
        {
            _Person = clsPerson.GetPersonByID(_PersonID);

            if (_Person == null)
            {
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNO.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            _UpdateGender();
            cbCountry.Text = _Person.CountryInfo.CountryName;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;

            if (_Person.ImagePath == null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            btnRemoveImage.Enabled = (_Person.ImagePath != null);
        }

        private void _UpdateGender()
        {
            rbMale.Checked = (_Person.Gender == 0);
            rbFemale.Checked = (_Person.Gender == 1);
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath == pbPersonImage.ImageLocation)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                try
                {
                    File.Delete(_Person.ImagePath);
                }
                catch (IOException)
                {

                }
            }

            if (pbPersonImage.ImageLocation == null)
            {
                return true;
            }

            string SourceImageFile = pbPersonImage.ImageLocation;

            if (!clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
            {
                clsMessageBoxManager.ShowMessageBox("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            pbPersonImage.ImageLocation = SourceImageFile;
            return true;
        }

        private void _CollectPersonInfoFromForm()
        {
            _Person.NationalNo = txtNationalNO.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = (short)(rbMale.Checked ? enGender.Male : enGender.Female);
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.NationalityCountryID = clsCountry.GetCountry(cbCountry.Text).CountryID;

            // If no image is selected, the default behavior will store a null value in the database.
            if (pbPersonImage.ImageLocation != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Calls validation on all child controls to ensure user input is valid before proceeding.
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Some fields are not valid, Put the mouse over the red icon to see the error.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }

            _CollectPersonInfoFromForm();

            if (!_Person.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            _Mode = enMode.Update;
            lblTitle.Text = "Update Person";

            DataBack?.Invoke(this, _Person.PersonID);

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSetNewPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            pbPersonImage.Load(openFileDialog1.FileName);

            btnRemoveImage.Enabled = true;
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            _RefreshDefaultPersonImage();
             
            btnRemoveImage.Enabled = false;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            _RefreshDefaultPersonImage();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                return;
            }

            if (!clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
                return;
            }

            errorProvider1.SetError(txtEmail, null);
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            string NationalNo = txtNationalNO.Text.Trim();

            if (string.IsNullOrEmpty(NationalNo))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNO, "This field is required!");
                return;
            }

            if (NationalNo != _Person.NationalNo && clsPerson.DoesPersonExist(NationalNo))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNO, "National Number is used for another person!");
                return;
            }

            errorProvider1.SetError(txtNationalNO, null);
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            SiticoneTextBox temp = (SiticoneTextBox)sender;

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required!");
                return;
            }

            errorProvider1.SetError(temp, null);
        }


    }
}
