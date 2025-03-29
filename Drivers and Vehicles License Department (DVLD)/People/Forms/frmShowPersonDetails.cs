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
        private int _PersonID = -1;

        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();

            this._PersonID = PersonID;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.PersonID = _PersonID;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }


    }
}
