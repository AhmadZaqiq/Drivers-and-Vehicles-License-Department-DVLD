using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlPersonDetails : UserControl
    {
        private frmPeople _frmPeople = new frmPeople();
        private clsPerson _Person = new clsPerson();
        private clsCountry _Country = new clsCountry();
        private int _PersonID;

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            set
            {
                _PersonID = value;
                _FillPersonData();
            }
            get
            {
                return _PersonID;
            }
        }

        private string _SetDefaultImage()
        {
            string ResourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

            if (_PersonID == -1)
            {
                return Path.Combine(ResourcesPath, "MaleAvatar.png");
            }

            string FileName = (_Person.Gender == 0) ? "MaleAvatar.png" : "FemaleAvatar.png";

            return Path.Combine(ResourcesPath, FileName);
        }

        public string _ConvertGenderToText(int Gender)
        {
            return (Gender == 0) ? "Male" : "Female";
        }

        private void _ClearPersonDetails()
        {
            if (_PersonID != -1)
                return;


            lblPersonID.Text = "N\\A";
            lblName.Text = "N\\A";
            lblNationalNO.Text = "N\\A";
            lblGender.Text = "N\\A";
            lblEmail.Text = "N\\A";
            lblAddress.Text = "N\\A";
            lblPhone.Text = "N\\A";
            lblDateOfBirth.Text = "N\\A";
            lblCountry.Text = "N\\A";
            pbPersonalImage.BackgroundImage = Image.FromFile(_SetDefaultImage());
        }

        private void _FillPersonData()
        {
            if ((_PersonID == -1))
            {
                _ClearPersonDetails();
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            _Person = clsPerson.GetPersonByID(_PersonID);
            _Country = clsCountry.GetCountryByPersonID(_PersonID);

            if (_Person == null)
                return;

            lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            lblNationalNO.Text = _Person.NationalNo;
            lblGender.Text = _ConvertGenderToText(_Person.Gender);
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("yyyy-MM-dd");
            lblCountry.Text = _Country.CountryName;
        }

        private void btnEditInfoClick(object sender, EventArgs e)
        {
            if (_Person == null)
                return;

            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(_Person.PersonID, _frmPeople);
            frmAddAndUpdatePeople.ShowDialog();
        }

    }
}
