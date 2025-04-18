﻿using DVLD_Business;
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
        private clsUser _User = new clsUser();

        private int _UserID = -1;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public int UserID
        {
            set
            {
                _UserID = value;

                if ((_UserID == -1))
                {
                    ctrlPersonCard1.PersonID = -1;
                    return; // Exits only from get
                }

                _DisplayUserDetails();
            }
            get
            {
                return _UserID;
            }
        }

        private string _ConvertActiveStatusToText()
        {
            return _User.IsActive == true ? "Yes" : "No";
        }

        private void _LoadUserData()
        {
            _User = clsUser.GetUserByID(_UserID);
        }

        private void _DisplayUserDetails()
        {
            _LoadUserData();

            if (_User == null)
            {
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username.ToString();
            lblIsAcitve.Text = _ConvertActiveStatusToText();
            ctrlPersonCard1.PersonID = _User.PersonID;
        }


    }
}

