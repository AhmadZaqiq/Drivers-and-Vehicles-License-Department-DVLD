using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
using DVLD_Business;



namespace Drivers_and_Vehicles_License_Department__DVLD_.Applications.Controls
{
    public partial class ctrlLocalDrivingApplicationCard : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public ctrlLocalDrivingApplicationCard()
        {
            InitializeComponent();
        }

        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
            }
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();

                clsMessageBoxManager.ShowMessageBox("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(ApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();

                clsMessageBoxManager.ShowMessageBox("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "N/A";
            lblAppliedForLicense.Text = "N/A";
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            btnShowLicenseInfo.Enabled = (_LicenseID != -1);

            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblAppliedForLicense.Text = clsLicenseClass.GetLicenseClass(_LocalDrivingLicenseApplication.LicenseClassID).Name;
             lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        private void btnShowLicenceInfo_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            FormDriverLicenseInfo.ShowDialog();
        }


    }
}
