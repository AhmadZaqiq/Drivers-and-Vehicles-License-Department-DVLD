using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _UpdateLocalLicensesCount()
        {
            lblLocalRecordsCount.Text = (dgvLocalLicenses.RowCount).ToString();
        }

        private void _UpdateInternationalLicensesCount()
        {
            lblInternationalRecordsCount.Text = (dgvInternationalLicenses.RowCount).ToString();
        }

        private void _RefreshLocalDrivingLicensesDataGrid()
        {
            _dtDriverLocalLicensesHistory = clsLicense.GetDriverLicenses(_DriverID);

            dgvLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;

            _UpdateLocalLicensesCount();
        }

        private void _RefreshInternationalDrivingLicensesDataGrid()
        {
            _dtDriverInternationalLicensesHistory = clsInternationalLicense.GetAllInternationalLicensesForDriver(_DriverID);

            dgvInternationalLicenses.DataSource = _dtDriverInternationalLicensesHistory;

            _UpdateInternationalLicensesCount();
        }

        public void LoadDriverLicensesInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.GetDriverByID(_DriverID);

            if (_Driver == null)
            {
                clsMessageBoxManager.ShowMessageBox("There is no driver with id = " + DriverID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _RefreshLocalDrivingLicensesDataGrid();
            _RefreshInternationalDrivingLicensesDataGrid();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.GetDriverByPersonID(PersonID);

            if (_Driver == null)
            {
                clsMessageBoxManager.ShowMessageBox("There is no driver linked with person with id = " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.ID;

            _RefreshLocalDrivingLicensesDataGrid();
            _RefreshInternationalDrivingLicensesDataGrid();
        }

        private void ShowLicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvLocalLicenses.SelectedRows[0];

            int LicenseID = Convert.ToInt32(SelectedRow.Cells["LicenseID"].Value);

            frmDriverLicenseInfo FormDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            FormDriverLicenseInfo.ShowDialog();
        }

        private void ShowInternationalLicenseInfo_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dgvInternationalLicenses.SelectedRows[0];

            int InternationalLicenseID = Convert.ToInt32(SelectedRow.Cells["InternationalLicenseID"].Value);

            frmDriverInternationalLicenseInfo FormDriverInternationalLicenseInfo = new frmDriverInternationalLicenseInfo(InternationalLicenseID);
            FormDriverInternationalLicenseInfo.ShowDialog();
        }


    }
}
