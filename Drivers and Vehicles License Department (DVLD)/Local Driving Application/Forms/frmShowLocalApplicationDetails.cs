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
        private int _LocalDrivingLicenseApplicationID = -1;

        public frmShowLocalApplicationDetails(int LocalDrivingApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID=LocalDrivingApplicationID;
        }

        private void ShowLocalApplicationDetails_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);

            ctrlLocalDrivingApplicationCard1.LocalDrivingApplicationID = _LocalDrivingLicenseApplicationID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
