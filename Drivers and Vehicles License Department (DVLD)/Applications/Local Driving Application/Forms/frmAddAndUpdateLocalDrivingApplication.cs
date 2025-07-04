using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application
{
    public partial class frmAddAndUpdateLocalDrivingApplication : Form
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _SelectedPersonID = -1;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode = enMode.AddNew;

        public frmAddAndUpdateLocalDrivingApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddAndUpdateLocalDrivingApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void frmAddAndUpdateLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadLocalDrivingApplicationData();
            }

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                tabApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
            }

            else
            {
                lblTitle.Text = "Update Local Driving License Application";

                tabApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtLicenseClass = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dtLicenseClass;
            cbLicenseClass.DisplayMember = "ClassName";
        }

        private void _LoadLocalDrivingApplicationData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.Date);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.GetLicenseClass(_LocalDrivingLicenseApplication.LicenseClassID).Name);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.GetUserByID(_LocalDrivingLicenseApplication.CreatedByUserID).Username;
        }

        private void _FillLocalApplicationInfo(int LicenseClassID)
        {
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.Date = DateTime.Now;
            _LocalDrivingLicenseApplication.TypeID = 1;// 1 Stands from New Local Application service
            _LocalDrivingLicenseApplication.Status = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.GetLicenseClass(cbLicenseClass.Text).ID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                clsMessageBoxManager.ShowMessageBox($@"Choose another License Class.
                                                     The selected person already has an active application for the selected class 
                                                     with ID: {ActiveApplicationID}",
                                                     "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {
                clsMessageBoxManager.ShowMessageBox("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalApplicationInfo(LicenseClassID);

            if (!_LocalDrivingLicenseApplication.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data not Saved...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();

            _Mode = enMode.Update;

            lblTitle.Text = "Update Local Driving License Application";

            clsMessageBoxManager.ShowMessageBox("Data Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabApplicationInfo;

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabApplicationInfo.Enabled = true;
                TabControl1.SelectedTab = tabApplicationInfo;
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tabApplicationInfo.Enabled = true;
                TabControl1.SelectedTab = tabApplicationInfo;
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }


    }
}
