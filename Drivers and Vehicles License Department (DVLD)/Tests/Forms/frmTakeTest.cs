using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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

        public frmTakeTest(int TestAppointmentID, int LocalDrivingLicenseApplication, int TestTypeNumber,frmTestAppointments FormTestAppointments)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplication);

            _LocalDrivingApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            _Application = clsApplication.GetApplicationByID(_LocalDrivingLicenseApplication.ApplicationID);

            _TestAppointmentID = TestAppointmentID;

            _TestAppointment=clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            _TestType = (enTestType)TestTypeNumber;

            if (FormTestAppointments != null)
            {
                this.DataAdded += FormTestAppointments.RefreshTestAppointmentsDataGrid;
            }

            _Fees = clsTestType.GetTestTypeByID((int)_TestType).TestTypeFees;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _PopulateTestAppointmentInfo();

            rbPass.Enabled= true;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _PopulateTestAppointmentInfo()
        {
            lblDLAppID.Text = _LocalDrivingApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
            lblName.Text = clsPerson.GetPersonByID(_Application.ApplicantPersonID).FullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.GetPassedTestsCountForLocalApplication(_LocalDrivingApplicationID, _LocalDrivingLicenseApplication.LicenseClassID, false).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _Fees.ToString();
        }

        private void _LoadTestData()
        {
            _Test.TestAppointmentID= _TestAppointmentID;
            _Test.TestResult = rbPass.Checked=true;
            _Test.Notes = lblNotes.Text;
            _Test.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
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

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();

            _TestAppointment.IsLocked= true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
