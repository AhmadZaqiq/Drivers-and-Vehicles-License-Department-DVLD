using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlAddNewPerson : UserControl
    {
        private clsPerson _Person = new clsPerson();

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
            rbMale.Checked = _Person.Gendor == "Male" ? true : false;
            rbFemale.Checked = _Person.Gendor == "Female" ? true : false;
        }


        private void FillPersonInformation()
        {
            if (_Mode == enMode.Update && _PersonID != -1)
            {
                if (clsPerson.IsPersonExists(_PersonID))
                {
                    _Person = clsPerson.GetPersonByID(_PersonID);
                    txtFirstName.Text = _Person.FirstName;
                    txtSecondName.Text = _Person.SecondName;
                    txtThirdName.Text = _Person.ThirdName;
                    txtLastName.Text = _Person.LastName;
                    txtNationalNO.Text = _Person.NationalNo;
                    dtpDateOfBirth.Value = _Person.DateOfBirth;
                    UpdateGender();
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
        }

        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {
            _FillCountriesComboBox();
            _SetDefaultValues();
            FillPersonInformation();
        }
    }
}
