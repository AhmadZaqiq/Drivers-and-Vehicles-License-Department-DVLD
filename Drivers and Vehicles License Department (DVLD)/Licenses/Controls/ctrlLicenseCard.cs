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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    public partial class ctrlLicenseCard : UserControl
    {
        private clsLicense _License;

        private int _LicenseID;

        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _License;
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.GetLicenseByID(_LicenseID);

            if (_License == null)
            {
                clsMessageBoxManager.ShowMessageBox("Could not find License ID = " + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _FillLicenseInfo();

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            string imagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    pbPersonalImage.Load(imagePath);
                }

                catch (Exception ex)
                {
                    clsMessageBoxManager.ShowMessageBox("Error loading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            string resourcesPath = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");
            string fileName = (_License.DriverInfo.PersonInfo.Gender == 0) ? "MaleAvatar.png" : "FemaleAvatar.png";
            string defaultImagePath = Path.Combine(resourcesPath, fileName);

            if (File.Exists(defaultImagePath))
            {
                try
                {
                    pbPersonalImage.Image = Image.FromFile(defaultImagePath);
                }

                catch (Exception ex)
                {
                    clsMessageBoxManager.ShowMessageBox("Error loading default image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            clsMessageBoxManager.ShowMessageBox("Could not find any image: " + defaultImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillLicenseInfo()
        {
            lblLicenseID.Text = _License.ID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.ClassInfo.Name;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNO.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = string.IsNullOrWhiteSpace(_License.Notes) ? "No Notes" : _License.Notes;
        }


    }
}
