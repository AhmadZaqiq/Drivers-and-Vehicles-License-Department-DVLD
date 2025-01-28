using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlShowPersonDetails : UserControl
    {
        public ctrlShowPersonDetails()
        {
            InitializeComponent();
        }

        private clsPerson _Person;

        private int _PersonID;
        public int PersonID
        {
            set
            {
                _PersonID = value;
                lblPersonID.Text = _PersonID.ToString();
                _Person = clsPerson.GetPersonByID(_PersonID);
                FillPersonData();
            }
            get
            {
                return _PersonID;
            }
        }

        public void FillPersonData()
        {
            lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            lblNationalNO.Text = _Person.NationalNo;
            lblGender.Text = _Person.Gendor;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("yyyy-MM-dd");
        }
    }
}
