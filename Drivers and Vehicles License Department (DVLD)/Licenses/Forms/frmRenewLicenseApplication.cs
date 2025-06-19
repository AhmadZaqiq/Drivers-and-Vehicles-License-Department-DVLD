using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmRenewLicenseApplication : Form
    {
        private int _OldLicenseID;

        private clsLicense _OldLicense;

        private clsLicense _RenewedLicense;

        private clsApplication _RenewApplication;

        private decimal _RenewApplicationTypeFees;

        private const int _RenewApplicationTypeID = 2;

        private enum enIssueReason { FirstTime = 1, Renew = 2, Damaged = 3, Lost = 4 };

        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);

            _RenewApplicationTypeFees = clsApplicationType.GetApplicationTypeByID(_RenewApplicationTypeID).ApplicationTypeFees;

            _OldLicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblShowNewLicenseInfo.Enabled = false;

            _PopulateRenewApplicationDetails();

            ctrlLicenseCardWithFilter1.LicenseSelected += CtrlLicenseCardWithFilter1_LicenseSelected;
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(object sender, EventArgs e)
        {
            _OldLicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblOldLicenseID.Text = (_OldLicenseID == -1) ? "N\\A" : _OldLicenseID.ToString();

            lblShowLicensesHistory.Enabled = (_OldLicenseID != -1);

            _OldLicense = clsLicense.GetLicenseByID(_OldLicenseID);

            if (_OldLicenseID != -1)
            {
                _PopulateOldLicenseDetails();

                _CheckIfLicenseExpired();
            }
        }

        private void _CheckIfLicenseExpired()
        {
            if (_OldLicense.ExpirationDate > DateTime.Now)
            {
                btnIssue.Enabled = false;
                clsMessageBoxManager.ShowMessageBox($"Selected license is not yet expired, it will expire on: {_OldLicense.ExpirationDate:dd/MM/yyyy}", "not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnIssue.Enabled = true;
        }

        private decimal _CalculateTotalFees()
        {
            return _OldLicense.PaidFees + _RenewApplicationTypeFees;
        }

        private void _PopulateOldLicenseDetails()
        {
            lblLicenseFees.Text = _OldLicense.PaidFees.ToString();
            lblOldLicenseID.Text = _OldLicenseID.ToString();
            lblExpirationDate.Text = _OldLicense.ExpirationDate.ToString();
            lblTotalFees.Text = _CalculateTotalFees().ToString();
        }

        private void _PopulateRenewApplicationDetails()
        {
            lblRLAppID.Text = "N\\A";
            lblApplicationDate.Text = lblIssueDate.Text = DateTime.Now.ToString();
            lblAppFees.Text = _RenewApplicationTypeFees.ToString();
            lblLicenseFees.Text = "N\\A";
            lblRenewedLicenseID.Text = "N\\A";
            lblOldLicenseID.Text = "N\\A";
            lblExpirationDate.Text = "N\\A";
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
            lblTotalFees.Text = "N\\A"; ;
        }

        private void _LoadRenewLicenseInfo()
        {
            _RenewedLicense = new clsLicense();

            int LicenseClassID = _OldLicense.LicenseClassID;

            _RenewedLicense.ApplicationID = _RenewApplication.ID;
            _RenewedLicense.DriverID = _OldLicense.DriverID;
            _RenewedLicense.LicenseClassID = LicenseClassID;
            _RenewedLicense.IssueDate = DateTime.Now;
            _RenewedLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseClassByID(LicenseClassID).DefaultValidityLength);
            _RenewedLicense.Notes = txtNotes.Text;
            _RenewedLicense.PaidFees = clsLicenseClass.GetLicenseClassByID(LicenseClassID).Fees;
            _RenewedLicense.IsActive = true;
            _RenewedLicense.IssueReasonCode = (int)enIssueReason.Renew;
            _RenewedLicense.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void _LoadRenewApplicationData()
        {
            byte Completed = 3;
            _RenewApplication = new clsApplication();

            _RenewApplication.ApplicantPersonID = clsLicense.GetPersonIDByLicenseID(_OldLicenseID);
            _RenewApplication.Date = DateTime.Now;
            _RenewApplication.TypeID = _RenewApplicationTypeID;
            _RenewApplication.Status = Completed;
            _RenewApplication.LastStatusDate = DateTime.Now;
            _RenewApplication.PaidFees = _RenewApplicationTypeFees;
            _RenewApplication.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void _PopulateRenewedLicenseInfo()
        {
            lblRenewedLicenseID.Text = _RenewedLicense.ID.ToString();
            lblRLAppID.Text = _RenewedLicense.ApplicationID.ToString();
        }

        private void _SetControlsAfterRenew()
        {
            btnIssue.Enabled = false;
            lblShowNewLicenseInfo.Enabled = true;
        }

        private void _DisableOldLicense()
        {
            _OldLicense.IsActive = false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_OldLicenseID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a License first.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadRenewApplicationData();

            if (!_RenewApplication.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadRenewLicenseInfo();

            if (!_RenewedLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"Renew License Issued Successfully with License ID = {_RenewedLicense.ID}", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            _PopulateRenewedLicenseInfo();

            _SetControlsAfterRenew();

            _DisableOldLicense();

            if (!_OldLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblShowNewLicenseInfo.Enabled = true;
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_RenewedLicense.ID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(_OldLicense.DriverID, clsApplication.GetApplicationByID(_OldLicense.ApplicationID).ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
