using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms
{
    public partial class frmTestAppointments : Form
    {
        private enum enTestType { Vision = 1, Written = 2, Street = 3 };

        private enTestType _TestType;

        private int _LocalDrivingApplicationID = -1;

        public frmTestAppointments(int LocalDrivingApplicationID, int TestTypeNumber)
        {
            InitializeComponent();

            this._LocalDrivingApplicationID = LocalDrivingApplicationID;

            _TestType = (enTestType)TestTypeNumber;
        }

        private void _UpdateTestAppointmentsCount()
        {
            lblRecordsCount.Text = (dgvTestAppointments.RowCount).ToString();
        }

        public void RefreshTestAppointmentsDataGrid()
        {
            dgvTestAppointments.DataSource =clsTestAppointment.GetAllTestAppointmentsForLocalApp(_LocalDrivingApplicationID);

            _UpdateTestAppointmentsCount();
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingApplicationCard1.LocalDrivingApplicationID = _LocalDrivingApplicationID;

            RefreshTestAppointmentsDataGrid();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsAppointmentScheduledForPerson(_LocalDrivingApplicationID,clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingApplicationID).LicenseClassID))
            {
                clsMessageBoxManager.ShowMessageBox("The person already has an active appointment for this test. You cannot add a new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest FormScheduleTest = new frmScheduleTest(-1,_LocalDrivingApplicationID, (int)_TestType,this);
            FormScheduleTest.ShowDialog();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestAppointments.SelectedRows[0];

            int TestAppointmentID = Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value);

            frmScheduleTest FormScheduleTest = new frmScheduleTest(TestAppointmentID, _LocalDrivingApplicationID, (int)_TestType, this);
            FormScheduleTest.ShowDialog();
        }

        private void TakeTestStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestAppointments.SelectedRows[0];

            int TestAppointmentID = Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value);

            frmTakeTest FormTakeTest = new frmTakeTest(TestAppointmentID,_LocalDrivingApplicationID, (int)_TestType,this);
            FormTakeTest.ShowDialog();
        }


    }
}
