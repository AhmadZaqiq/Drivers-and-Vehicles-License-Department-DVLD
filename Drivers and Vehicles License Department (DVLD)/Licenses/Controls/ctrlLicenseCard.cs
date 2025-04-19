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

namespace Drivers_and_Vehicles_License_Department__DVLD_.Licenses.Controls
{
    public partial class ctrlLicenseCard : UserControl
    {
        private clsLicense _License;

        private clsApplication _Application;

        private clsPerson _Person;

        private int _LicenseID;

        private int _ApplicationID;

        private enum enStatus { New = 1, Cancelled = 2, Completed = 3 };

        private enum enIssueReason { FirstTime = 1 };

        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            set
            {
                _LicenseID = value;

                if (_LicenseID == -1)
                {
                    _ClearLicenseDetails();
                    return; // Exits only from get
                }

                _DisplayLicenseDetails();
            }

            get
            {
                return _LicenseID;
            }
        }

        private void _LoadAllLicenseData()
        {
            _License = clsLicense.GetLicenseByID(_LicenseID);

            _Application = clsApplication.GetApplicationByID(_License.ApplicationID);

            _ApplicationID = _Application.ApplicationID;

            _Person = clsPerson.GetPersonByID(_Application.ApplicantPersonID);
        }

        public string _ConvertGenderToText(int Gender)
        {
            return (Gender == 0) ? "Male" : "Female";
        }

        private enIssueReason GetIssueReason(int value)
        {
            return (enIssueReason)value;
        }

        private void _PopulateLicenseDetails()
        {
            lblClass.Text = clsLicenseClass.GetLicenseClassByID(_License.LicenseClassID).ClassName;
            lblName.Text = _Person.FullName;
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNO.Text = _Person.NationalNo;
            lblGender.Text = _ConvertGenderToText(_Person.Gender);
            lblIssueDate.Text = _License.IssueDate.ToString();
            lblIssueReason.Text = GetIssueReason(_License.IssueReason).ToString();
            lblNotes.Text = string.IsNullOrWhiteSpace(_License.Notes) ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
            lblIsDetained.Text = "NO";
        }

        private void _DisplayLicenseDetails()
        {
            _LoadAllLicenseData();

            if (_License == null)
            {
                return;
            }

            _PopulateLicenseDetails();
        }

        private void _ClearLicenseDetails()
        {
            lblClass.Text = "N\\A";
            lblName.Text = "N\\A"; ;
            lblLicenseID.Text = "N\\A";
            lblNationalNO.Text = "N\\A";
            lblGender.Text = "N\\A";
            lblIssueDate.Text = "N\\A";
            lblIssueReason.Text = "N\\A";
            lblNotes.Text = "N\\A";
            lblIsActive.Text = "N\\A";
            lblDateOfBirth.Text = "N\\A";
            lblDriverID.Text = "N\\A";
            lblExpirationDate.Text = "N\\A";
            lblIsDetained.Text = "N\\A"; ;
        }


    }
}
