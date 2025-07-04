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
    public partial class frmDriverInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID;

        public frmDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseCard1.LoadInternationalLicenseInfo(_InternationalLicenseID);

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
