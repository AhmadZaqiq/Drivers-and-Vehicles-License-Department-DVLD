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
        public event Action DataAdded;

        private int _TestTypeID = -1;

        private clsTestType _TestType;

        public frmUpdateTestType(int TestTypeID, frmManageTestType FormManageTestTypes)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;

            _TestType = clsTestType.GetTestTypeByID(_TestTypeID);

            this.DataAdded += FormManageTestTypes.RefreshTestTypesDataGrid;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _PopulateTestTypeFields();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _PopulateTestTypeFields()
        {
            if (_TestType == null)
            {
                return;
            }

            lblID.Text = _TestTypeID.ToString();
            txtTestTypeTitle.Text = _TestType.TestTypeTitle.ToString();
            txtTestTypeDescription.Text = _TestType.TestTypeDescription.ToString();
            txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
        }

        private bool _ValidateAndSetTestTypeData()
        {
            string TestTypeTitle = txtTestTypeTitle.Text.Trim();
            string TestTypeDescription = txtTestTypeDescription.Text.Trim();


            if (string.IsNullOrWhiteSpace(TestTypeTitle) || string.IsNullOrWhiteSpace(TestTypeDescription))
            {
                return false;
            }

            if (!decimal.TryParse(txtTestTypeFees.Text.Trim(), out decimal TestTypeFees) || TestTypeFees < 0)
            {
                return false;
            }

            _TestType.TestTypeTitle = TestTypeTitle;
            _TestType.TestTypeDescription = TestTypeDescription;
            _TestType.TestTypeFees = TestTypeFees;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateAndSetTestTypeData())
            {
                clsMessageBoxManager.ShowMessageBox("Please make sure the entered values ​​are valid.", "Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (!_TestType.UpdateTestType())
            {
                clsMessageBoxManager.ShowMessageBox("Data Not Saved.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Test type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataAdded?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }


    }
}
