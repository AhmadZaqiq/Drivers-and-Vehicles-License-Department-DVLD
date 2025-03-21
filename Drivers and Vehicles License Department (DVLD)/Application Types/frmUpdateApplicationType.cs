﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using DVLD_Business;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Application_Types
{
    public partial class frmUpdateApplicationType : Form
    {
        public event Action DataAdded;

        private int _ApplicationTypeID = -1;

        private clsApplicationType _ApplicationType;

        public frmUpdateApplicationType(int ApplicationTypeID, frmManageApplicationTypes FormManageApplicationTypes)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;

            _ApplicationType = clsApplicationType.GetApplicationTypeByID(_ApplicationTypeID);

            this.DataAdded += FormManageApplicationTypes.RefreshApplicationTypesDataGrid;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _PopulateApplicationTypeFields();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _PopulateApplicationTypeFields()
        {
            if (_ApplicationType == null)
            {
                return;
            }

            lblID.Text = _ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
            txtApplicationTypeFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }

        private bool _ValidateAndSetApplicationTypeData()
        {
            string ApplicationTypeTitle = txtApplicationTypeTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(ApplicationTypeTitle))
            {
                return false;
            }

            if (!decimal.TryParse(txtApplicationTypeFees.Text.Trim(), out decimal ApplicationTypeFees) || ApplicationTypeFees < 0)
            {
                return false;
            }

            _ApplicationType.ApplicationTypeTitle = ApplicationTypeTitle;
            _ApplicationType.ApplicationTypeFees = ApplicationTypeFees;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateAndSetApplicationTypeData())
            {
                clsMessageBoxManager.ShowMessageBox("Please make sure the entered values ​​are valid.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_ApplicationType.UpdateApplicationType())
            {
                clsMessageBoxManager.ShowMessageBox("Data Not Saved.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Application type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
