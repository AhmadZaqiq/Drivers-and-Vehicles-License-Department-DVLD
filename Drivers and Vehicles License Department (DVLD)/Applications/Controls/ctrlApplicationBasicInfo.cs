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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;

        private int _ApplicationID = -1;

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.GetApplicationByID(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                clsMessageBoxManager.ShowMessageBox("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfo();
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "N/A";
            lblStatus.Text = "N/A";
            lblType.Text = "N/A";
            lblFees.Text = "N/A";
            lblApplicant.Text = "N/A";
            lblDate.Text = "N/A";
            lblStatusDate.Text = "N/A";
            lblCreatedBy.Text = "N/A";
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.TypeInfo.Title;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = clsFormat.DateToShort(_Application.Date);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedBy.Text = _Application.CreatedByUserInfo.Username;
        }

        private void btnViewPersonInfo_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails FormShowPersonDetails = new frmShowPersonDetails(_Application.ApplicantPersonID);
            FormShowPersonDetails.ShowDialog();

            LoadApplicationInfo(_ApplicationID);
        }


    }
}
