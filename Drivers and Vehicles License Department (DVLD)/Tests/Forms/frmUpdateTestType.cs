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
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.GetTestTypeByID(_TestTypeID);

            _PopulateTestTypeFields();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _PopulateTestTypeFields()
        {
            if (_TestType == null)
            {
                return;
            }

            lblID.Text = _TestTypeID.ToString();
            txtTestTypeTitle.Text = _TestType.Title.ToString();
            txtTestTypeDescription.Text = _TestType.Description.ToString();
            txtTestTypeFees.Text = _TestType.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Calls validation on all child controls to ensure user input is valid before proceeding.
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Please make sure the entered values ​​are valid.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtTestTypeTitle.Text.Trim();
            _TestType.Description = txtTestTypeDescription.Text.Trim();
            _TestType.Fees = decimal.Parse(txtTestTypeFees.Text.Trim());

            if (!_TestType.Save())
            {
                clsMessageBoxManager.ShowMessageBox("Data Not Saved.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Test type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "Title is required.");
                return;
            }

            errorProvider1.SetError(txtTestTypeTitle, null);
        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtTestTypeFees.Text.Trim(), out decimal fees) || fees < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Please enter a valid non-negative number for the fees.");
                return;
            }

            errorProvider1.SetError(txtTestTypeFees, null);
        }


    }
}
