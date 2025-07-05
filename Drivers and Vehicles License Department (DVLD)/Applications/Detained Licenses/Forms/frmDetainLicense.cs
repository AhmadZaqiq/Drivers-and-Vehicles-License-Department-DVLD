using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application;
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
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;

        private int _SelectedLicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainedDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseInfo.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            if (ctrlLicenseCardWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                clsMessageBoxManager.ShowMessageBox("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            if (!float.TryParse(txtFineFees.Text, out float fineFees))
            {
                clsMessageBoxManager.ShowMessageBox("Please enter a valid fine amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFineFees.Focus();
                return;
            }
            if (_DetainID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = _DetainID.ToString();

            clsMessageBoxManager.ShowMessageBox("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlLicenseCardWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_SelectedLicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtFineFees.Text, out _))
            {
                errorProvider1.SetError(txtFineFees, "");
                return;
            }

            errorProvider1.SetError(txtFineFees, "Please enter a valid decimal value.");
            e.Cancel = true;
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.txtLicenseIDFocus();
        }


    }
}
