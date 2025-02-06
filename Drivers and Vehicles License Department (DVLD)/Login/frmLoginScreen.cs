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
            _LoadValuesFromFile();
        }

        static string FileName = "UserSession.txt";

        private void _SaveUserSession()
        {
            if (chkRememberMe.Checked)
            {
                _SaveValuesOnFile(txtUsername.Text, txtPassword.Text);
            }

            else
            {
                _SaveValuesOnFile("", "");
            }
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
        }

        private void CheckCredentials()
        {
            if (!(_CheckIfUserExists()) || (_User = clsUser.GetUserByUsername(txtUsername.Text.Trim())).Password != txtPassword.Text)
            {
                MessageBox.Show("Invalid Username/Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User.IsActive == true)
            {
                _SaveUserSession();
                LoginUser(_User);
            }

            else
            {
                MessageBox.Show("Your account is inactive please contact the admin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckCredentials();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                btnShowHidePassword.Visible = false;
            }

            else
            {
                btnShowHidePassword.Visible = true;
            }

        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnShowHidePassword.Text = "Hide Password";
                txtPassword.PasswordChar = '\0';
            }

            else
            {
                btnShowHidePassword.Text = "Show Password";
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
