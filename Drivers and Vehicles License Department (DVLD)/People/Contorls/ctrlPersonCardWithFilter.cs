using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.People.Contorls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private int _PersonID=-1;

        private frmListPeople _frmPeople = new frmListPeople();

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("NationalNO.");
            cbFilter.Items.Add("PersonID");

            cbFilter.SelectedIndex = 0;
        }

        private void _GetPersonDetailsByID()
        {
            if (String.IsNullOrEmpty((txtFilter.Text)))
                return;

            _PersonID = Convert.ToInt32(txtFilter.Text.Trim());

            if (!clsPerson.IsPersonExists(_PersonID))
            {
                MessageBox.Show($"There is No Person with ID: {_PersonID}",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ctrlShowPersonDetails1.PersonID = -1;

                return;
            }

            ctrlShowPersonDetails1.PersonID = _PersonID;
        }

        private void _GetPersonDetailsByNationalNo()
        {
            if (String.IsNullOrEmpty((txtFilter.Text)))
                return;

            string NationalNo = txtFilter.Text.Trim();

            if (!clsPerson.IsPersonExists(NationalNo))
            {
                MessageBox.Show($"There is No Person with NationalNo: {NationalNo}",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ctrlShowPersonDetails1.PersonID = -1;

                return;
            }

            _PersonID = clsPerson.GetPersonIDByNationalNO(NationalNo);
            ctrlShowPersonDetails1.PersonID = _PersonID;
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            string SelectedFilter = cbFilter.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "PersonID":
                    _GetPersonDetailsByID();
                    break;

                case "NationalNO.":
                    _GetPersonDetailsByNationalNo();
                    break;

                default:
                    MessageBox.Show("Invalid filter selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
            }

            else
            {
                txtFilter.Visible = true;
            }


            if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                txtFilter.Mask = "0000000000";
                txtFilter.PromptChar = ' ';
            }

            else
            {
                txtFilter.Mask = "";
            }

            txtFilter.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople AddNewPersonForm = new frmAddAndUpdatePeople(-1, _frmPeople);
            AddNewPersonForm.ShowDialog();
        }




















    }
}
