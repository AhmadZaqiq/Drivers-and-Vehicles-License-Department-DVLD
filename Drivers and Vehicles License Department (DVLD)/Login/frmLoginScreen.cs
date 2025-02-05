using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Login
{
    public partial class frmLoginScreen : Form
    {

        private clsUser _User = new clsUser();
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pbFacebook_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/ahmad0599132052",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void pbLinkedin_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/ahmadzaqiq/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void pbInstagram_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/4.ahmad_awad.4/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private bool _CheckIfUserExists()
        {
            return clsUser.IsUserExists(txtUsername.Text);
        }

        private void LoginUser(clsUser CurrentUser)
        {
            frmMainMenu MainMenuForm = new frmMainMenu(CurrentUser);
            MainMenuForm.ShowDialog();

            this.Close();
        }

        private void CheckCredentials()
        {
            if (!(_CheckIfUserExists()) || (_User = clsUser.GetUserByUsername(txtUsername.Text.Trim())).Password != txtPassword.Text)
            {
                MessageBox.Show("Invalid Username/Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                LoginUser(_User);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckCredentials();
        }

    }
}
