using Drivers_and_Vehicles_License_Department__DVLD_.Applications.Controls;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmIssueDrivingLicense : Form
    {
        private int _LocalDrivingApplicationID = -1;


        public frmIssueDrivingLicense(int LocalDrivingApplicationID)
        {
            InitializeComponent();

            this._LocalDrivingApplicationID = LocalDrivingApplicationID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingApplicationCard1.LocalDrivingApplicationID = _LocalDrivingApplicationID;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
