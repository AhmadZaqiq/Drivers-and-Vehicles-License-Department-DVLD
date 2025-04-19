using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    public partial class ctrlLicenseCardWithFilter : UserControl
    {
        private int _LicenseID = -1;

        public ctrlLicenseCardWithFilter()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((txtFilter.Text)))
            {
                return;
            }

            _LicenseID = Convert.ToInt32(txtFilter.Text.Trim());

            if (!clsLicense.IsLicenseExists(_LicenseID))
            {
                clsMessageBoxManager.ShowMessageBox($"There is No License with ID: {_LicenseID}",
                                                     "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ctrlLicenseCard1.LicenseID = -1;

                return;
            }

            ctrlLicenseCard1.LicenseID = _LicenseID;
        }

    }
}
