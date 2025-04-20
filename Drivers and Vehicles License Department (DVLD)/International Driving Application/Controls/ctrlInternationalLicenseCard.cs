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

namespace Drivers_and_Vehicles_License_Department__DVLD_.International_Driving_Application.Controls
{
    public partial class ctrlInternationalLicenseCard : UserControl
    {
        private clsInternationalLicense _InternationalLicense;

        private clsLicense _License;

        private clsApplication _Application;

        private clsPerson _Person;

        private int _InternationalLicenseID;

        private int _LicenseID;

        private int _ApplicationID;

        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID
        {
            set
            {
                _InternationalLicenseID = value;

                if (_InternationalLicenseID == -1)
                {
                    _ClearInternationalLicenseDetails();
                    return; // Exits only from get
                }

                _DisplayInternationalLicenseDetails();
            }

            get
            {
                return _InternationalLicenseID;
            }
        }

        private void _LoadAllInternationalLicenseData()
        {
            _InternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(_InternationalLicenseID);

            _License = clsLicense.GetLicenseByID(_InternationalLicense.IssuedUsingLocalLicenseID);

            _LicenseID = _License.LicenseID;

            _Application = clsApplication.GetApplicationByID(_InternationalLicense.ApplicationID);

            _ApplicationID = _Application.ApplicationID;

            _Person = clsPerson.GetPersonByID(_Application.ApplicantPersonID);
        }

        private string _GetGenderAsText(int Gender)
        {
            return (Gender == 0) ? "Male" : "Female";
        }

        private void _PopulateInternationalLicenseDetails()
        {
            lblName.Text = _Person.FullName;
            lblInternationLicenseID.Text = _InternationalLicenseID.ToString();
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNO.Text = _Person.NationalNo;
            lblGender.Text = _GetGenderAsText(_Person.Gender);
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
        }

        private void _DisplayInternationalLicenseDetails()
        {
            _LoadAllInternationalLicenseData();

            if (_InternationalLicense == null)
            {
                return;
            }

            _PopulateInternationalLicenseDetails();
        }

        private void _ClearInternationalLicenseDetails()
        {
            lblName.Text = "N\\A";
            lblInternationLicenseID.Text = "N\\A";
            lblLicenseID.Text = "N\\A";
            lblNationalNO.Text = "N\\A";
            lblGender.Text = "N\\A";
            lblIssueDate.Text = "N\\A";
            lblApplicationID.Text = "N\\A";
            lblIsActive.Text = "N\\A";
            lblDateOfBirth.Text = "N\\A";
            lblDriverID.Text = "N\\A";
            lblExpirationDate.Text = "N\\A";
        }

    }
}
