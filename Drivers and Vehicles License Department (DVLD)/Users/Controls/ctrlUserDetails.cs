using DVLD_Business;
using SiticoneNetFrameworkUI.Helpers.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Users.Controls
{
    public partial class ctrlUserDetails : UserControl
    {
        private clsUser _User = new clsUser();
        private int _UserID = -1;

        public ctrlUserDetails()
        {
            InitializeComponent();
        }

        public int UserID
        {
            set
            {
                _UserID = value;
                _FillUserData();
            }
            get
            {
                return _UserID;
            }
        }

        private string _ConvertActiveStatustoText()
        {
            return _User.IsActive == true ? "Yes" : "No";
        }

        private void _FillUserData()
        {
            if ((UserID == -1))
            {
                ctrlPersonDetails1.PersonID = -1;
                return;
            }

            lblUserID.Text = UserID.ToString();
            _User = clsUser.GetUserByID(_UserID);

            if (_User == null)
                return;

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username.ToString();
            lblIsAcitve.Text = _ConvertActiveStatustoText();
            ctrlPersonDetails1.PersonID = _User.PersonID;
        }


    }
}

