using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.Tests.Controls;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Tests.Forms
{
    public partial class frmTakeTest : Form
    {
        private clsTestType.enTestType _TestType;

        private clsTest _Test;

        private int _TestID = -1;

        private int _TestAppointmentID = -1;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
        }

        public void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestType;
            ctrlScheduledTest1.LoadScheduledTestInfo(_TestAppointmentID);

            btnSave.Enabled = ctrlScheduledTest1.TestAppointmentID != -1;

            int TestID = ctrlScheduledTest1.TestID;

            _Test = (TestID != -1) ? clsTest.GetTestByID(TestID) : new clsTest();

            if (TestID != -1 && _Test != null)
            {
                rbPass.Checked = _Test.Result;
                rbFail.Checked = !_Test.Result;
                txtNotes.Text = _Test.Notes;

                rbPass.Enabled = false;
                rbFail.Enabled = false;
            }

            else
            {
                rbPass.Checked = true;
            }

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _LoadTestData()
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.Result = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsCurrentUser.CurrentUser.ID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsMessageBoxManager.ShowConfirmActionBox("Are you sure you want to save? You will not be able to change the result afterward",
                                                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            _LoadTestData();

            if (!_Test.Save())
            {
                clsMessageBoxManager.ShowMessageBox("An error occurred while saving the data. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                return;
            }

            clsMessageBoxManager.ShowMessageBox("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
