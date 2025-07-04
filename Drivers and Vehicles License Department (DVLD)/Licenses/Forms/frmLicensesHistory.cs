using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Forms;
using Drivers_and_Vehicles_License_Department__DVLD_.People.Contorls;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Forms
{
    public partial class frmLicensesHistory : Form
    {
        private int _PersonID = -1;

        public frmLicensesHistory()
        {
            InitializeComponent();
        }

        public frmLicensesHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            _LoadPersonDataIfExists();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _LoadPersonDataIfExists()
        {
            if (_PersonID == -1)
            {
                ctrlPersonCardWithFilter1.Enabled = true;
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
            {
                return;
            }

            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }


    }
}
