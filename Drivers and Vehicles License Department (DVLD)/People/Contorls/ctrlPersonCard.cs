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
            string resourcesPath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");

            if (_PersonID == -1)
            {
                return Path.Combine(resourcesPath, "MaleAvatar.png");
            }

            string fileName = (_Person.Gender == 0) ? "MaleAvatar.png" : "FemaleAvatar.png";

            return Path.Combine(resourcesPath, fileName);
        }

        private void _SetPersonImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages", _Person.ImagePath);

            pbPersonalImage.BackgroundImage = File.Exists(imagePath)
                ? Image.FromFile(imagePath)
                : Image.FromFile(_SetDefaultImage());
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

        private void _DisplayPersonDetails()
        {
            _Person = clsPerson.GetPersonByID(_PersonID);

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
            lblCountry.Text = _Person.CountryInfo.CountryName;

            _SetPersonImage();
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
