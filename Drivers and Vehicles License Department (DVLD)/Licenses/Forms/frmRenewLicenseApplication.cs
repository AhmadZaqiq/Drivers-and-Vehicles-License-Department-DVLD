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
        private int _RenewLicenseID;

        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.txtLicenseIDFocus();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "N/A";
            lblAppFees.Text = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            lblShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            int DefaultValidityLength = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ClassInfo.Fees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.Notes;

            if (!ctrlLicenseCardWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                clsMessageBoxManager.ShowMessageBox("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ExpirationDate)
                                                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!ctrlLicenseCardWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            clsLicense NewLicense = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsCurrentUser.CurrentUser.ID);

            if (NewLicense == null)
            {
                clsMessageBoxManager.ShowMessageBox("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAppID.Text = NewLicense.ApplicationID.ToString();
            _RenewLicenseID = NewLicense.ID;
            lblRenewedLicenseID.Text = _RenewLicenseID.ToString();

            clsMessageBoxManager.ShowMessageBox("Licensed Renewed Successfully with ID=" + _RenewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
            lblShowLicensesHistory.Enabled = true;
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_RenewLicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
