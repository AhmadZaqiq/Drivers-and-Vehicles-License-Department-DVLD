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
        private int _InternationalLicenseID = -1;

        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmAddNewInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblFees.Text = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            llblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ClassID != 3)
            {
                clsMessageBoxManager.ShowMessageBox("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationalLicenseID != -1)
            {
                clsMessageBoxManager.ShowMessageBox("Person already have an active international license with ID = " + ActiveInternationalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llblShowInternationalLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternationalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicantPersonID = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.Date = DateTime.Now;
            InternationalLicense.Status = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;

            InternationalLicense.DriverID = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsCurrentUser.CurrentUser.ID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblILAppID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.ID;
            lblILLicenseID.Text = InternationalLicense.ID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.ID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
            llblShowLicensesHistory.Enabled = true;
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverInternationalLicenseInfo FormDriverInternationalLicenseInfo = new frmDriverInternationalLicenseInfo(_InternationalLicenseID);
            FormDriverInternationalLicenseInfo.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}