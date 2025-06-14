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
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;

        private int _UserID = -1;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public int UserID
        {
            get
            {
                return _UserID;
            }
        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "N/A";
            lblUsername.Text = "N/A";
            lblIsActive.Text = "N/A";
        }

        private void _FillUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username.ToString();
            lblIsActive.Text = (_User.IsActive == true) ? "Yes" : "No";
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
        }

        public void LoadUserData(int UserID)
        {
            _User = clsUser.GetUserByID(UserID);

            if (_User == null)
            {
                _ResetPersonInfo();
                return;
            }

            _FillUserInfo();
        }


    }
}

