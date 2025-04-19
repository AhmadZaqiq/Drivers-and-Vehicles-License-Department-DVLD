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
        public event Action DataAdded;

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLicense _License;

        private clsDriver _Driver;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsApplication _Application;

        public frmIssueDrivingLicense(int LocalDrivingApplicationID, frmListLocalDrivingLicenseApplications FormListLocalDrivingLicenseApplications)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingApplicationID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingApplicationID);

            _Application = clsApplication.GetApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);

            if (FormListLocalDrivingLicenseApplications != null)
            {
                this.DataAdded += FormListLocalDrivingLicenseApplications.RefreshLocalDrivingApplicationsDataGrid;
            }
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingApplicationCard1.LocalDrivingApplicationID = _LocalDrivingLicenseApplicationID;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _LoadDriverInfo()
        {
            int PersonID = _Application.ApplicantPersonID;

            if (!clsDriver.IsDriverExists(PersonID))
            {
                _Driver = new clsDriver();

                _Driver.PersonID = PersonID;
                _Driver.CreatedByUserID = _Application.CreatedByUserID;
                _Driver.CreatedDate = DateTime.Now;

                if (!_Driver.Save())
                {
                    clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return;
            }

            _Driver = clsDriver.GetDriverByID(clsDriver.GetDriverIDByPersonID(PersonID));
        }

        private void _LoadLicenseInfo()
        {
            const int FirstTime = 1;

            _License = new clsLicense();

            int LicenseClassID = _LocalDrivingLicenseApplication.LicenseClassID;

            _License.ApplicationID = _LocalDrivingLicenseApplication.ApplicationID;
            _License.DriverID = _Driver.DriverID;
            _License.LicenseClassID = LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseClassByID(LicenseClassID).DefaultValidityLength);
            _License.Notes = txtNotes.Text;
            _License.PaidFees = clsLicenseClass.GetLicenseClassByID(LicenseClassID).ClassFees;
            _License.IsActive = true;
            _License.IssueReason = FirstTime;
            _License.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _UpdateApplicationStatus()
        {
            const int Completed = 3;

            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationStatus = Completed;

            if (!_Application.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _LoadDriverInfo();

            _LoadLicenseInfo();

            if (!_License.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox($"License Issued Successfully with License ID = {_License.LicenseID}", "Success",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            _UpdateApplicationStatus();

            DataAdded?.Invoke();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

    }
}
