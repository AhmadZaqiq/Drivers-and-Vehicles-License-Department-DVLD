using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Global
{
    public class clsUtil
    {
        private clsUtil() { }

        public static void MakeRoundedCorners(Form form, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcSize = borderRadius * 2;

            // Create rounded rectangle
            path.AddArc(new Rectangle(0, 0, arcSize, arcSize), 180, 90);
            path.AddArc(new Rectangle(form.Width - arcSize, 0, arcSize, arcSize), 270, 90);
            path.AddArc(new Rectangle(form.Width - arcSize, form.Height - arcSize, arcSize, arcSize), 0, 90);
            path.AddArc(new Rectangle(0, form.Height - arcSize, arcSize, arcSize), 90, 90);
            path.CloseFigure();

            // Apply region
            form.Region = new Region(path);
        }

        public static void OpenFormEffect(Form form)
        {
            int startY = form.Top - 50;
            form.Top = startY;
            form.Opacity = 0;

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (form.Opacity < 1) form.Opacity += 0.05;
                if (form.Top < startY + 50) form.Top += 2;
                else timer.Stop();
            };
            timer.Start();
        }

        public static void CloseFormEffect(Form form)
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (s, e) =>
            {
                if (form.Opacity > 0) form.Opacity -= 0.05;
                if (form.Width > 10) form.Width -= 20;
                if (form.Height > 10) form.Height -= 15;
                if (form.Opacity <= 0) { timer.Stop(); form.Close(); }
            };
            timer.Start();
        }

        public static string ValidGmailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

        public static string ValidPhonePattern = @"^\d{8,15}$";

        public static string ComputeHash(string Password)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }


    }
}
