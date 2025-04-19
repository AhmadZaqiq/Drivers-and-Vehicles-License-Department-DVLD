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
    public partial class frmDriverLicenseInfo : Form
    {
        private int _LicenseID;

        public frmDriverLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseCard1.LicenseID = _LicenseID;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
