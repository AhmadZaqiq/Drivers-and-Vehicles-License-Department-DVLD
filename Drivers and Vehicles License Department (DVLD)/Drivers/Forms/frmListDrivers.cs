﻿using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Drivers.Forms
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtAllDrivers;

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversDataGrid();

            _FillDriversFilterComboBox();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _FillDriversFilterComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("DriverID");
            cbFilter.Items.Add("PersonID");
            cbFilter.Items.Add("NationalNO");
            cbFilter.Items.Add("FullName");

            cbFilter.SelectedIndex = 0;
        }

        private void _UpdateDriversCount()
        {
            lblRecordsCount.Text = (dgvDrivers.RowCount).ToString();
        }

        private void _RefreshDriversDataGrid()
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();

            dgvDrivers.DataSource = _dtAllDrivers;

            _UpdateDriversCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            string SearchText = txtFilter.Text;

            if (string.IsNullOrEmpty(SearchText))
            {
                _RefreshDriversDataGrid(); // Return the complete data in the table after clearing the search box.
                return;
            }

            DataView dv = new DataView(_dtAllDrivers);
            dv.RowFilter = $"CONVERT([{FilterColumn}], System.String) LIKE '{SearchText}%'";
            dgvDrivers.DataSource = dv;

            _UpdateDriversCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.SelectedItem.ToString();
            txtFilter.Visible = (FilterColumn != "None");

            if (FilterColumn != "DriverID" && FilterColumn != "PersonID")
            {
                txtFilter.Mask = "";
                return;
            }

            txtFilter.Mask = "00000000000000000000";
            txtFilter.PromptChar = ' ';
            txtFilter.Focus();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ShowPersonlicenseHistoryStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

            frmLicensesHistory FormLicensesHistory = new frmLicensesHistory(PersonID);
            FormLicensesHistory.ShowDialog();
        }


    }
}
