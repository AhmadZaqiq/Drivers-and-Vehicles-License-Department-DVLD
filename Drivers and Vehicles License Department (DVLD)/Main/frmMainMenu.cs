using Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmMainMenu : Form
    {
        private clsUser _CurrentUser = new clsUser();

        public frmMainMenu(clsUser CurrentUser)
        {
            InitializeComponent();

            _CurrentUser = CurrentUser;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frmPeople = new frmPeople();
            frmPeople.ShowDialog();
        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUsersForm = new frmManageUsers();
            ManageUsersForm.ShowDialog();
        }

    }
}
