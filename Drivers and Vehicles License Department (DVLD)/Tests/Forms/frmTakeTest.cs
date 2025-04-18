using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Tests.Forms
{
    public partial class frmTakeTest : Form
    {
        public event Action DataAdded;

        private enum enTestType { Vision = 1, Written = 2, Street = 3 };

        private enTestType _TestType;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsApplication _Application;

        private clsTestAppointment _TestAppointment;

        private clsTest _Test;

        private int _TestAppointmentID = -1;

        private int _LocalDrivingApplicationID;

        private decimal _Fees;

        public frmTakeTest(int TestAppointmentID, int LocalDrivingLicenseApplication, int TestTypeNumber, frmTestAppointments FormTestAppointments)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplication);

            _LocalDrivingApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            _Application = clsApplication.GetApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);

            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            _TestType = (enTestType)TestTypeNumber;

            if (FormTestAppointments != null)
            {
                this.DataAdded += FormTestAppointments.FillLocalDrivingApplicationCard;
                this.DataAdded += FormTestAppointments._RefreshTestAppointmentsDataGrid;
            }

            _Fees = clsTestType.GetTestTypeByID((int)_TestType).TestTypeFees;
        }

        public void frmTakeTest_Load(object sender, EventArgs e)
        {
            _PopulateTestAppointmentInfo();

            _UpdateTestTypeUI();

            rbPass.Checked = true;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _UpdateTestTypeUI()
        {
            switch (_TestType)
            {
                case enTestType.Vision:

                    pbTestType.BackgroundImage = Resources.Eye_Test_Pic;

                    break;

                case enTestType.Written:

                    pbTestType.BackgroundImage = Resources.Writen_Test_pic;

                    break;

                case enTestType.Street:

                    pbTestType.BackgroundImage = Resources.Street_Test_Pic;

                    break;
            }
        }

        private void _PopulateTestAppointmentInfo()
        {
            lblDLAppID.Text = _LocalDrivingApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
            lblName.Text = clsPerson.GetPersonByID(_Application.ApplicantPersonID).FullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.GetTestsCountForLocalApplication(_LocalDrivingApplicationID, _LocalDrivingLicenseApplication.LicenseClassID, false).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _Fees.ToString();
        }

        private void _LoadTestData()
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = lblNotes.Text;
            _Test.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _LoadRetakeApplicationData(clsApplication RetakeApplication)
        {
            int RetakeDrivingTestApplicationTypeID = 7;

            RetakeApplication.ApplicantPersonID = _Application.ApplicantPersonID;
            RetakeApplication.ApplicationDate = DateTime.Now;
            RetakeApplication.ApplicationTypeID = _Application.ApplicationTypeID;
            RetakeApplication.ApplicationStatus = _Application.ApplicationStatus;
            RetakeApplication.LastStatusDate = DateTime.Now;
            RetakeApplication.PaidFees = clsApplicationType.GetApplicationTypeByID(RetakeDrivingTestApplicationTypeID).ApplicationTypeFees;
            RetakeApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _CheckIfPassOrFailTest()
        {
            if (_Test.TestResult)
            {
                return;
            }

            clsApplication RetakeApplication = new clsApplication();

            _LoadRetakeApplicationData(RetakeApplication);

            if (!RetakeApplication.AddNewApplication())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _TestAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test = new clsTest();

            _LoadTestData();

            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save ?",
                                                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            if (!_Test.AddNewTest())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _TestAppointment.IsLocked = true;

            _CheckIfPassOrFailTest();

            if (!_TestAppointment.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
