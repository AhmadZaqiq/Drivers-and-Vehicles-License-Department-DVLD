using Drivers_and_Vehicles_License_Department__DVLD_.Global;
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
        public delegate void DataBackEventHandler(object sender, int PersonID);

        private frmListPeople _PeopleForm;

        public frmAddAndUpdatePeople(int PersonID = -1, frmListPeople PeopleForm = null)
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
            clsFormUtil.MakeRoundedCorners(this, 30); //to make the form rounded

            clsFormUtil.OpenFormEffect(this);
        }

        private void _SetPersonID(int PersonID)
        {
            lblPersonID.Text = (PersonID == -1) ? "N/A" : PersonID.ToString();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            clsFormUtil.CloseFormEffect(this);
        }
    }
}
