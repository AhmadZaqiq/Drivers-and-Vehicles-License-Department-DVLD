using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Application_Types
{
    public partial class frmUpdateApplicationType : Form
    {
        public event Action DataAdded;

        private int _ApplicationTypeID = -1;

        private clsApplicationTypes _ApplicationType;

        public frmUpdateApplicationType(int applicationTypeID, frmManageApplicationTypes FormManageApplicationTypes)
        {
            InitializeComponent();

            _ApplicationTypeID = applicationTypeID;

            _ApplicationType = clsApplicationTypes.GetApplicationByID(_ApplicationTypeID);

            this.DataAdded += FormManageApplicationTypes.RefreshApplicationTypesDataGrid;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _PopulateApplicationTypeFields();

            _MakeRoundedCorners(30); //to make the form rounded

            _OpenFormEffect();
        }

        private void _PopulateApplicationTypeFields()
        {
            if (_ApplicationType == null)
                return;

            lblID.Text = _ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
            txtApplicationTypeFee.Text = _ApplicationType.ApplicationTypeFees.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

        private bool _ValidateAndSetApplicationTypeData()
        {
            string applicationTypeTitle = txtApplicationTypeTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(applicationTypeTitle))
                return false;

            if (!decimal.TryParse(txtApplicationTypeFee.Text.Trim(), out decimal applicationTypeFees) || applicationTypeFees < 0)
                return false;

            _ApplicationType.ApplicationTypeTitle = applicationTypeTitle;
            _ApplicationType.ApplicationTypeFees = applicationTypeFees;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateAndSetApplicationTypeData())
            {
                MessageBox.Show("Please make sure the entered values ​​are valid.", "Failed");
                return;
            }

            if (!_ApplicationType.UpdateApplicationType())
            {
                MessageBox.Show("Data Not Saved.", "Failed");
                return;
            }

            MessageBox.Show("Application type updated successfully", "Success");
            DataAdded?.Invoke();
        }











    }
}
