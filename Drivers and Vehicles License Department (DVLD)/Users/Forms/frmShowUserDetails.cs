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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms
{
    public partial class frmShowUserDetails : Form
    {
        private int _UserID = 0;

        public frmShowUserDetails(int UserID)
        {
            InitializeComponent();

            this._UserID = UserID;
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserDetails1.UserID = _UserID;

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }
    }
}
