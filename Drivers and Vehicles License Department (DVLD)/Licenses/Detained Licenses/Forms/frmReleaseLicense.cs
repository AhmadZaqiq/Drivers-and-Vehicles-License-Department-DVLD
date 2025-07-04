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
        private int _SelectedLicenseID = -1;

        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;

            ctrlLicenseCardWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseInfo.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            if (!ctrlLicenseCardWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                clsMessageBoxManager.ShowMessageBox("Selected License is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppFees.Text = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).Fees.ToString();
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;

            lblDetainID.Text = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DetainedInfo.ID.ToString();
            lblLicenseID.Text = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ID.ToString();

            lblDetainDate.Text = clsFormat.DateToShort(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrlLicenseCardWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsCurrentUser.CurrentUser.ID, ref ApplicationID);

            lblReleaseAppID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                clsMessageBoxManager.ShowMessageBox("Failed to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_SelectedLicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void frmReleaseLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.txtLicenseIDFocus();
        }


    }
}
