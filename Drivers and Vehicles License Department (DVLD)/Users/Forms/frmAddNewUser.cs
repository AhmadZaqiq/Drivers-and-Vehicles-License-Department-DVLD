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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Forms
{
    public partial class frmAddNewUser : Form
    {

        private frmPeople _frmPeople = new frmPeople();

        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("NationalNO.");
            cbFilter.Items.Add("PersonID");

            cbFilter.SelectedIndex = 0;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople AddNewPersonForm = new frmAddAndUpdatePeople(-1, _frmPeople);
            AddNewPersonForm.ShowDialog();
        }

        private void _GetPersonDetailsByID()
        {
            if (!String.IsNullOrEmpty((txtFilter.Text)))
            {

                int PersonID = Convert.ToInt32(txtFilter.Text.Trim());

                if (clsPerson.IsPersonExists(PersonID))
                {
                    ctrlShowPersonDetails1.PersonID = PersonID;
                    btnNext.Enabled = true;
                }

                else
                {
                    MessageBox.Show($"There is No Person with ID: {PersonID}",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ctrlShowPersonDetails1.PersonID = -1;
                    btnNext.Enabled = false;
                }
            }
        }

        private void _GetPersonDetailsByNationalNo()
        {
            if (!String.IsNullOrEmpty((txtFilter.Text)))
            {
                string NationalNo = txtFilter.Text.Trim();

                if (clsPerson.IsPersonExists(NationalNo))
                {
                    ctrlShowPersonDetails1.PersonID = clsPerson.GetPersonIDByNationalNO(NationalNo);
                    btnNext.Enabled = true;
                }


                else
                {
                    MessageBox.Show($"There is No Person with NationalNo: {NationalNo}",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ctrlShowPersonDetails1.PersonID = -1;
                    btnNext.Enabled = false;
                }
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                _GetPersonDetailsByID();
            }

            if (cbFilter.SelectedItem.ToString() == "NationalNO.")
            {
                _GetPersonDetailsByNationalNo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabLoginInfo;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Error, Username connot be Blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Error, Please enter Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

    }
}
