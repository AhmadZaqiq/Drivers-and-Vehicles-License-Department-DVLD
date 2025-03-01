using Drivers_and_Vehicles_License_Department__DVLD_.Application_Types;
using DVLD_Business;
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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        public event Action DataAdded;

        private int _TestTypeID = -1;

        private clsTestType _TestType;

        public frmUpdateTestType(int TestTypeID, frmManageTestType FormManageTestTypes)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;

            _TestType = clsTestType.GetTestTypeByID(_TestTypeID);

            this.DataAdded += FormManageTestTypes.RefreshTestTypesDataGrid;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _PopulateTestTypeFields();

            _MakeRoundedCorners(30); //to make the form rounded

            _OpenFormEffect();
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

        private void _PopulateTestTypeFields()
        {
            if (_TestType == null)
                return;

            lblID.Text = _TestTypeID.ToString();
            txtTestTypeTitle.Text = _TestType.TestTypeTitle.ToString();
            txtTestTypeDescription.Text = _TestType.TestTypeDescription.ToString();
            txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

        private bool _ValidateAndSetTestTypeData()
        {
            string TestTypeTitle = txtTestTypeTitle.Text.Trim();
            string TestTypeDescription = txtTestTypeDescription.Text.Trim();


            if (string.IsNullOrWhiteSpace(TestTypeTitle) || string.IsNullOrWhiteSpace(TestTypeDescription))
                return false;

            if (!decimal.TryParse(txtTestTypeFees.Text.Trim(), out decimal TestTypeFees) || TestTypeFees < 0)
                return false;

            _TestType.TestTypeTitle = TestTypeTitle;
            _TestType.TestTypeDescription = TestTypeDescription;
            _TestType.TestTypeFees = TestTypeFees;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateAndSetTestTypeData())
            {
                MessageBox.Show("Please make sure the entered values ​​are valid.", "Failed");
                return;
            }

            if (!_TestType.UpdateTestType())
            {
                MessageBox.Show("Data Not Saved.", "Failed");
                return;
            }

            MessageBox.Show("Test type updated successfully", "Success");
            DataAdded?.Invoke();
        }






    }
}
