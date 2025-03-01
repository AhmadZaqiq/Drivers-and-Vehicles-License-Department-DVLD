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
    public partial class frmManageTestType : Form
    {
        public frmManageTestType()
        {
            InitializeComponent();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            RefreshTestTypesDataGrid();

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

        public void RefreshTestTypesDataGrid()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();

            _UpdateTestTypesCount();
        }

        private void _UpdateTestTypesCount()
        {
            lblRecordsCount.Text = (dgvTestTypes.RowCount).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvTestTypes.SelectedRows[0];

            int TestTypeID = Convert.ToInt32(selectedRow.Cells["TestTypeID"].Value);

            frmUpdateTestType FormUpdateTestType = new frmUpdateTestType(TestTypeID, this);
            FormUpdateTestType.ShowDialog();
        }
    }
}
