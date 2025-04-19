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
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsApplication _Application;

        private clsPerson _ApplicantPerson;

        private clsUser _CreatedByUser;

        private int _LocalDrivingApplicationID;

        private int _ApplicationID;

        private enum enStatus { New = 1, Cancelled = 2, Completed = 3 };

        public ctrlLocalDrivingApplicationCard()
        {
            InitializeComponent();
        }

        public int LocalDrivingApplicationID
        {
            set
            {
                _LocalDrivingApplicationID = value;

                if (_LocalDrivingApplicationID == -1)
                {
                    return; // Exits only from get
                }

                _DisplayAllApplicationDetails();
            }

            get
            {
                return _LocalDrivingApplicationID;
            }
        }

        private void _LoadBasicAndLocalApplicationData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingApplicationID);

            _ApplicationID = _LocalDrivingLicenseApplication.ApplicationID;

            _Application = clsApplication.GetApplicationByID(_ApplicationID);

            _ApplicantPerson = clsPerson.GetPersonByID(_Application.ApplicantPersonID);

            _CreatedByUser = clsUser.GetUserByID(_Application.CreatedByUserID);
        }

        private enStatus _SetStatus(int StatusNumber)
        {
            return (enStatus)StatusNumber;
        }

        private void _PopulateLocalApplicationDetails()
        {
            lblLocalApplicationID.Text = _LocalDrivingApplicationID.ToString();
            lblPassedTests.Text = clsLocalDrivingLicenseApplication.GetTestsCountForLocalApplication(_LocalDrivingApplicationID, _LocalDrivingLicenseApplication.LicenseClassID,true).ToString() + "/3";
            lblAppliedForLicence.Text = clsLicenseClass.GetLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName.ToString();
        }

        private void _PopulateApplicationBasicDetails()
        {
            lblApplicationID.Text = _ApplicationID.ToString();
            lblStatus.Text = _SetStatus(_Application.ApplicationStatus).ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = clsApplicationType.GetApplicationTypeByID(_Application.ApplicationTypeID).ApplicationTypeTitle.ToString();
            lblApplicant.Text = _ApplicantPerson.FullName.ToString();
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = _CreatedByUser.Username.ToString();
        }

        private void _DisplayAllApplicationDetails()
        {
            _LoadBasicAndLocalApplicationData();

            if (_LocalDrivingLicenseApplication == null)
            {
                return;
            }

            _PopulateLocalApplicationDetails();
            _PopulateApplicationBasicDetails();
        }

        private void btnViewPersonInfo_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails FormPersonDetails = new frmShowPersonDetails(_ApplicantPerson.PersonID);
            FormPersonDetails.ShowDialog();
        }

        private void btnShowLicenceInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
