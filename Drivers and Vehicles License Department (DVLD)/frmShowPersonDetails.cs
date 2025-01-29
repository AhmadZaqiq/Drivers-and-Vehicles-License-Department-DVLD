using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmShowPersonDetails : Form
    {
        private int _PersonID = 0;

        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlShowPersonDetails1.PersonID = _PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
