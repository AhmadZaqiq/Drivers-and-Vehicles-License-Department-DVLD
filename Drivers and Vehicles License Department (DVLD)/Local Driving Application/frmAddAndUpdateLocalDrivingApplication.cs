using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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
        private clsApplication _Application = new clsApplication();

        private clsLocalDrivingLicenseApplication _ApplicationLocal;

        private DateTime _ApplicationLastStatusDate = DateTime.Now;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enStatus { New = 1, Canceled = 2, Completed = 3 };

        private enMode _Mode = enMode.AddNew;

        private enStatus _Status = enStatus.New;



        public frmAddAndUpdateLocalDrivingApplication()
        {
            InitializeComponent();
        }

        private void frmAddAndUpdateLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesComobBox();

            _SetDefaultAplicationInfoValues();

            _UpdateMode();

            _UpdateTitle();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillLicenseClassesComobBox()
        {
            DataTable LicenseClass = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = LicenseClass;
            cbLicenseClass.DisplayMember = "ClassName";
        }

        private void _UpdateMode()
        {
            _Mode = (ctrlPersonCardWithFilter1.PersonID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void _UpdateTitle()
        {
            lblTitle.Text = (_Mode == enMode.AddNew) ? "New Local Driving License Application"
                                                     : "Update Local Driving License Application";
        }

        private void _SetDefaultAplicationInfoValues()
        {
            decimal ApplicationFees = clsApplicationType.GetApplicationTypeByID(1).ApplicationTypeFees;

            lblApplicationFees.Text = ApplicationFees.ToString("G29");
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.Username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
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

        private decimal _SetApplicationFees()
        {
            decimal ApplicationTypeFees = 1;

            switch (_Mode)
            {
                case enMode.AddNew:
                    ApplicationTypeFees = clsApplicationType.GetApplicationTypeByID(1).ApplicationTypeFees;
                    break;

                case enMode.Update:
                    ApplicationTypeFees = clsApplicationType.GetApplicationTypeByID(2).ApplicationTypeFees;
                    break;
            }

            return ApplicationTypeFees;
        }

        private int _SetApplicationType()
        {
            int ApplicationTypeID = 1;

            switch (_Mode)
            {
                case enMode.AddNew:
                    ApplicationTypeID = clsApplicationType.GetApplicationTypeByID(1).ApplicationTypeID;
                    break;

                case enMode.Update:
                    ApplicationTypeID = clsApplicationType.GetApplicationTypeByID(2).ApplicationTypeID;
                    break;
            }

            return ApplicationTypeID;
        }

        private void _LoadApplicationData()
        {
            _Application.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = _SetApplicationType();
            _Application.ApplicationStatus = _SetStatusID();
            _Application.LastStatusDate = _ApplicationLastStatusDate;
            _Application.PaidFees = _SetApplicationFees();
            _Application.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
        }

        private void _LoadLocalApplicationData()
        {
            _ApplicationLocal.ApplicationID = _Application.ApplicationID;
            _ApplicationLocal.LicenseClassID = cbLicenseClass.SelectedIndex + 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please select a person first", "Failed");
                return;
            }

            _LoadApplicationData();

            if (!_Application.AddNewApplication())
            {
                MessageBox.Show("Data not Saved...", "Failed");
                return;
            }

            _LoadLocalApplicationData();

            if (!_ApplicationLocal.Save())
            {
                MessageBox.Show("Data not Saved...", "Failed");
                return;
            }

            MessageBox.Show("Data Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





    }
}
