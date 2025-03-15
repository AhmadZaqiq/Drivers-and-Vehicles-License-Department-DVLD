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
        public event Action DataAdded;

        private clsApplication _Application = new clsApplication();

        private clsLocalDrivingLicenseApplication _ApplicationLocal = new clsLocalDrivingLicenseApplication();

        private const int NewLocalDrivingLicenseServiesID = 1;

        private DateTime _ApplicationLastStatusDate = DateTime.Now;

        clsApplicationType _NewLocalDrivingLicenseServies = clsApplicationType.GetApplicationTypeByID(NewLocalDrivingLicenseServiesID);
        public enum enStatus { New = 1, Canceled = 2, Completed = 3 };

        private enStatus _Status = enStatus.New;

        public frmAddAndUpdateLocalDrivingApplication(frmListLocalDrivingLicenseApplications FormListLocalDrivingLicenseApplications)
        {
            InitializeComponent();

            if (FormListLocalDrivingLicenseApplications != null)
            {
                this.DataAdded += FormListLocalDrivingLicenseApplications.RefreshLocalDrivingApplicationsDataGrid;
            }
        }

        private int _GetLicenseClassIDFromComboBox()
        {
            return cbLicenseClass.SelectedIndex + 1;
        }

        private void frmAddAndUpdateLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesComboBox();

            _SetDefaultApplicationInfoValues();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillLicenseClassesComboBox()
        {
            DataTable LicenseClass = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = LicenseClass;
            cbLicenseClass.DisplayMember = "ClassName";
        }

        private void _SetDefaultApplicationInfoValues()
        {
            lblApplicationFees.Text = _NewLocalDrivingLicenseServies.ApplicationTypeFees.ToString("G29");
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
        }

        private int _SetStatusID()
        {
            switch (_Status)
            {
                case enStatus.New: return 1;

                case enStatus.Canceled: return 2;

                case enStatus.Completed: return 3;

                default: return 1;
            }
        }

        private void _LoadApplicationData()
        {
            _Application.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _NewLocalDrivingLicenseServies.ApplicationTypeID;
            _Application.ApplicationStatus = _SetStatusID();
            _Application.LastStatusDate = _ApplicationLastStatusDate;
            _Application.PaidFees = _NewLocalDrivingLicenseServies.ApplicationTypeFees;
            _Application.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _LoadLocalApplicationData()
        {
            _ApplicationLocal.ApplicationID = _Application.ApplicationID;
            _ApplicationLocal.LicenseClassID = _GetLicenseClassIDFromComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int PersonID = ctrlPersonCardWithFilter1.PersonID;
            int LicenseClassID = _GetLicenseClassIDFromComboBox();
            int NewLocalApplicationTypeID = clsApplicationType.GetApplicationTypeByID(1).ApplicationTypeID;

            if (clsLocalDrivingLicenseApplication.IsPersonDeniedForClass(PersonID, NewLocalApplicationTypeID, LicenseClassID))
            {
                clsMessageBoxManager.ShowMessageBox("Choose another License Class. " +
                                "The selected person already has an active application for the selected class with ID: " + clsApplication.GetApplicationIDByApplicantPersonID(PersonID),
                                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PersonID == -1)
            {
                clsMessageBoxManager.ShowMessageBox("Please select a person first", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadApplicationData();

            if (!_Application.AddNewApplication())
            {
                clsMessageBoxManager.ShowMessageBox("Data not Saved...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationLocal = new clsLocalDrivingLicenseApplication(); // Ensures a new ID is assigned for each instance.  

            _LoadLocalApplicationData();

            if (!_ApplicationLocal.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data not Saved...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Data Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabApplicationInfo;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }


    }
}
