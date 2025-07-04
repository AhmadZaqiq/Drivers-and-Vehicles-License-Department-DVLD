using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Appointments.Forms;
using DVLD_Business;
using SiticoneNetFrameworkUI.Helpers.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsTestType;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Tests.Forms
{
    public partial class frmScheduleTest : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        public void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;

            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
