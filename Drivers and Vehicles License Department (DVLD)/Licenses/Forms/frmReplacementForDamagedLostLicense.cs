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
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmReplacementForDamagedLostLicense : Form
    {
        private int _OldLicenseID;

        private clsLicense _OldLicense;

        private clsLicense _ReplacementLicense;

        private clsApplication _ReplacementApplication;

        private decimal _ReplacementLostApplicationFees;

        private decimal _ReplacementDamageApplicationFees;

        private bool IsDamagedApp;

        private enum enIssueReason { FirstTime = 1, Renew = 2, Damaged = 3, Lost = 4 };

        private enum enApplicationType { LostApplication = 3, DamageApplication = 4 };

        public frmReplacementForDamagedLostLicense()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamagedLostLicense_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);

            rbDamagedLicense.Checked = true;

            _ReplacementLostApplicationFees = clsApplicationType.GetApplicationTypeByID((int)enApplicationType.LostApplication).ApplicationTypeFees;

            _ReplacementDamageApplicationFees = clsApplicationType.GetApplicationTypeByID((int)enApplicationType.DamageApplication).ApplicationTypeFees;

            _OldLicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            llblShowNewLicenseInfo.Enabled = false;

            _PopulateApplicationDetails();

            ctrlLicenseCardWithFilter1.LicenseSelected += CtrlLicenseCardWithFilter1_LicenseSelected;
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(object sender, EventArgs e)
        {
            _OldLicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblOldLicenseID.Text = (_OldLicenseID == -1) ? "N\\A" : _OldLicenseID.ToString();

            llblShowLicensesHistory.Enabled = (_OldLicenseID != -1);

            _OldLicense = clsLicense.GetLicenseByID(_OldLicenseID);

            if (_OldLicenseID != -1)
            {
                _PopulateOldLicenseDetails();

                _CheckIfLicenseActive();
            }

        }

        private void _UpdateApplicationFees()
        {
            if (rbDamagedLicense.Checked)
            {
                lblAppFees.Text = _ReplacementDamageApplicationFees.ToString();
                IsDamagedApp = true;
            }

            else if (rbLostLicense.Checked)
            {
                lblAppFees.Text = _ReplacementLostApplicationFees.ToString();
                IsDamagedApp = false;
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateApplicationFees();
        }

        private void _CheckIfLicenseActive()
        {
            if (!_OldLicense.IsActive)
            {
                btnIssue.Enabled = false;
                clsMessageBoxManager.ShowMessageBox($"Selected license is not Active, Please choose an active license", "not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnIssue.Enabled = true;
        }

        private void _PopulateOldLicenseDetails()
        {
            lblOldLicenseID.Text = _OldLicenseID.ToString();
        }

        private void _PopulateApplicationDetails()
        {

            lblRLAppID.Text = "N\\A";
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblAppFees.Text = _ReplacementDamageApplicationFees.ToString();
            lblReplacementLicenseID.Text = "N\\A";
            lblOldLicenseID.Text = "N\\A";
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
        }

        private void _LoadReplacementLicenseInfo()
        {
            _ReplacementLicense = new clsLicense();

            int LicenseClassID = _OldLicense.LicenseClassID;

            _ReplacementLicense.ApplicationID = _ReplacementApplication.ID;
            _ReplacementLicense.DriverID = _OldLicense.DriverID;
            _ReplacementLicense.LicenseClassID = LicenseClassID;
            _ReplacementLicense.IssueDate = DateTime.Now;
            _ReplacementLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseClassByID(LicenseClassID).DefaultValidityLength);
            _ReplacementLicense.PaidFees = clsLicenseClass.GetLicenseClassByID(LicenseClassID).Fees;
            _ReplacementLicense.IsActive = true;
            _ReplacementLicense.IssueReasonCode = IsDamagedApp ? (byte)enIssueReason.Damaged : (byte)enIssueReason.Lost;
            _ReplacementLicense.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void _LoadReplacementApplicationData()
        {
            byte Completed = 3;
            _ReplacementApplication = new clsApplication();

            _ReplacementApplication.ApplicantPersonID = clsLicense.GetPersonIDByLicenseID(_OldLicenseID);
            _ReplacementApplication.Date = DateTime.Now;
            _ReplacementApplication.TypeID = IsDamagedApp ? (int)enApplicationType.DamageApplication : (int)enApplicationType.LostApplication;
            _ReplacementApplication.Status = Completed;
            _ReplacementApplication.LastStatusDate = DateTime.Now;
            _ReplacementApplication.PaidFees = IsDamagedApp ? _ReplacementDamageApplicationFees : _ReplacementLostApplicationFees;
            _ReplacementApplication.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void _PopulateReplacementLicenseInfo()
        {
            lblReplacementLicenseID.Text = _ReplacementLicense.ID.ToString();
            lblRLAppID.Text = _ReplacementLicense.ApplicationID.ToString();
        }

        private void _SetControlsAfterReplacement()
        {
            btnIssue.Enabled = false;
            llblShowNewLicenseInfo.Enabled = true;
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

            _LoadReplacementApplicationData();

            if (!_ReplacementApplication.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadReplacementLicenseInfo();

            if (!_ReplacementLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"Replacement License Issued Successfully with License ID = {_ReplacementLicense.ID}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            _PopulateReplacementLicenseInfo();

            _SetControlsAfterReplacement();

            _DisableOldLicense();

            if (!_OldLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            llblShowNewLicenseInfo.Enabled = true;
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(_OldLicense.DriverID, clsApplication.GetApplicationByID(_OldLicense.ApplicationID).ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_ReplacementLicense.ID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
