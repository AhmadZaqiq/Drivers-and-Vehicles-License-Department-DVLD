using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Detained_Licenses.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Drivers.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void PeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frmPeople = new frmListPeople();
            frmPeople.ShowDialog();
        }

        private void SignoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCurrentUser.CurrentUser = null;

            clsUtil.CloseFormEffect(this);
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUsersForm = new frmManageUsers();
            ManageUsersForm.ShowDialog();
        }

        private void CurrentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails FormShowUserDetails = new frmShowUserDetails(clsCurrentUser.CurrentUser.UserID);
            FormShowUserDetails.ShowDialog();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUsername FormChangePassword = new frmUpdateUsername(clsCurrentUser.CurrentUser.UserID, true, null);
            FormChangePassword.ShowDialog();
        }

        private void ManageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes FormManageApplicationTypes = new frmManageApplicationTypes();
            FormManageApplicationTypes.ShowDialog();
        }

        private void ManageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes FormManageTestTypes = new frmManageTestTypes();
            FormManageTestTypes.ShowDialog();
        }

        private void LocalLicemseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateLocalDrivingApplication FormAddAndUpdateLocalDrivingApplication = new frmAddAndUpdateLocalDrivingApplication(null);
            FormAddAndUpdateLocalDrivingApplication.ShowDialog();
        }

        private void LocalDrivingLicenceApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications FormListLocalDrivingLicenseApplications=new frmListLocalDrivingLicenseApplications();
            FormListLocalDrivingLicenseApplications.ShowDialog();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers FormListDrivers= new frmListDrivers();
            FormListDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense FormAddNewInternationalDrivingLicenseApplicaiton = new frmIssueInternationalDrivingLicense();
            FormAddNewInternationalDrivingLicenseApplicaiton.ShowDialog();
        }

        private void internationalDrivingLicenceApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalDrivingLicenses FormListInternationalDrivingLicenses = new frmListInternationalDrivingLicenses();
            FormListInternationalDrivingLicenses.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication FormRenewLicenseApplication = new frmRenewLicenseApplication();
            FormRenewLicenseApplication.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedLostLicense FormReplacementForDamagedLostLicense=new frmReplacementForDamagedLostLicense();
            FormReplacementForDamagedLostLicense.ShowDialog();
        }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses FormListDetainedLicenses = new frmListDetainedLicenses();
            FormListDetainedLicenses.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense FormDetainLicense = new frmDetainLicense();
            FormDetainLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense FormReleaseLicense =new frmReleaseLicense();
            FormReleaseLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense FormReleaseLicense = new frmReleaseLicense();
            FormReleaseLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications FormListLocalDrivingLicenseApplications = new frmListLocalDrivingLicenseApplications();
            FormListLocalDrivingLicenseApplications.ShowDialog();
        }


    }
}
