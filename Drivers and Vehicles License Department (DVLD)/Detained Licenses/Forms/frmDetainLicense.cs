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
        public event Action DataAdded;

        private int _LicenseID;

        private clsLicense _License;

        private clsDetainedLicense _DetainedLicense;

        public frmDetainLicense(frmListDetainedLicenses FormListDetainedLicenses=null)
        {
            InitializeComponent();

            if(FormListDetainedLicenses !=null)
            {
                this.DataAdded += FormListDetainedLicenses.RefreshDetainedLicensesDataGrid;
            }
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);

            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblShowLicenseInfo.Enabled = false;

            ctrlLicenseCardWithFilter1.LicenseSelected += CtrlLicenseCardWithFilter1_LicenseSelected;
        }

        private void CtrlLicenseCardWithFilter1_LicenseSelected(object sender, EventArgs e)
        {
            _LicenseID = ctrlLicenseCardWithFilter1.LicenseID;

            lblLicenseID.Text = (_LicenseID == -1) ? "N\\A" : _LicenseID.ToString();

            llblShowLicensesHistory.Enabled = (_LicenseID != -1);
            lblShowLicenseInfo.Enabled = (_LicenseID != -1);

            _CheckIfLicenseDetained();

            _License = clsLicense.GetLicenseByID(_LicenseID);

            if (_LicenseID != -1)
            {
                lblLicenseID.Text = _LicenseID.ToString();
            }
        }

        private void _CheckIfLicenseDetained()
        {
            if (clsDetainedLicense.IsLicenseDetained(_LicenseID))
            {
                clsMessageBoxManager.ShowMessageBox("The license is currently detained.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            btnDetain.Enabled = true;
        }

        private void _LoadDetainedLicenseInfo()
        {
            _DetainedLicense = new clsDetainedLicense();

            _DetainedLicense.LicenseID= _LicenseID;
            _DetainedLicense.DetainDate = DateTime.Now;
            _DetainedLicense.FineFees = Decimal.Parse(txtFineFees.Text);
            _DetainedLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _DetainedLicense.IsReleased = false;
            _DetainedLicense.ReleaseDate = DateTime.MinValue;
            _DetainedLicense.ReleasedByUserID = -1;
            _DetainedLicense.ReleaseApplicationID = -1;

        }

        private void _PopulateDetainInfo()
        {
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainedDate.Text = _DetainedLicense.DetainDate.ToString();
        }

        private void _SetControlsAfterDetain()
        {
            btnDetain.Enabled = false;
            lblShowLicenseInfo.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (_LicenseID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a License first.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFineFees.Text, out _))
            {
                clsMessageBoxManager.ShowMessageBox("Please enter a valid value for the fine fees.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDetainedLicenseInfo();

            if (!_DetainedLicense.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"License Detained Successfully with  ID = {_DetainedLicense.LicenseID}", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            _PopulateDetainInfo();

            _SetControlsAfterDetain();

            DataAdded?.Invoke();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(_License.DriverID, clsApplication.GetApplicationByID(_License.ApplicationID).ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_LicenseID);
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


    }
}
