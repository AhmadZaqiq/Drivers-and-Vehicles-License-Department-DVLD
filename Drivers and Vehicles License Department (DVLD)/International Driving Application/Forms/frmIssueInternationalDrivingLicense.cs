using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
        private int _LicenseID;

        private clsLicense _License;

        private clsInternationalLicense _InternationalLicense;

        private clsApplication _InternationalApplication;

        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmAddNewInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);

            _PopulateApplicationDetails();

            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            llblShowInternationalLicenseInfo.Enabled= false;

            ctrlLicenseCardWithFilter1.LicenseSelected += CtrlLicenseCardWithFilter1_LicenseSelected;
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(object sender, EventArgs e)
        {
            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblLocalLicenseID.Text = (_LicenseID == -1) ? "N\\A" : _LicenseID.ToString();

            llblShowLicensesHistory.Enabled = (_LicenseID != -1);

            _License = clsLicense.GetLicenseByID(_LicenseID);
        }

        private void _PopulateApplicationDetails()
        {
            const int InternationalLicenseApplicationFees = 6;

            lblILAppID.Text = "N\\A";
            lblApplicationDate.Text = lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = clsApplicationType.GetApplicationTypeByID(InternationalLicenseApplicationFees).ApplicationTypeFees.ToString();
            lblILLicenseID.Text = "N\\A";
            lblLocalLicenseID.Text = "N\\A";
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
        }

        private void _LoadInternationalLicenseInfo()
        {
            _InternationalLicense = new clsInternationalLicense();

            _InternationalLicense.ApplicationID = _InternationalApplication.ApplicationID;
            _InternationalLicense.DriverID = _License.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.IsActive = true;
            _InternationalLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _LoadInternationalApplicationData()
        {
            int InternationalApplicationTypeID = 7;
            byte Completed = 3 ;
            clsApplicationType InternationalApplicationType = clsApplicationType.GetApplicationTypeByID(InternationalApplicationTypeID);
            _InternationalApplication = new clsApplication();

            _InternationalApplication.ApplicantPersonID = clsLicense.GetPersonIDByLicenseID(_LicenseID);
            _InternationalApplication.ApplicationDate = DateTime.Now;
            _InternationalApplication.ApplicationTypeID = InternationalApplicationType.ApplicationTypeID;
            _InternationalApplication.ApplicationStatus = Completed;
            _InternationalApplication.LastStatusDate = DateTime.Now;
            _InternationalApplication.PaidFees = InternationalApplicationType.ApplicationTypeFees;
            _InternationalApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _DisplayIssuedInternationalLicenseInfo()
        {
            lblILAppID.Text = _InternationalLicense.ApplicationID.ToString();
            lblILLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
        }

        private void _SetControlsAfterLicenseIssued()
        {
            btnIssue.Enabled = false;
            llblShowInternationalLicenseInfo.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            const int OrdinaryDrivingLicense = 3;

            if (_LicenseID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a License first.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_License.LicenseClassID != clsLicenseClass.GetLicenseClassByID(OrdinaryDrivingLicense).LicenseClassID)
            {
                clsMessageBoxManager.ShowMessageBox("The selected license is not an ordinary driving license.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsInternationalLicense.IsDriverHaveInternationalLicens(_License.DriverID))
            {
                clsMessageBoxManager.ShowMessageBox("This driver already holds an international driving license.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                llblShowInternationalLicenseInfo.Enabled = true;

                _InternationalLicense=clsInternationalLicense.GetInternationalLicenseByDriverID(_License.DriverID);

                return;
            }

            if (_License.IsActive == false)
            {
                clsMessageBoxManager.ShowMessageBox("The driver's License is deactivated.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_License.ExpirationDate < DateTime.Now)
            {
                clsMessageBoxManager.ShowMessageBox("The driver's license has expired.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadInternationalApplicationData();

            if (!_InternationalApplication.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadInternationalLicenseInfo();

            if (!_InternationalLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _DisplayIssuedInternationalLicenseInfo();

            _SetControlsAfterLicenseIssued();

            clsMessageBoxManager.ShowMessageBox($"International License Issued Successfully with License ID = {_InternationalLicense.InternationalLicenseID}", "Success",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            llblShowInternationalLicenseInfo.Enabled = true;
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(_License.DriverID, clsApplication.GetApplicationByID(_License.ApplicationID).ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverInternationalLicenseInfo FormDriverInternationalLicenseInfo = new frmDriverInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            FormDriverInternationalLicenseInfo.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
