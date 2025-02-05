using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = 0;
        }

        private clsUser(int UserID, int PersonID, string Username, string Password, byte IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static clsUser GetUserByID(int UserID)
        {
            int PersonID = -1;
            string Username = "",
                   Password = "";
            byte IsActive = 0;


            if (clsUsersData.GetUserByID(UserID, ref PersonID, ref Username, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }

            return null;
        }

        public static clsUser GetUserByUsername(string Username)
        {
            int UserID = -1,
            PersonID = -1;
            string Password = "";
            byte IsActive = 0;


            if (clsUsersData.GetUserByUsername(Username, ref UserID, ref PersonID, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }

            return null;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.PersonID, this.Username, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    if (_UpdateUser())
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool IsUserExists(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        public static bool IsUserExists(string Username)
        {
            return clsUsersData.IsUserExist(Username);
        }



    }
}
