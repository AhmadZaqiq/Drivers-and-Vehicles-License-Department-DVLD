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
using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using Drivers_and_Vehicles_License_Department__DVLD_.People.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.People.Contorls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;  // Custom event handler delegate with parameters

        protected virtual void PersonSelected(int PersonID) // Method to raise the event with a parameter
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }


        private frmListPeople _frmPeople = new frmListPeople();

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get
            {
                return ctrlPersonCard1.PersonID;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ctrlPersonCard1.SelectedPersonInfo;
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            txtFilter.Focus();
        }

        private void _FillComboBox()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("NationalNO.");
            cbFilter.Items.Add("PersonID");

            cbFilter.SelectedIndex = 0;
        }

        private void _FindNow()
        {
            string FilterValue = txtFilter.Text.Trim();

            switch (cbFilter.Text)
            {
                case "PersonID":
                    {
                        if (!int.TryParse(FilterValue, out int personID))
                        {
                            clsMessageBoxManager.ShowMessageBox("Please enter a valid numeric PersonID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ctrlPersonCard1.LoadPersonInfo(personID);
                        break;
                    }

                case "NationalNO.":
                    ctrlPersonCard1.LoadPersonInfo(FilterValue);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID); // Raise the event with a parameter
            }
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 2;
            txtFilter.Text = PersonID.ToString();
            _FindNow();
        }

        private void _DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilter.SelectedIndex = 2;
            txtFilter.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePeople FormAddAndUpdatePeople = new frmAddAndUpdatePeople();

            FormAddAndUpdatePeople.DataBack += _DataBackEvent;

            FormAddAndUpdatePeople.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Mask = "";
            txtFilter.Focus();
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilter, "This field is required!");
                return;
            }

            errorProvider1.SetError(txtFilter, null);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //Check if the perssed key is enter (13 in ASCII)
            {
                btnFindPerson.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilter.Text == "PersonID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


    }
}
