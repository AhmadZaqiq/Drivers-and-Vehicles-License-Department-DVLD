using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms
{
    public partial class frmListInternationalDrivingLicenses : Form
    {
        public frmListInternationalDrivingLicenses()
        {
            InitializeComponent();
        }

        private void frmListInternationalDrivingLicenses_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            RefreshInternationalDrivingLicensesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("InternationalLicenseID");
            cbFilter.Items.Add("ApplicationID");
            cbFilter.Items.Add("DriverID");

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateInternationalDrivingLicensesCount()
        {
            lblRecordsCount.Text = (dgvInternationalLicense.RowCount).ToString();
        }

        public void RefreshInternationalDrivingLicensesDataGrid()
        {
            dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();

            _UpdateInternationalDrivingLicensesCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshInternationalDrivingLicensesDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsInternationalLicense.GetAllInternationalLicenses());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvInternationalLicense.DataSource = dv;

            _UpdateInternationalDrivingLicensesCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (!(FilterColumn == "InternationalLicenseID"))
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "00000000000000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void btnAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense FormIssueInternationalDrivingLicense = new frmIssueInternationalDrivingLicense();
            FormIssueInternationalDrivingLicense.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowPersonDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvInternationalLicense.SelectedRows[0];

            int InternationalLicenseID = Convert.ToInt32(SelectedRow.Cells["InternationalLicenseID"].Value);

            int LicenseID = clsInternationalLicense.GetInternationalLicenseByID(InternationalLicenseID).IssuedUsingLocalLicenseID;

            int PersonID = clsLicense.GetPersonIDByLicenseID(LicenseID);

            frmShowPersonDetails frmShowPersonDetails = new frmShowPersonDetails(PersonID);
            frmShowPersonDetails.ShowDialog();
        }

        private void CancelApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvInternationalLicense.SelectedRows[0];

            int InternationalLicenseID = Convert.ToInt32(SelectedRow.Cells["InternationalLicenseID"].Value);

            frmDriverInternationalLicenseInfo FormDriverInternationalLicenseInfo = new frmDriverInternationalLicenseInfo(InternationalLicenseID);
            FormDriverInternationalLicenseInfo.ShowDialog();
        }

        private void ShowPersonlicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvInternationalLicense.SelectedRows[0];

            int DriverID = Convert.ToInt32(SelectedRow.Cells["DriverID"].Value);

            int InternationalLicenseID = Convert.ToInt32(SelectedRow.Cells["InternationalLicenseID"].Value);

            int LicenseID = clsInternationalLicense.GetInternationalLicenseByID(InternationalLicenseID).IssuedUsingLocalLicenseID;

            int PersonID = clsLicense.GetPersonIDByLicenseID(LicenseID);

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(DriverID, PersonID);
            FormLicensesHistory.ShowDialog();
        }


    }
}
