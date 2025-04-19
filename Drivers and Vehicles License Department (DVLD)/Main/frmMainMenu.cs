using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Drivers.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms;
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
            frmAddNewInternationalDrivingLicenseApplicaiton FormAddNewInternationalDrivingLicenseApplicaiton = new frmAddNewInternationalDrivingLicenseApplicaiton();
            FormAddNewInternationalDrivingLicenseApplicaiton.ShowDialog();
        }


    }
}
