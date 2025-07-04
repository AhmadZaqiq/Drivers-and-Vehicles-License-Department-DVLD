using System;
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
        private int _ApplicationTypeID = -1;

        private clsApplicationType _ApplicationType;

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.GetApplicationTypeByID(_ApplicationTypeID);

            _FillApplicationTypeInfo();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _FillApplicationTypeInfo()
        {
            if (_ApplicationType == null)
            {
                return;
            }

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.Title.ToString();
            txtApplicationTypeFees.Text = _ApplicationType.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Calls validation on all child controls to ensure user input is valid before proceeding.
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Please make sure the entered values ​​are valid.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _ApplicationType.Title = txtApplicationTypeTitle.Text.Trim();
            _ApplicationType.Fees = decimal.Parse(txtApplicationTypeFees.Text.Trim());

            if (!_ApplicationType.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data Not Saved.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Application type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtApplicationTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtApplicationTypeFees.Text.Trim(), out decimal fees) || fees < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeFees, "Please enter a valid non-negative number for the fees.");
                return;
            }

            errorProvider1.SetError(txtApplicationTypeFees, null);
        }

        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApplicationTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationTypeTitle, "Title is required.");
                return;
            }

            errorProvider1.SetError(txtApplicationTypeTitle, null);
        }


    }
}
