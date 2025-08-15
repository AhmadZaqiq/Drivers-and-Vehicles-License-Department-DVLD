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


namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Controls
{
    public partial class ctrlInternationalLicenseCard : UserControl
    {
        private clsInternationalLicense _InternationalLicense;

        private int _InternationalLicenseID;

        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID
        {
            get
            {
                return _InternationalLicenseID;
            }
        }

        public clsInternationalLicense InternationalLicenseInfo
        {
            get
            {
                return _InternationalLicense;
            }
        }

        private void _LoadPersonImage()
        {
            string imagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    pbPersonalImage.Load(imagePath);
                }

                catch (Exception ex) { clsDVLDLogger.LogException(ex); }

                return;
            }

            string resourcesPath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");
            string fileName = (_InternationalLicense.DriverInfo.PersonInfo.Gender == 0) ? "MaleAvatar.png" : "FemaleAvatar.png";
            string defaultImagePath = Path.Combine(resourcesPath, fileName);

            if (File.Exists(defaultImagePath))
            {
                try
                {
                    pbPersonalImage.Image = Image.FromFile(defaultImagePath);
                }

                catch (Exception ex) { clsDVLDLogger.LogException(ex); }

                return;
            }

            clsMessageBoxManager.ShowMessageBox("Could not find any image: " + defaultImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillInternationalLicenseDetails()
        {
            lblName.Text = _InternationalLicense.ApplicantFullName;
            lblInternationLicenseID.Text = _InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNO.Text = _InternationalLicense.ApplicantPersonInfo.NationalNo.ToString();
            lblGender.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicense.ApplicantPersonInfo.DateOfBirth.ToString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();

            _LoadPersonImage();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                clsMessageBoxManager.ShowMessageBox("Could not find International License ID = " + _InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            _FillInternationalLicenseDetails();
        }


    }
}
