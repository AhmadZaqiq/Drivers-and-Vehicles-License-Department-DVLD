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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshApplicationTypesDataGrid();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        public void RefreshApplicationTypesDataGrid()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();

            _UpdateApplicationTypesCount();
        }

        private void _UpdateApplicationTypesCount()
        {
            lblRecordsCount.Text = (dgvApplicationTypes.RowCount).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }

        private void EditApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvApplicationTypes.SelectedRows[0];

            int ApplicationTypeID = Convert.ToInt32(selectedRow.Cells["ApplicationTypeID"].Value);

            frmUpdateApplicationType FormUpdateApplicationType = new frmUpdateApplicationType(ApplicationTypeID, this);
            FormUpdateApplicationType.ShowDialog();
        }
    }
}
