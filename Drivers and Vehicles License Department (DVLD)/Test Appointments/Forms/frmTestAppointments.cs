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
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        private int _LocalDrivingLicenseApplicationID;

        private DataTable _dtLicenseTestAppointments;

        public frmTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _TestType = TestType;
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingApplicationCard1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            _RefreshTestAppointmentsDataGrid();

            _UpdateTestTypeUI();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        public void _RefreshTestAppointmentsDataGrid()
        {
            _dtLicenseTestAppointments = clsTestAppointment.GetAllTestAppointmentsForLocalApp(_LocalDrivingLicenseApplicationID, _TestType);

            dgvTestAppointments.DataSource = _dtLicenseTestAppointments;

            _UpdateTestAppointmentsCount();
        }

        private void _UpdateTestTypeUI()
        {
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:

                    pbTestType.BackgroundImage = Resources.Eye_Test_Pic;
                    lblTestType.Text = "Vision Test Appointment";

                    break;

                case clsTestType.enTestType.WrittenTest:

                    pbTestType.BackgroundImage = Resources.Writen_Test_pic;
                    lblTestType.Text = "Written Test Appointment";

                    break;

                case clsTestType.enTestType.StreetTest:

                    pbTestType.BackgroundImage = Resources.Street_Test_Pic;
                    lblTestType.Text = "Street Test Appointment";

                    break;
            }
        }

        private void _UpdateTestAppointmentsCount()
        {
            lblRecordsCount.Text = (dgvTestAppointments.RowCount).ToString();
        }

        private void _OpenScheduleTestForm(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            frmScheduleTest FormScheduleTest = new frmScheduleTest(LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            FormScheduleTest.ShowDialog();

            _RefreshTestAppointmentsDataGrid();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                clsMessageBoxManager.ShowMessageBox("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                _OpenScheduleTestForm(_LocalDrivingLicenseApplicationID);
                return;
            }

            if (LastTest.Result)
            {
                clsMessageBoxManager.ShowMessageBox("This person already passed this test before, you can only retake faild tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _OpenScheduleTestForm(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID);
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            _OpenScheduleTestForm(_LocalDrivingLicenseApplicationID, TestAppointmentID);
        }

        private void TakeTestStripMenuItem1_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest FormTakeTest = new frmTakeTest(TestAppointmentID, _TestType);
            FormTakeTest.ShowDialog();
        }

        private void cmTestAppointmentSettings_Opening(object sender, CancelEventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            TakeTestStripMenuItem1.Enabled = !clsTestAppointment.GetTestAppointmentByID(TestAppointmentID).IsLocked;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
