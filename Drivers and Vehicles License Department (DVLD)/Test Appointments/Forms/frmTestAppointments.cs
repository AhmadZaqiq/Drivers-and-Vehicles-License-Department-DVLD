using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using Drivers_and_Vehicles_License_Department__DVLD_.Tests.Forms;
using DVLD_Business;
using SiticoneNetFrameworkUI.Helpers.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms
{
    public partial class frmTestAppointments : Form
    {
        public event Action DataAdded;

        private enum enTestType { Vision = 1, Written = 2, Street = 3 };

        private enTestType _TestType;

        private int _LocalDrivingApplicationID = -1;

        public frmTestAppointments(int LocalDrivingApplicationID, int TestTypeNumber, frmListLocalDrivingLicenseApplications FormListLocalDrivingLicenseApplications)
        {
            InitializeComponent();

            this._LocalDrivingApplicationID = LocalDrivingApplicationID;

            _TestType = (enTestType)TestTypeNumber;

            if (FormListLocalDrivingLicenseApplications != null)
            {
                this.DataAdded += FormListLocalDrivingLicenseApplications.RefreshLocalDrivingApplicationsDataGrid;
            }
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            FillLocalDrivingApplicationCard();

            _RefreshTestAppointmentsDataGrid();

            _UpdateTestTypeUI();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        public void FillLocalDrivingApplicationCard()
        {
            ctrlLocalDrivingApplicationCard1.LocalDrivingApplicationID = _LocalDrivingApplicationID;
        }

        private void _UpdateTestTypeUI()
        {
            switch (_TestType)
            {
                case enTestType.Vision:

                    pbTestType.BackgroundImage = Resources.Eye_Test_Pic;
                    lblTestType.Text = "Vision Test Appointment";

                    break;

                case enTestType.Written:

                    pbTestType.BackgroundImage = Resources.Writen_Test_pic;
                    lblTestType.Text = "Written Test Appointment";

                    break;

                case enTestType.Street:

                    pbTestType.BackgroundImage = Resources.Street_Test_Pic;
                    lblTestType.Text = "Street Test Appointment";

                    break;
            }
        }

        private void _UpdateTestAppointmentsCount()
        {
            lblRecordsCount.Text = (dgvTestAppointments.RowCount).ToString();
        }

        public void _RefreshTestAppointmentsDataGrid()
        {
            dgvTestAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsForLocalApp(_LocalDrivingApplicationID, (int)_TestType);

            _UpdateTestAppointmentsCount();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            DataAdded?.Invoke();

            clsUtil.CloseFormEffect(this);
        }

        private void _OpenScheduleTestForm(bool IsRetakeTest, int TestAppointmentID = -1)
        {
            frmScheduleTest FormScheduleTest = new frmScheduleTest(IsRetakeTest, TestAppointmentID, _LocalDrivingApplicationID, (int)_TestType, this);
            FormScheduleTest.ShowDialog();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingApplicationID).LicenseClassID;

            if (clsTestAppointment.IsAppointmentScheduledForPerson(_LocalDrivingApplicationID, LicenseClassID))
            {
                clsMessageBoxManager.ShowMessageBox("The person already has an active appointment for this test. You cannot add a new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApplication.GetTestsCountForLocalApplication(_LocalDrivingApplicationID,
                                                  LicenseClassID, true) == (int)_TestType)
            {
                clsMessageBoxManager.ShowMessageBox("This person already passed this test before, you can only retake faild tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointment.IsRetakeTestAppointmentExists(_LocalDrivingApplicationID, LicenseClassID, (int)_TestType))
            {
                _OpenScheduleTestForm(true, clsTestAppointment.GetTestAppointmentIDByLocalApplicationID(_LocalDrivingApplicationID, LicenseClassID));
                return;
            }

            _OpenScheduleTestForm(false);
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestAppointments.SelectedRows[0];

            int TestAppointmentID = Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value);

            frmScheduleTest FormScheduleTest = new frmScheduleTest(false, TestAppointmentID, _LocalDrivingApplicationID, (int)_TestType, this);
            FormScheduleTest.ShowDialog();
        }

        private void TakeTestStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestAppointments.SelectedRows[0];

            int TestAppointmentID = Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value);

            frmTakeTest FormTakeTest = new frmTakeTest(TestAppointmentID, _LocalDrivingApplicationID, (int)_TestType, this);
            FormTakeTest.ShowDialog();
        }

        private void _UpdateTakeTestAvailability(int TestAppointmentID)
        {
            TakeTestStripMenuItem1.Enabled = !clsTestAppointment.GetTestAppointmentByID(TestAppointmentID).IsLocked;
        }

        private void cmTestAppointmentSettings_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestAppointments.SelectedRows[0];

            int TestAppointmentID = Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value);

            _UpdateTakeTestAvailability(TestAppointmentID);
        }


    }
}
