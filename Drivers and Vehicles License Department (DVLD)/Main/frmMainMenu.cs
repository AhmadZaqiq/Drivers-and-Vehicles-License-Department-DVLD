using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using Drivers_and_Vehicles_License_Department__DVLD_.Test_Types;
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
        private clsUser _CurrentUser;

        public frmMainMenu(clsUser CurrentUser)
        {
            InitializeComponent();

            _CurrentUser = CurrentUser;
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void _CloseFormEffect()
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (this.Opacity > 0) this.Opacity -= 0.05;
                if (this.Width > 10) this.Width -= 20;
                if (this.Height > 10) this.Height -= 15;
                if (this.Opacity <= 0) { timer.Stop(); this.Close(); }
            };
            timer.Start();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frmPeople = new frmPeople();
            frmPeople.ShowDialog();
        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUsersForm = new frmManageUsers();
            ManageUsersForm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails FormShowUserDetails = new frmShowUserDetails(_CurrentUser.UserID);
            FormShowUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUsername FormChangePassword = new frmUpdateUsername(_CurrentUser.UserID, true, null);
            FormChangePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes FormManageApplicationTypes = new frmManageApplicationTypes();
            FormManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestType FormManageTestTypes = new frmManageTestType();
            FormManageTestTypes.ShowDialog();
        }
    }
}
