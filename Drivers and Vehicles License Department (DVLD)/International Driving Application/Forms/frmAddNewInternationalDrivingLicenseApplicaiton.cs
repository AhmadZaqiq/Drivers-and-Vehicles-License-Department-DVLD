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

namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms
{
    public partial class frmAddNewInternationalDrivingLicenseApplicaiton : Form
    {
        public frmAddNewInternationalDrivingLicenseApplicaiton()
        {
            InitializeComponent();
        }

        private void frmAddNewInternationalDrivingLicenseApplicaiton_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

    }
}
