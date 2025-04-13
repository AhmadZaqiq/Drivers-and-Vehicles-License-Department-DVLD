using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Tests.Forms
{
    public partial class frmScheduleTest : Form
    {
        public event Action DataAdded;

        private enum enTestType { Vision = 1, Written = 2, Street = 3 };

        private enTestType _TestType;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsApplication _Application;

        private clsTestAppointment _TestAppointment;

        private int _TestAppointmentID = -1;

        private int _LocalDrivingApplicationID;

        private decimal _Fees;

        public frmScheduleTest(int TestAppointmentID, int LocalDrivingLicenseApplication, int TestTypeNumber, frmTestAppointments FormTestAppointments)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplication);

            _LocalDrivingApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            _Application = clsApplication.GetApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);

            _TestAppointmentID = TestAppointmentID;

            _TestType = (enTestType)TestTypeNumber;

            if (FormTestAppointments != null)
            {
                this.DataAdded += FormTestAppointments.RefreshTestAppointmentsDataGrid;
            }

            _Fees = clsTestType.GetTestTypeByID((int)_TestType).TestTypeFees;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _PopulateTestAppointmentInfo();

            dtpTestAppointmentDate.MinDate = DateTime.Today.AddDays(1);

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _PopulateTestAppointmentInfo()
        {
            lblDLAppID.Text = _LocalDrivingApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
            lblName.Text = clsPerson.GetPersonByID(_Application.ApplicantPersonID).FullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.GetPassedTestsCountForLocalApplication(_LocalDrivingApplicationID, _LocalDrivingLicenseApplication.LicenseClassID, false).ToString();
            lblFees.Text = _Fees.ToString();
        }

        private void _LoadTestAppointmentData()
        {
            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingApplicationID;
            _TestAppointment.AppointmentDate = dtpTestAppointmentDate.Value;
            _TestAppointment.PaidFees = _Fees;
            _TestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;
            _TestAppointment.RetakeTestApplicationID = -1; //Do not Change -1 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment = (clsTestAppointment.IsTestAppointmentExists(_TestAppointmentID)) ? clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID) : new clsTestAppointment();

            _LoadTestAppointmentData();

            if (!_TestAppointment.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _TestAppointmentID = _TestAppointment.TestAppointmentID;

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
