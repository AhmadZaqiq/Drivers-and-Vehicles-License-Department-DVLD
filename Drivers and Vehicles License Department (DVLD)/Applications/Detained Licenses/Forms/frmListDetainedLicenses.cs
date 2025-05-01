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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Detained_Licenses.Forms
{
    public partial class frmListDetainedLicenses : Form
    {
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frm_ListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _FillDetainedLicensesComboBox();

            RefreshDetainedLicensesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _FillDetainedLicensesComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("DetainID");
            cbFilter.Items.Add("LicenseID");
            cbFilter.Items.Add("DetainDate");
            cbFilter.Items.Add("IsReleased");
            cbFilter.Items.Add("FineFees");
            cbFilter.Items.Add("ReleaseDate");
            cbFilter.Items.Add("NationalNO");
            cbFilter.Items.Add("FullName");
            cbFilter.Items.Add("ReleaseApplicationID");

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateDetainedLicensesCount()
        {
            lblRecordsCount.Text = (dgvDetainedLicenses.RowCount).ToString();
        }

        public void RefreshDetainedLicensesDataGrid()
        {
            dgvDetainedLicenses.DataSource = clsDetainedLicense.GetAllDetainedLicenses();

            _UpdateDetainedLicensesCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshDetainedLicensesDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsDetainedLicense.GetAllDetainedLicenses());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvDetainedLicenses.DataSource = dv;

            _UpdateDetainedLicensesCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (!(FilterColumn == "DetainID"))
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "00000000000000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense FormReleaseLicense = new frmReleaseLicense(this);
            FormReleaseLicense.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense FormDetainLicense = new frmDetainLicense(this);
            FormDetainLicense.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowPersonlicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvDetainedLicenses.SelectedRows[0];

            int LicenseID = Convert.ToInt32(SelectedRow.Cells["LicenseID"].Value);

            int PersonID = clsLicense.GetPersonIDByLicenseID(LicenseID);

            frmShowPersonDetails FormShowPersonDetails = new frmShowPersonDetails(PersonID);
            FormShowPersonDetails.ShowDialog();
        }

        private void LicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvDetainedLicenses.SelectedRows[0];

            int LicenseID = Convert.ToInt32(SelectedRow.Cells["LicenseID"].Value);

            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void LicenseHistryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvDetainedLicenses.SelectedRows[0];

            int LicenseID = Convert.ToInt32(SelectedRow.Cells["LicenseID"].Value);

            int DriverID = clsLicense.GetLicenseByID(LicenseID).DriverID;

            int PersonID = clsLicense.GetPersonIDByLicenseID(LicenseID);

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(DriverID, PersonID);
            FormLicensesHistory.ShowDialog();
        }


    }
}
