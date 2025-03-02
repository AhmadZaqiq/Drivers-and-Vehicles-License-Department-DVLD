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

        static string FileName = "UserSession.txt";

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadValuesFromFile();

            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
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
            File.WriteAllText(FileName, Data);
        }

        private void _LoadValuesFromFile()
        {
            if (File.Exists(FileName))
            {
                string Data = File.ReadAllText(FileName);

                string[] Parts = Data.Split(new string[] { "#%%#" }, StringSplitOptions.None);

                if (Parts.Length == 2)
                {
                    txtUsername.Text = Parts[0];
                    txtPassword.Text = Parts[1];
                }
            }
        }

        private void _LoginUser(clsUser CurrentUser)
        {
            frmMainMenu FormMainMenu = new frmMainMenu(CurrentUser);
            FormMainMenu.ShowDialog();
        }

        private void _CheckCredentials()
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text;
            _User = clsUser.GetUserByUsername(Username);

            if (_User == null || (_User.Password != Password))
            {
                MessageBox.Show("Invalid Username/Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_User.IsActive)
            {
                MessageBox.Show("Your account is inactive please contact the admin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveUserSession();
            _LoginUser(_User);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
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
            _CheckCredentials();
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
