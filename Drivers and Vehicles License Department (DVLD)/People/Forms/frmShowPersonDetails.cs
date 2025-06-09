using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmShowPersonDetails : Form
    {

        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();

            ctrlPersonDetails1.LoadPersonInfo(PersonID);
        }

        public frmShowPersonDetails(string NationalNo)
        {
            InitializeComponent();

            ctrlPersonDetails1.LoadPersonInfo(NationalNo);
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
