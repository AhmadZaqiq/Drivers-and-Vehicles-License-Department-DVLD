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

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            DataTable peopleTable = clsPeople.GetAllPeople();

            dgvPeople.DataSource = peopleTable;

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn column in peopleTable.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _FillDataGridOfPeople()
        {
            dgvPeople.DataSource = clsPeople.GetAllPeople();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _FillDataGridOfPeople();

            _FillComboBox();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex==0)
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }
        }

    }
}
