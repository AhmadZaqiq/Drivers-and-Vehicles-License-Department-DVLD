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
using System.IO;
using System.Drawing.Drawing2D;
using Drivers_and_Vehicles_License_Department__DVLD_.Properties;
using Drivers_and_Vehicles_License_Department__DVLD_.Global;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Login
{
    public partial class frmLoginScreen : Form
    {

        private clsUser _User;

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _GetStoredCredentials();

            clsUtil.MakeRoundedCorners(this, 30);

            clsUtil.OpenFormEffect(this);
        }

        private void _GetStoredCredentials()
        {
            string Username = "", Password = "";

            clsUtil.LoadValuesFromFile(ref Username, ref Password);
            txtUsername.Text = Username;
            txtPassword.Text = Password;
        }

        private bool _CheckCredentials()
        {
            string Username = txtUsername.Text.Trim();
            string passwordHash = clsUtil.ComputeHash(txtPassword.Text);

            _User = clsUser.FindByUsernameAndPassword(Username, passwordHash);

            if (_User == null)
            {
                clsMessageBoxManager.ShowMessageBox("Invalid Username/Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_User.IsActive)
            {
                clsMessageBoxManager.ShowMessageBox("Your account is inactive please contact the admin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void _StoreCredentials()
        {
            // ⚠ WARNING: This example is for demonstration and educational purposes only.
            // Storing plaintext passwords or even hashes in a file is insecure and not recommended in real applications.
            // This implementation is intended to illustrate the basic idea of storing user credentials.

            if (!chkRememberMe.Checked)
            {
                clsUtil.SaveValuesOnFile("", "");
                return;
            }

            clsUtil.SaveValuesOnFile(txtUsername.Text, txtPassword.Text);
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/ahmad0599132052",
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void btnLinkedin_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/ahmadzaqiq/",
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/4.ahmad_awad.4/",
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!_CheckCredentials())
            {
                return;
            }

            _StoreCredentials();
            clsCurrentUser.CurrentUser = _User;

            frmMainMenu FormMainMenu = new frmMainMenu();
            FormMainMenu.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsUtil.CloseFormEffect(this);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnShowHidePassword.Visible = !String.IsNullOrEmpty(txtPassword.Text);
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            bool IsHidden = txtPassword.UseSystemPasswordChar;

            txtPassword.UseSystemPasswordChar = !IsHidden;
            btnShowHidePassword.BackgroundImage = IsHidden ? Resources.eye_46_512 : Resources.eye_50_512;
        }


    }
}
