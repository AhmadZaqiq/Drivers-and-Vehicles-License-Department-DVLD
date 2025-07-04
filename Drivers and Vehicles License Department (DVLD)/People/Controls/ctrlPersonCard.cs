using Drivers_and_Vehicles_License_Department__DVLD_.People.Forms;
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

        private clsPerson _Person;

        private int _PersonID = -1;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return _Person;
            }
        }

        private void _SetPersonImage()
        {
            string ImagePath = _Person.ImagePath;

            if (string.IsNullOrEmpty(ImagePath) || !File.Exists(ImagePath))
            {
                ImagePath = _SetDefaultImage();
            }

            pbPersonImage.ImageLocation = ImagePath;
        }

        private void _FillPersonInfo()
        {
            btnEditInfo.Enabled = true;

            _PersonID = _Person.ID;

            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNO.Text = _Person.NationalNo;
            lblGender.Text = (_Person.Gender == 0) ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("yyyy-MM-dd");
            lblCountry.Text = _Person.CountryInfo.Name;

            _SetPersonImage();
        }

        private string _SetDefaultImage()
        {
            string ResourcesPath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");

            if (_PersonID == -1)
            {
                return Path.Combine(ResourcesPath, "MaleAvatar.png");
            }

            string fileName = (_Person.Gender == 0) ? "MaleAvatar.png" : "FemaleAvatar.png";

            return Path.Combine(ResourcesPath, fileName);
        }

        public void ResetPersonInfo()
        {
            btnEditInfo.Enabled = false;

            _PersonID = -1;

            lblPersonID.Text = "N/A";
            lblName.Text = "N/A";
            lblNationalNO.Text = "N/A";
            lblGender.Text = "N/A";
            lblEmail.Text = "N/A";
            lblAddress.Text = "N/A";
            lblPhone.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblCountry.Text = "N/A";

            pbPersonImage.Image = null;
            pbPersonImage.ImageLocation = _SetDefaultImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.GetPersonByID(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.GetPersonByNationalNo(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                return;
            }

            _FillPersonInfo();
        }

        private void btnEditInfoClick(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople FormAddAndUpdatePeople = new frmAddAndUpdatePeople(_Person.ID);
            FormAddAndUpdatePeople.ShowDialog();

            LoadPersonInfo(_PersonID);
        }


    }
}
