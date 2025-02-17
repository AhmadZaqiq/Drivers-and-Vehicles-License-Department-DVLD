﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void _SetPersonID(int PersonID)
        {
            lblPersonID.Text = (PersonID == -1) ? "N/A" : PersonID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
