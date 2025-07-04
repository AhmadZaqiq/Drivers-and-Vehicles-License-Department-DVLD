using Drivers_and_Vehicles_License_Department__DVLD_.Applications.Controls;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmIssueDrivingLicense : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                clsMessageBoxManager.ShowMessageBox("No Application with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                clsMessageBoxManager.ShowMessageBox("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            if (LicenseID != -1)
            {
                clsMessageBoxManager.ShowMessageBox("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlLocalDrivingApplicationCard1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNotes.Text.Trim(), clsCurrentUser.CurrentUser.ID);

            if (LicenseID == -1)
            {

                clsMessageBoxManager.ShowMessageBox("License Was not Issued !", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"License Issued Successfully with License ID = {LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
