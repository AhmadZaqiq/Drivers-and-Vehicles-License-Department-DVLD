using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

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

        public static string ComputeHash(string Password)
        {
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }

                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;

            FileInfo Fi = new FileInfo(FileName);

            return GenerateGUID() + Fi.Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = Path.Combine(Application.StartupPath, @"..\..\PersonalImages");

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string FestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, FestinationFile, true);
            }

            catch (IOException iox)
            {
                return false;
            }

            SourceFile = FestinationFile;

            return true;
        }


    }
}
