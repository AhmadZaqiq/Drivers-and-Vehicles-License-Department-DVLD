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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmLicensesHistory : Form
    {
        private int _DriverID;

        private int _PersonID;
        public frmLicensesHistory(int DriverID,int PersonID)
        {
            InitializeComponent();

            _DriverID = DriverID;

            _PersonID = PersonID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.PersonID= _PersonID;

            _RefreshLocalDrivingApplicationsDataGrid();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _UpdateLocalLicensesCount()
        {
            lblRecordsCount.Text = (dgvLocalLicenses.RowCount).ToString();
        }

        private void _RefreshLocalDrivingApplicationsDataGrid()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetAllLicensesForDriver(_DriverID);

            _UpdateLocalLicensesCount();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }
    }
}
