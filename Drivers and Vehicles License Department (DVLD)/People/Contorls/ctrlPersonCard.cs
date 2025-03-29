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
    public partial class ctrlPersonCard : UserControl
    {
        private frmListPeople _frmPeople = new frmListPeople();

        private clsPerson _Person;

        private clsCountry _Country;

        private int _PersonID;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            set
            {
                _PersonID = value;

                if (_PersonID == -1)
                {
                    _ClearPersonDetails();
                    return; // Exits only from get
                }

                _DisplayPersonDetails();
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

        private void _LoadPersonData()
        {
            _Person = clsPerson.GetPersonByID(_PersonID);
            _Country = clsCountry.GetCountryByPersonID(_PersonID);
        }

        private void _DisplayPersonDetails()
        {
            _LoadPersonData();

            if (_Person == null)
            {
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = _Person.FullName;
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
            {
                return;
            }

            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(_Person.PersonID, _frmPeople);
            frmAddAndUpdatePeople.ShowDialog();
        }


    }
}
