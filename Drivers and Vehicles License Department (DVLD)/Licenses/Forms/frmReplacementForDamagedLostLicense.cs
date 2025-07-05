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
using static DVLD_Business.clsLicense;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmReplacementForDamagedLostLicense : Form
    {
        private int _NewLicenseID = -1;

        public frmReplacementForDamagedLostLicense()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamagedLostLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;

            rbDamagedLicense.Checked = true;

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private int _GetApplicationTypeID()
        {
            return rbDamagedLicense.Checked ? (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense : (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            return rbDamagedLicense.Checked ? enIssueReason.DamagedReplacement : enIssueReason.LostReplacement;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {

            if (rbDamagedLicense.Checked)
            {
                lblTitle.Text = "Replacement for Damaged License";
            }

            else
            {
                lblTitle.Text = "Replacement for Lost License";
            }

            this.Text = lblTitle.Text;
            lblAppFees.Text = clsApplicationType.GetApplicationTypeByID(_GetApplicationTypeID()).Fees.ToString();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            clsLicense NewLicense = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsCurrentUser.CurrentUser.ID);

            if (NewLicense == null)
            {
                clsMessageBoxManager.ShowMessageBox("Failed to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.ID;

            lblReplacementLicenseID.Text = _NewLicenseID.ToString();

            btnIssue.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
            llblShowNewLicenseInfo.Enabled = true;

            clsMessageBoxManager.ShowMessageBox("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_NewLicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void frmReplacementForDamagedLostLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.txtLicenseIDFocus();
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrlLicenseCardWithFilter1.SelectedLicenseInfo.IsActive)
            {
                clsMessageBoxManager.ShowMessageBox("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }


    }
}
