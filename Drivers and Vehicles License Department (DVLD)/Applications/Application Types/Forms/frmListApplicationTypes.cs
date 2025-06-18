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
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes= clsApplicationType.GetAllApplicationTypes();

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshApplicationTypesDataGrid();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        public void RefreshApplicationTypesDataGrid()
        {
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;

            _UpdateApplicationTypesCount();
        }

        private void _UpdateApplicationTypesCount()
        {
            lblRecordsCount.Text = (dgvApplicationTypes.RowCount).ToString();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void EditApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = ((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);

            frmUpdateApplicationType FormUpdateApplicationType = new frmUpdateApplicationType(ApplicationTypeID);
            FormUpdateApplicationType.ShowDialog();

            RefreshApplicationTypesDataGrid();
        }


    }
}
