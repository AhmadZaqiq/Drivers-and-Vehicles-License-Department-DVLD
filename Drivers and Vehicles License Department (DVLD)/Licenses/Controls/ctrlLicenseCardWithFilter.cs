using Drivers_and_Vehicles_License_Department__DVLD_.Global;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    public partial class ctrlLicenseCardWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private int _LicenseID = -1;

        public ctrlLicenseCardWithFilter()
        {
            InitializeComponent();
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

        public int LicenseID
        {
            get
            {
                return ctrlLicenseCard1.LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlLicenseCard1.SelectedLicenseInfo;
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();

            ctrlLicenseCard1.LoadLicenseInfo(LicenseID);

            _LicenseID = ctrlLicenseCard1.LicenseID;

            if (OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(_LicenseID);
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessageBoxManager.ShowMessageBox("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }

            _LicenseID = int.Parse(txtLicenseID.Text);

            LoadLicenseInfo(_LicenseID);
        }

        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }
        }

        private void txtLicenseID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
                return;
            }

            errorProvider1.SetError(txtLicenseID, null);
        }


    }
}
