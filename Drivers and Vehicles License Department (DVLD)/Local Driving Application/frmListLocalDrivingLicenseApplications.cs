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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshLocalDrivingApplicationsDataGrid();

            _FillComboBox();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("LocalDrivingLicenseApplications");
            cbFilter.Items.Add("ClassName");
            cbFilter.Items.Add("FullName");
            cbFilter.Items.Add("ApplicationStatus");

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateLocalDrivingApplicationsCount()
        {
            lblRecordsCount.Text = (dgvLocalDrivingLicenseApplications.RowCount).ToString();
        }

        public void RefreshLocalDrivingApplicationsDataGrid()
        {
            dgvLocalDrivingLicenseApplications.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications();

            _UpdateLocalDrivingApplicationsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                RefreshLocalDrivingApplicationsDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(clsLocalDrivingLicenseApplication.GetAllLocalDrivingApplications());
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvLocalDrivingLicenseApplications.DataSource = dv;

            _UpdateLocalDrivingApplicationsCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (!(FilterColumn == "LocalDrivingLicenseApplicationID"))
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "00000000000000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateLocalDrivingApplication FormAddAndUpdateLocalDrivingApplication = new frmAddAndUpdateLocalDrivingApplication();
            FormAddAndUpdateLocalDrivingApplication.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void dgvLocalDrivingLicenseApplications_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvLocalDrivingLicenseApplications_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void CancelApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];

            if (MessageBox.Show("Are You Sure you want to Cancel this Application?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int LocalApplicationID = Convert.ToInt32(SelectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            if(!clsLocalDrivingLicenseApplication.CancelLocalDrivingLicenseApplication(LocalApplicationID))
            {
                MessageBox.Show("Person was not Cancelled", "Alert");
                return;
            }

            MessageBox.Show("Person Cancelled successfully.", "Done");
            RefreshLocalDrivingApplicationsDataGrid();
        }
    }
}
