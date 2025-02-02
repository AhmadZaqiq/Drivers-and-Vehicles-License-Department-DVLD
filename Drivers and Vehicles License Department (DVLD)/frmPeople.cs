using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            DataTable peopleTable = clsPerson.GetAllPeople();

            dgvPeople.DataSource = peopleTable;

            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");

            foreach (DataColumn column in peopleTable.Columns)
            {
                cbFilter.Items.Add(column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _RefreshPeopleDataGrid()
        {
            dgvPeople.DataSource = clsPerson.GetAllPeople();
        }

        private void _UpdatePeopleCount()
        {
            //   lblRecordsCount.Text = clsPerson.GetPeopleCount().ToString();

            lblRecordsCount.Text = (dgvPeople.RowCount).ToString();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleDataGrid();

            _FillComboBox();

            _UpdatePeopleCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                _RefreshPeopleDataGrid(); // Return the complete data in the table after clearing the search box.

                _UpdatePeopleCount();
            }
            else
            {
                DataView dv = new DataView(clsPerson.GetAllPeople());
                dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
                dgvPeople.DataSource = dv;

                _UpdatePeopleCount();
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
            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(-1);
            frmAddAndUpdatePeople.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            if (selectedRow.Cells["PersonID"].Value != DBNull.Value && selectedRow.Cells["PersonID"].Value != null)
            {
                int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

                frmShowPersonDetails frmShowPersonDetails = new frmShowPersonDetails(PersonID);
                frmShowPersonDetails.ShowDialog();
            }

            else
            {
                MessageBox.Show("The specified row does not contain a value! ");
            }
        }

        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(-1);
            frmAddAndUpdatePeople.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            if (selectedRow.Cells["PersonID"].Value != DBNull.Value && selectedRow.Cells["PersonID"].Value != null)
            {
                int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);

                frmAddAndUpdatePeople frmAddAndUpdatePeople = new frmAddAndUpdatePeople(PersonID);
                frmAddAndUpdatePeople.ShowDialog();
            }

            else
            {
                MessageBox.Show("No Records Here...", "Error");
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            if (MessageBox.Show("Are You Sure you want to delete this Person?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(Convert.ToInt32(selectedRow.Cells["PersonID"].Value)))
                {
                    MessageBox.Show("Person deleted successfully.", "Done");

                    _RefreshPeopleDataGrid();

                    _UpdatePeopleCount();
                }

                else
                {
                    MessageBox.Show("Person was not deleted because it is linked to other transactions in the system...", "Alert");
                }
            }
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon... (;", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];

            string emailAddress = selectedRow.Cells["Email"].Value.ToString();

            string mailtoLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={emailAddress}";

            Process.Start(new ProcessStartInfo(mailtoLink) { UseShellExecute = true });
        }


    }
}

