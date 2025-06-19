using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
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

        private bool _IsRetakeTest = false;

        private int _RetakeTestApplicationID = -1;

        public frmScheduleTest(bool IsRetakeTest, int TestAppointmentID, int LocalDrivingLicenseApplication, int TestTypeNumber, frmTestAppointments FormTestAppointments)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplication);

            _LocalDrivingApplicationID = _LocalDrivingLicenseApplication.ID;

            _Application = clsApplication.GetApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);

            _TestAppointmentID = TestAppointmentID; // For Update

            _TestType = (enTestType)TestTypeNumber;

            if (FormTestAppointments != null)
            {
                this.DataAdded += FormTestAppointments.FillLocalDrivingApplicationCard;
                this.DataAdded += FormTestAppointments._RefreshTestAppointmentsDataGrid;
            }

            _Fees = clsTestType.GetTestTypeByID((int)_TestType).Fees;

            _IsRetakeTest = IsRetakeTest;

            if (_TestAppointmentID != -1)
            {
                _RetakeTestApplicationID = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID).RetakeTestApplicationID;
            }

        }

        public void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _PopulateTestAppointmentInfo();

            dtpTestAppointmentDate.MinDate = DateTime.Today.AddDays(1);

            _CheckIfAppointmentLocked();

            _CheckIfRetakeTest();

            _UpdateTestTypeUI();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
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

        private decimal _CalculateTotalFees()
        {
            int RetakeDrivingTestApplicationTypeID = 7;

            return _Fees + clsApplicationType.GetApplicationTypeByID(RetakeDrivingTestApplicationTypeID).ApplicationTypeFees;
        }

        private void _PopulateRetakeTestAppointmentInfo()
        {
            clsApplication RetakeDrivingTestApplication = clsApplication.GetApplicationByID(_RetakeTestApplicationID);

            lblRTestAppID.Text = RetakeDrivingTestApplication.ID.ToString();
            lblRAppFees.Text = RetakeDrivingTestApplication.PaidFees.ToString();
            lblTotalFees.Text = _IsRetakeTest ? _CalculateTotalFees().ToString("0.00") : "N/A";
        }

        private void _CheckIfRetakeTest()
        {
            if (_IsRetakeTest)
            {
                _PopulateRetakeTestAppointmentInfo();
            }

            lblRTestAppID.Enabled = _IsRetakeTest;
            lblRAppFees.Enabled = _IsRetakeTest;
            lblTotalFees.Enabled = _IsRetakeTest;
            lblRetakeTestInfo.Enabled = _IsRetakeTest;
        }

        private void _CheckIfAppointmentLocked()
        {
            bool IsLocked = false;

            if (_TestAppointmentID != -1 && clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID).RetakeTestApplicationID == -1)
            {
                IsLocked = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID).IsLocked;
            }

            lblSatWarningMessage.Visible = IsLocked;
            btnSave.Enabled = !IsLocked;
            dtpTestAppointmentDate.Enabled = !IsLocked;
        }

        private void _PopulateTestAppointmentInfo()
        {
            lblDLAppID.Text = _LocalDrivingApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).Name.ToString();
            lblName.Text = clsPerson.GetPersonByID(_Application.ApplicantPersonID).FullName;
            lblAttempts.Text = clsTest.GetTestAttemptsCountByTestType(_LocalDrivingApplicationID, _LocalDrivingLicenseApplication.LicenseClassID, (int)_TestType, false).ToString();
            lblFees.Text = _Fees.ToString();
        }

        private void _LoadTestAppointmentData()
        {
            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingApplicationID;
            _TestAppointment.Date = dtpTestAppointmentDate.Value;
            _TestAppointment.PaidFees = _Fees;
            _TestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
            _TestAppointment.IsLocked = false;

            if (!_IsRetakeTest)
            {
                _TestAppointment.RetakeTestApplicationID = -1; // Do not Change -1
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsRetakeTest)
            {
                _TestAppointment = (clsTestAppointment.IsTestAppointmentExists(_TestAppointmentID)) ? clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID) : new clsTestAppointment();
            }

            else
            {
                _TestAppointment = new clsTestAppointment();
            }

            _LoadTestAppointmentData();

            if (!_TestAppointment.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
