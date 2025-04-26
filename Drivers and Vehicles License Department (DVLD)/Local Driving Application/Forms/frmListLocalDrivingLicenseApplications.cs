using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application.frmAddAndUpdateLocalDrivingApplication;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private enum enTestType { Vision = 0, Written = 1, Street = 2, Finish = 3 };

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshLocalDrivingApplicationsDataGrid();

            _FillLocalApplicationsComboBox();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _FillLocalApplicationsComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("LocalDrivingLicenseApplications");
            cbFilter.Items.Add("ClassName");
            cbFilter.Items.Add("FullName");
            cbFilter.Items.Add("ApplicationStatus");

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateLocalDrivingApplicationsCount()
        {
            lblRecordsCount.Text = (dgvLocalDrivingLicenseApplications.RowCount).ToString();
        }

        public void RefreshLocalDrivingApplicationsDataGrid()
        {
            dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications();

            _UpdateLocalDrivingApplicationsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshLocalDrivingApplicationsDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvLocalDrivingLicenseApplications.DataSource = dv;

            _UpdateLocalDrivingApplicationsCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (!(FilterColumn == "LocalDrivingLicenseApplicationID"))
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "00000000000000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void btnAddNewLocalApplication_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateLocalDrivingApplication FormAddAndUpdateLocalDrivingApplication = new frmAddAndUpdateLocalDrivingApplication(this);
            FormAddAndUpdateLocalDrivingApplication.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmShowLocalApplicationDetails FormShowLocalApplicationDetails = new frmShowLocalApplicationDetails(LocalApplicationID);
            FormShowLocalApplicationDetails.ShowDialog();
        }

        private void CancelApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to cancel this application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            if (!clsLocalDrivingLicenseApplication.CancelLocalDrivingLicenseApplication(LocalApplicationID))
            {
                clsMessageBoxManager.ShowMessageBox("Failed to cancel the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Person cancelled successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void dgvLocalDrivingLicenseApplications_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvLocalDrivingLicenseApplications_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ScheduleVisionTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmTestAppointments FormTestAppointments = new frmTestAppointments(LocalApplicationID, (int)enTestType.Vision + 1, this);
            FormTestAppointments.ShowDialog();
        }

        private void ScheduleWrittenTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmTestAppointments FormTestAppointments = new frmTestAppointments(LocalApplicationID, (int)enTestType.Written + 1, this);
            FormTestAppointments.ShowDialog();
        }

        private void ScheduleStreetTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmTestAppointments FormTestAppointments = new frmTestAppointments(LocalApplicationID, (int)enTestType.Street + 1, this);
            FormTestAppointments.ShowDialog();
        }

        private void _UpdateTestScheduleAvailability(int PassedTestsCount)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString(); 

            enTestType TestType = (enTestType)PassedTestsCount;

            if (TestType == enTestType.Finish)
            {
                ScheduleTestsToolStripMenuItem.Enabled = false;
                return;
            }

            if (Status == "Cancelled")
            {
                ScheduleTestsToolStripMenuItem.Enabled = false;
                return;
            }

            ScheduleTestsToolStripMenuItem.Enabled = true;
            ScheduleVisionTestToolStripMenuItem1.Enabled = (TestType == enTestType.Vision);
            ScheduleWrittenTestToolStripMenuItem1.Enabled = (TestType == enTestType.Written);
            ScheduleStreetTestToolStripMenuItem1.Enabled = (TestType == enTestType.Street);
        }

        private void _UpdateIssueDrivingLicenseAvailability(int PassedTestsCount)
        {
            enTestType TestType = (enTestType)PassedTestsCount;

            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            IssueDrivingLicenseToolStripMenuItem1.Enabled = (TestType == enTestType.Finish) && (Status == "New");
        }

        private void _UpdateDeleteLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            DeleteToolStripMenuItem1.Enabled = (Status != "Completed");
        }

        private void _UpdateCancelLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            CancelApplicationToolStripMenuItem1.Enabled = (Status == "New");
        }

        private void _UpdateShowLicenseAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            ShowLicenseStripToolMenuItem1.Enabled = (Status == "Completed");
        }

        private void _UpdateEditLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            EditToolStripMenuItem1.Enabled = (Status != "Completed");
        }

        private void _UpdateShowLicenseHistoryAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            ShowPersonlicenseHistoryStripMenuItem1.Enabled = (Status == "Completed");
        }

        private void cmLicenseApplicationSettings_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int PassedTestsCount = Convert.ToInt32(SelectedRow.Cells["PassedTests"].Value);

            _UpdateTestScheduleAvailability(PassedTestsCount);

            _UpdateIssueDrivingLicenseAvailability(PassedTestsCount);

            _UpdateDeleteLocalApplicationAvailability();

            _UpdateCancelLocalApplicationAvailability();

            _UpdateShowLicenseAvailability();

            _UpdateEditLocalApplicationAvailability();

            _UpdateShowLicenseHistoryAvailability();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this Local Application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int LocalDrivingLicenseApplicationID = Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            if (!clsLocalDrivingLicenseApplication.DeleteLocalDrivingApplication(LocalDrivingLicenseApplicationID))
            {
                clsMessageBoxManager.ShowMessageBox("Local Application was not deleted because it is linked to other transactions in the system...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Local Application deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void IssueDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalDrivingLicenseApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmIssueDrivingLicense FormIssueDrivingLicense = new frmIssueDrivingLicense(LocalDrivingLicenseApplicationID, this);
            FormIssueDrivingLicense.ShowDialog();
        }

        private void ShowLicenseStripToolMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            int ApplicationID = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalApplicationID).ApplicationID;

            int LicenseID = clsLicense.GetLicenseIDByApplicationID(ApplicationID);

            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void ShowPersonlicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            int ApplicationID = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalApplicationID).ApplicationID;

            int LicenseID = clsLicense.GetLicenseIDByApplicationID(ApplicationID);

            int DriverID = clsLicense.GetLicenseByID(LicenseID).DriverID;

            int PersonID = clsApplication.GetApplicationByID(ApplicationID).ApplicantPersonID;

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(DriverID, PersonID);
            FormLicensesHistory.ShowDialog();
        }


    }
}
