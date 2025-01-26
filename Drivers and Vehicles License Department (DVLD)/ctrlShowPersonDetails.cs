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

namespace Drivers_and_Vehicles_License_Department__DVLD_
{
    public partial class ctrlShowPersonDetails : UserControl
    {

        clsPerson Person = clsPerson.GetPersonByID(1);

        public ctrlShowPersonDetails()
        {
            InitializeComponent();
            FillPersonData();
        }

        public int PersonId
        {
            set
            {
                lblPersonID.Text = value.ToString();
                Person = clsPerson.GetPersonByID(value);
                FillPersonData();
            }
        }

        public string HandleGender(int Gender)
        {
            return Gender == 0 ? "Male" : "Female";
        }


        public void FillPersonData()
        {
            lblName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblNationalNO.Text = Person.NationalNo;
            lblGender.Text = HandleGender(Person.Gendor);
            lblEmail.Text = Person.Email;
            lblAddress.Text = Person.Address;
            lblPhone.Text = Person.Phone;
        }

    }
}
