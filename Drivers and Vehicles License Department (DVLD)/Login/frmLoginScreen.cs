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

        static string UserSessionFileName = "UserSession.txt";

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadValuesFromFile();

            clsUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsUtil.OpenFormEffect(this);
        }

        private void _SaveUserSession()
        {
            if (!chkRememberMe.Checked)
            {
                _SaveValuesOnFile("", "");
                return;
            }

            _SaveValuesOnFile(txtUsername.Text, txtPassword.Text);
        }

        private void _SaveValuesOnFile(string Username, string Password)
        {
            string Data = Username + "#%%#" + Password;
            File.WriteAllText(UserSessionFileName, Data);
        }

        private void _LoadValuesFromFile()
        {
            if (!File.Exists(UserSessionFileName))
            {
                return;
            }

            string data = File.ReadAllText(UserSessionFileName);
            string[] parts = data.Split(new string[] { "#%%#" }, StringSplitOptions.None);

            if (parts.Length != 2)
            {
                return;
            }

            txtUsername.Text = parts[0];
            txtPassword.Text = parts[1];
        }

        private bool _CheckCredentials()
        {
            string Username = txtUsername.Text.Trim();
            string Password = clsUtil.ComputeHash(txtPassword.Text);
            _User = clsUser.GetUserByUsername(Username);

            if (_User == null || (_User.Password != Password))
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

            _SaveUserSession();
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
