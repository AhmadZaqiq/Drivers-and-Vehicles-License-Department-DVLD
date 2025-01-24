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

            lblRecordsCount.Text = clsPeople.GetPeopleCount().ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                dgvPeople.DataSource = clsPeople.GetAllPeople();
            }
            else
            {
                DataView dv = new DataView(clsPeople.GetAllPeople());
                dv.RowFilter = $"CONVERT([{filterColumn}], System.String) LIKE '{SearchText}%'";
                dgvPeople.DataSource = dv;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;

            }

            if (cbFilter.SelectedItem.ToString() == "PersonID" || cbFilter.SelectedItem.ToString() == "DateOfBirth" || cbFilter.SelectedItem.ToString() == "Phone")
            {
                txtFilter.Mask = "0000000000";
                txtFilter.PromptChar = ' ';
            }

            else
            {
                txtFilter.Mask = "";
            }

            txtFilter.Focus();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople();
            frmAddAndUpdatePeople.ShowDialog();
        }
    }
}
