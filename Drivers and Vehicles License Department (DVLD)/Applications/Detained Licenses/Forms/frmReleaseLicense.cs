using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Detained_Licenses.Forms
{
    public partial class frmReleaseLicense : Form
    {
        public event Action DataAdded;

        private int _LicenseID;

        private int _DetainID;

        private clsLicense _License;

        private clsApplication _ReleaseLicenseApplication;

        private clsDetainedLicense _DetainedLicense;

        private decimal _ReleaseLicensApplicationTypeFees;

        private const int _ReleaseLicenseApplicationTypeID = 5;

        public frmReleaseLicense(frmListDetainedLicenses FormListDetainedLicenses = null)
        {
            InitializeComponent();

            if (FormListDetainedLicenses != null)
            {
                this.DataAdded += FormListDetainedLicenses.RefreshDetainedLicensesDataGrid;
            }
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);

            _ReleaseLicensApplicationTypeFees = clsApplicationType.GetApplicationTypeByID(_ReleaseLicenseApplicationTypeID).ApplicationTypeFees;

            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblShowLicenseInfo.Enabled = false;

            _PopulateReleaseApplicationDetails();

            ctrlLicenseCardWithFilter1.LicenseSelected += CtrlLicenseCardWithFilter1_LicenseSelected;
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(object sender, EventArgs e)
        {
            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblLicenseID.Text = (_LicenseID == -1) ? "N\\A" : _LicenseID.ToString();

            lblShowLicensesHistory.Enabled = (_LicenseID != -1);
            lblShowLicenseInfo.Enabled = (_LicenseID != -1);

            _License = clsLicense.GetLicenseByID(_LicenseID);

            if (_LicenseID != -1)
            {
                lblLicenseID.Text = _LicenseID.ToString();

                _CheckIfLicenseNotDetained();
            }
        }

        private void _LoadDetainedLicenseInfo()
        {
            _DetainID = clsDetainedLicense.GetDetainIDByLicenseID(_LicenseID);

            _DetainedLicense = clsDetainedLicense.GetDetainedLicenseByID(_DetainID);
        }

        private void _CheckIfLicenseNotDetained()
        {
            if (!clsDetainedLicense.IsLicenseDetained(_LicenseID))
            {
                clsMessageBoxManager.ShowMessageBox("Selected license is not detained.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }

            btnRelease.Enabled = true;

            _LoadDetainedLicenseInfo();

            _PopulateDetainedLicenseDetails();
        }

        private void _PopulateReleaseApplicationDetails()
        {
            lblDetainID.Text = "N\\A";
            lblDetainedDate.Text = "N\\A";
            lblAppFees.Text = _ReleaseLicensApplicationTypeFees.ToString();
            lblFineFees.Text = "N\\A";
            lblReleaseAppID.Text = "N\\A";
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
            lblTotalFees.Text = "N\\A"; ;
        }

        private decimal _CalculateTotalFees()
        {
            return _DetainedLicense.FineFees + _ReleaseLicensApplicationTypeFees;
        }

        private void _PopulateDetainedLicenseDetails()
        {
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblDetainID.Text = _DetainedLicense.ID.ToString();
            lblDetainedDate.Text = _DetainedLicense.DetainDate.ToString();
            lblTotalFees.Text = _CalculateTotalFees().ToString();
        }

        private void _ReleaseLicense()
        {
            _DetainedLicense.IsReleased= true;
            _DetainedLicense.ReleaseDate = DateTime.Now;
            _DetainedLicense.ReleasedByUserID=clsCurrentUser.CurrentUser.ID;
            _DetainedLicense.ReleaseApplicationID = _ReleaseLicenseApplication.ID;
        }

        private void _LoadReleaseApplicationData()
        {
            byte Completed = 3;
            _ReleaseLicenseApplication = new clsApplication();

            _ReleaseLicenseApplication.ApplicantPersonID = clsLicense.GetPersonIDByLicenseID(_LicenseID);
            _ReleaseLicenseApplication.Date = DateTime.Now;
            _ReleaseLicenseApplication.TypeID = _ReleaseLicenseApplicationTypeID;
            _ReleaseLicenseApplication.Status = Completed;
            _ReleaseLicenseApplication.LastStatusDate = DateTime.Now;
            _ReleaseLicenseApplication.PaidFees = _ReleaseLicensApplicationTypeFees;
            _ReleaseLicenseApplication.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void _SetControlsAfterRelease()
        {
            btnRelease.Enabled = false;
            lblShowLicenseInfo.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (_LicenseID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a License first.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadReleaseApplicationData();

            if (!_ReleaseLicenseApplication.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ReleaseLicense();

            if (!_DetainedLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"License with  ID = {_DetainedLicense.LicenseID} Released Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblReleaseAppID.Text = _ReleaseLicenseApplication.ID.ToString();

            _SetControlsAfterRelease();

            DataAdded?.Invoke();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_License.ID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(_License.DriverID, clsApplication.GetApplicationByID(_License.ApplicationID).ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
