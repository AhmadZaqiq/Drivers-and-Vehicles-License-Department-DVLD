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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            RefreshTestTypesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        public void RefreshTestTypesDataGrid()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();

            _UpdateTestTypesCount();
        }

        private void _UpdateTestTypesCount()
        {
            lblRecordsCount.Text = (dgvTestTypes.RowCount).ToString();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void EditTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestTypes.SelectedRows[0];

            int TestTypeID = Convert.ToInt32(selectedRow.Cells["TestTypeID"].Value);

            frmUpdateTestType FormUpdateTestType = new frmUpdateTestType(TestTypeID, this);
            FormUpdateTestType.ShowDialog();
        }


    }
}
