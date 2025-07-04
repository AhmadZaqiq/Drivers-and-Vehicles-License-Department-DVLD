using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Local_Driving_Application.Forms
{
    public partial class frmShowLocalApplicationDetails : Form
    {
        private int _LocalDrivingLicenseApplicationID;

        public frmShowLocalApplicationDetails(int LocalDrivingApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID=LocalDrivingApplicationID;
        }

        private void ShowLocalApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingApplicationCard1.LoadApplicationInfoByApplicationID(_LocalDrivingLicenseApplicationID);

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
