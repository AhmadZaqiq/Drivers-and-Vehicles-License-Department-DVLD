using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Test_Types
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes = clsTestType.GetAllTestTypes();

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _UpdateTestTypesCount()
        {
            lblRecordsCount.Text = (dgvTestTypes.RowCount).ToString();
        }

        private void _RefreshTestTypesDataGrid()
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();

            dgvTestTypes.DataSource = _dtAllTestTypes;

            _UpdateTestTypesCount();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void EditTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = ((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);

            frmUpdateTestType FormUpdateTestType = new frmUpdateTestType(TestTypeID);
            FormUpdateTestType.ShowDialog();

            _RefreshTestTypesDataGrid();
        }


    }
}
