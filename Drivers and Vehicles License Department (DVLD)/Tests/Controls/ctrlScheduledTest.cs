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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsTestAppointment _TestAppointment;

        public ctrlScheduledTest()
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

                        pbTestType.BackgroundImage = Resources.Eye_Test_Pic;
                        break;


                    case clsTestType.enTestType.WrittenTest:

                        pbTestType.BackgroundImage = Resources.Writen_Test_pic;
                        break;


                    case clsTestType.enTestType.StreetTest:

                        pbTestType.BackgroundImage = Resources.Street_Test_Pic;
                        break;

                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private bool LoadLocalDrivingLicenseApplication()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _FillTestAppointmentInfo()
        {
            lblDLAppID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.Name;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalAttemptsPerTest(_TestTypeID).ToString();
            lblDate.Text = clsFormat.DateToShort(_TestAppointment.Date);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();
        }

        public void LoadScheduledTestInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                clsMessageBoxManager.ShowMessageBox("Error: No Appointment ID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;

            if (!LoadLocalDrivingLicenseApplication())
            {
                return;
            }

            _FillTestAppointmentInfo();
        }


    }
}
