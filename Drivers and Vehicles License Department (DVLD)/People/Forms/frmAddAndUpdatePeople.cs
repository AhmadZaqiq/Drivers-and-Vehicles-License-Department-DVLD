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

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class frmAddAndUpdatePeople : Form
    {
        private frmPeople _PeopleForm;

        public frmAddAndUpdatePeople(int PersonID = -1, frmPeople PeopleForm=null)
        {
            InitializeComponent();

            ctrlAddNewPerson1.PersonID = PersonID;

            lblTitle.Text = ctrlAddNewPerson1.Mode;

            _SetPersonID(PersonID);
            _PeopleForm = PeopleForm;
            ctrlAddNewPerson1.DataAdded += _PeopleForm.RefreshPeopleDataGrid;
        }

        private void frmAddAndUpdatePeople_Load(object sender, EventArgs e)
        {
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

        private void _SetPersonID(int PersonID)
        {
            lblPersonID.Text = (PersonID == -1) ? "N/A" : PersonID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _CloseFormEffect();
        }

    }
}
