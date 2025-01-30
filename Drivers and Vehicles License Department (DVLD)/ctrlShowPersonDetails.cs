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
    public partial class ctrlShowPersonDetails : UserControl
    {
        public ctrlShowPersonDetails()
        {
            InitializeComponent();
        }

        private clsPerson _Person;
        private clsCountry _Country;

        private int _PersonID;

        private string _SetDefaultImage()
        {
            string ResourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            string FileName = (_Person.Gendor == "Male") ? "MaleAvatar.png" : "FemaleAvatar.png";

            return Path.Combine(ResourcesPath, FileName);
        }

        public int PersonID
        {
            set
            {
                _PersonID = value;
                lblPersonID.Text = _PersonID.ToString();
                _Person = clsPerson.GetPersonByID(_PersonID);
                _Country = clsCountry.GetCountryByPersonID(_PersonID);
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
            lblCountry.Text = _Country.CountryName;

            if (_Person.ImagePath != null)
            {
                pbPersonalImage.BackgroundImage = Image.FromFile(_SetDefaultImage());
                pbPersonalImage.BackgroundImageLayout = ImageLayout.Stretch;
            }

            else
            {
              //  pbPersonalImage.BackgroundImage = ;
            }
        }
    }
}
