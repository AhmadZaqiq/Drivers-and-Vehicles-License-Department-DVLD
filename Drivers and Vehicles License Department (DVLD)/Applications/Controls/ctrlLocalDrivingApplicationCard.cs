using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;



namespace Drivers_and_Vehicles_License_Department__DVLD_.Applications.Controls
{
    public partial class ctrlLocalDrivingApplicationCard : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

        private clsApplication _Application = new clsApplication();

        private int _LocalDrivingApplicationID;

        private int _PersonID = 0;
        public enum enStatus { New = 1, Cancelled = 2, Completed = 3 };

        public ctrlLocalDrivingApplicationCard()
        {
            InitializeComponent();
        }

        private void ctrlLocalDrivingApplicationCard_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingApplicationID);
        }

        private void _FillLocalApplicationData()
        {
            lblLocalApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblPassedTests.Text = clsTestAppointment.GetTestAppointmentCountForPerson(_PersonID).ToString();
        }



        private enStatus _SetStatus(int StatusNumber)
        {
            enStatus NewStatus = (enStatus)StatusNumber;

            switch (NewStatus)
            {
                case enStatus.New:
                    return enStatus.New;

                case enStatus.Cancelled:
                    return enStatus.Cancelled;

                case enStatus.Completed:
                    return enStatus.Completed;

                default:
                    return NewStatus;
            }
        }

        private void _FillApplicationBasicData()
        {
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _SetStatus(_Application.ApplicationStatus).ToString();
            lblFees.Text= _Application.PaidFees.ToString();
            lblType.Text=clsApplicationType.GetApplicationTypeByID(_Application.ApplicationTypeID).ToString();
            lblType.Text=clsPerson.GetPersonByID(_Application.ApplicantPersonID).ToString();
            lblDate.Text=_Application.ApplicationDate.ToString();
            lblStatusDate.Text=_Application.LastStatusDate.ToString();
            lblCreatedBy.Text=_Application.CreatedByUserID.ToString();
        }

        public int LocalDrivingApplicationID
        {
            set
            {
                _LocalDrivingApplicationID = value;
                _FillLocalApplicationData();
                _FillApplicationBasicData();
            }
            get
            {
                return _LocalDrivingApplicationID;
            }
        }


    }
}
