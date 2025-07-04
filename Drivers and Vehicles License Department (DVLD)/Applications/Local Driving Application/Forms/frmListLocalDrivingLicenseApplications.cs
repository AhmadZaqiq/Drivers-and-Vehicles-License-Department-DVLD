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
using static DVLD_Business.clsTestType;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications();

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshLocalDrivingApplicationsDataGrid();

            _FillLocalApplicationsComboBox();

            clsUtil.MakeRoundedCorners(this, 30);

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
            _dtAllLocalDrivingLicenseApplications= clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications();

            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            _UpdateLocalDrivingApplicationsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshLocalDrivingApplicationsDataGrid();
                return;
            }

            DataView dv = new DataView(_dtAllLocalDrivingLicenseApplications);
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
            frmAddAndUpdateLocalDrivingApplication FormAddAndUpdateLocalDrivingApplication = new frmAddAndUpdateLocalDrivingApplication();
            FormAddAndUpdateLocalDrivingApplication.ShowDialog();

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmShowLocalApplicationDetails FormShowLocalApplicationDetails = new frmShowLocalApplicationDetails(LocalDrivingLicenseApplicationID);
            FormShowLocalApplicationDetails.ShowDialog();

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddAndUpdateLocalDrivingApplication FormAddAndUpdateLocalDrivingApplication = new frmAddAndUpdateLocalDrivingApplication(LocalDrivingLicenseApplicationID);
            FormAddAndUpdateLocalDrivingApplication.ShowDialog();

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are You Sure you want to delete this Local Application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);

            if (!LocalDrivingLicenseApplication.Delete())
            {
                clsMessageBoxManager.ShowMessageBox("Local Application was not deleted because it is linked to other transactions in the system...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Local Application deleted successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void CancelApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to cancel this application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);

            if (!LocalDrivingLicenseApplication.Cancel())
            {
                clsMessageBoxManager.ShowMessageBox("Failed to cancel the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Person cancelled successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void _ScheduleTest(clsTestType.enTestType TestType)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmTestAppointments FormTestAppointments = new frmTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            FormTestAppointments.ShowDialog();

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void ScheduleVisionTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void ScheduleWrittenTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void ScheduleStreetTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void _UpdateTestScheduleAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);

            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            ScheduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                                                     (Status == clsApplication.enApplicationStatus.New.ToString());

            if (ScheduleTestsToolStripMenuItem.Enabled)
            {
                ScheduleVisionTestToolStripMenuItem1.Enabled = !PassedVisionTest;

                ScheduleWrittenTestToolStripMenuItem1.Enabled = PassedVisionTest && !PassedWrittenTest;

                ScheduleStreetTestToolStripMenuItem1.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }
        }

        private void _UpdateIssueDrivingLicenseAvailability(int PassedTestsCount)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            IssueDrivingLicenseToolStripMenuItem1.Enabled = (PassedTestsCount == 3) && (Status == clsApplication.enApplicationStatus.New.ToString());
        }

        private void _UpdateDeleteLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            DeleteToolStripMenuItem1.Enabled = (Status != clsApplication.enApplicationStatus.Completed.ToString());
        }

        private void _UpdateCancelLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            CancelApplicationToolStripMenuItem1.Enabled = (Status == clsApplication.enApplicationStatus.New.ToString());
        }

        private void _UpdateShowLicenseAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            ShowLicenseStripToolMenuItem1.Enabled = (Status == clsApplication.enApplicationStatus.Completed.ToString());
        }

        private void _UpdateEditLocalApplicationAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            EditToolStripMenuItem1.Enabled = (Status != clsApplication.enApplicationStatus.Completed.ToString());
        }

        private void _UpdateShowLicenseHistoryAvailability()
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            string Status = SelectedRow.Cells["ApplicationStatus"].Value.ToString();

            ShowPersonlicenseHistoryStripMenuItem1.Enabled = (Status == clsApplication.enApplicationStatus.Completed.ToString());
        }

        private void cmLicenseApplicationSettings_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            int PassedTestsCount = Convert.ToInt32(SelectedRow.Cells["PassedTests"].Value);

            _UpdateTestScheduleAvailability();

            _UpdateIssueDrivingLicenseAvailability(PassedTestsCount);

            _UpdateDeleteLocalApplicationAvailability();

            _UpdateCancelLocalApplicationAvailability();

            _UpdateShowLicenseAvailability();

            _UpdateEditLocalApplicationAvailability();

            _UpdateShowLicenseHistoryAvailability();
        }

        private void IssueDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmIssueDrivingLicense FormIssueDrivingLicense = new frmIssueDrivingLicense(LocalDrivingLicenseApplicationID);
            FormIssueDrivingLicense.ShowDialog();

            RefreshLocalDrivingApplicationsDataGrid();
        }

        private void ShowLicenseStripToolMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if(LicenseID ==-1)
            {
                clsMessageBoxManager.ShowMessageBox("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void ShowPersonlicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(LocalDrivingLicenseApplication.ApplicantPersonID);
            FormLicensesHistory.ShowDialog();
        }

        private void dgvLocalDrivingLicenseApplications_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvLocalDrivingLicenseApplications_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


    }
}
