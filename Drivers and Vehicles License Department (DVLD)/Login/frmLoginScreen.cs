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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Login
{
    public partial class frmLoginScreen : Form
    {

        private clsUser _User;

        static string FileName = "UserSession.txt";

        public frmLoginScreen()
        {
            InitializeComponent();

            _MakeRoundedCorners(30); //to make the form rounded
        }

        private void _MakeRoundedCorners(int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcSize = borderRadius * 2;

            // Create rounded rectangle
            path.AddArc(new Rectangle(0, 0, arcSize, arcSize), 180, 90);
            path.AddArc(new Rectangle(Width - arcSize, 0, arcSize, arcSize), 270, 90);
            path.AddArc(new Rectangle(Width - arcSize, Height - arcSize, arcSize, arcSize), 0, 90);
            path.AddArc(new Rectangle(0, Height - arcSize, arcSize, arcSize), 90, 90);
            path.CloseFigure();

            // Apply region
            this.Region = new Region(path);
        }

        private void _OpenFormEffect()
        {
            int startY = this.Top - 50;
            this.Top = startY;
            this.Opacity = 0;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                if (this.Top < startY + 50) this.Top += 2;
                else timer.Stop();
            };
            timer.Start();
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

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadValuesFromFile();

            _OpenFormEffect();
        }

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
            _CloseFormEffect();
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
