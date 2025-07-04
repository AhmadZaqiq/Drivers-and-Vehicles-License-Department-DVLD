using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
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
using static System.Net.Mime.MediaTypeNames;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };

        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            pbTestType.BackgroundImage = Resources.Eye_Test_Pic;
                            lblTestType.Text = "Vision Test Appointment";
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            pbTestType.BackgroundImage = Resources.Writen_Test_pic;
                            lblTestType.Text = "Written Test Appointment";
                            break;
                        }

                    case clsTestType.enTestType.StreetTest:
                        {
                            pbTestType.BackgroundImage = Resources.Street_Test_Pic;
                            lblTestType.Text = "Street Test Appointment";
                            break;
                        }
                }
            }
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            _Mode = (AppointmentID == -1) ? enMode.AddNew : enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            if (!_LoadLocalDrivingLicenseApplication())
            {
                return;
            }

            _CreationMode = (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID)) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;

            _LoadRetakeTestInfo();

            _LoadBasicApplicationInfo();

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.GetTestTypeByID(_TestTypeID).Fees.ToString();
                dtpTestAppointmentDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";
                _TestAppointment = new clsTestAppointment();

                lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRAppFees.Text)).ToString();

                if (!_HandleActiveTestAppointmentConstraint())
                {
                    return;
                }


                if (!_HandleAppointmentLockedConstraint())
                {
                    return;
                }

                if (!_HandlePrviousTestConstraint())

                {
                    return;
                }

                return;
            }

            if (!_LoadTestAppointmentData())
            {
                return;
            }
        }

        private bool _LoadLocalDrivingLicenseApplication()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication != null)
            {
                return true;
            }

            clsMessageBoxManager.ShowMessageBox($"Error: No Local Driving License Application with ID = {_LocalDrivingLicenseApplicationID}",
                                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnSave.Enabled = false;

            return false;
        }

        private void _LoadRetakeTestInfo()
        {
            if (_CreationMode != enCreationMode.RetakeTestSchedule)
            {
                gbRetakeTestInfo.Enabled = false;
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
                return;
            }

            lblRAppFees.Text = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
            gbRetakeTestInfo.Enabled = true;
            lblRTestAppID.Text = "0";
        }

        private void _LoadBasicApplicationInfo()
        {
            lblDLAppID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.Name;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblAttempts.Text = _LocalDrivingLicenseApplication.TotalAttemptsPerTest(_TestTypeID).ToString();
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                clsMessageBoxManager.ShowMessageBox("Person Already have an active appointment for this test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                dtpTestAppointmentDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                clsMessageBoxManager.ShowMessageBox("Person already sat for the test, appointment loacked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTestAppointmentDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:

                    {
                        return true;
                    }
                case clsTestType.enTestType.WrittenTest:

                    {
                        if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                        {
                            clsMessageBoxManager.ShowMessageBox("Cannot schedule, Vision Test should be passed first", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSave.Enabled = false;
                            dtpTestAppointmentDate.Enabled = false;
                            return false;
                        }

                        btnSave.Enabled = true;
                        dtpTestAppointmentDate.Enabled = true;
                        return true;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                        {
                            clsMessageBoxManager.ShowMessageBox("Cannot schedule, Written Test should be passed first", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSave.Enabled = false;
                            dtpTestAppointmentDate.Enabled = false;
                            return false;
                        }

                        btnSave.Enabled = true;
                        dtpTestAppointmentDate.Enabled = true;
                        return true;
                    }
            }

            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                clsMessageBoxManager.ShowMessageBox("Error: No Appointment with ID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();
            dtpTestAppointmentDate.MinDate = (DateTime.Now < _TestAppointment.Date) ? DateTime.Now : _TestAppointment.Date;
            dtpTestAppointmentDate.Value = _TestAppointment.Date;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
                return true;
            }

            lblRAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
            lblRTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            gbRetakeTestInfo.Enabled = true;

            return true;
        }

        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.Date = DateTime.Now;
                Application.TypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.Status = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsCurrentUser.CurrentUser.ID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    clsMessageBoxManager.ShowMessageBox("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }

            return true;
        }

        private void _FillTestAppointmentInfo()
        {
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.ID;
            _TestAppointment.Date = dtpTestAppointmentDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
            {
                return;
            }

            _FillTestAppointmentInfo();

            if (!_TestAppointment.Save())
            {

                clsMessageBoxManager.ShowMessageBox("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.Update;
            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
