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
        private DataTable _dtInternationalLicenses;

        public frmListInternationalDrivingLicenses()
        {
            InitializeComponent();
        }

        private void frmListInternationalDrivingLicenses_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            RefreshInternationalDrivingLicensesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30);

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
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();

            dgvInternationalLicense.DataSource = _dtInternationalLicenses;

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
            int DriverID = (int)dgvInternationalLicense.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.GetDriverByID(DriverID).PersonID;

            frmShowPersonDetails frmShowPersonDetails = new frmShowPersonDetails(PersonID);
            frmShowPersonDetails.ShowDialog();
        }

        private void ShowLicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicense.CurrentRow.Cells[0].Value;

            frmDriverInternationalLicenseInfo FormDriverInternationalLicenseInfo = new frmDriverInternationalLicenseInfo(InternationalLicenseID);
            FormDriverInternationalLicenseInfo.ShowDialog();
        }

        private void ShowPersonLicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicense.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.GetDriverByID(DriverID).PersonID;

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(PersonID);
            FormLicensesHistory.ShowDialog();
        }


    }
}
