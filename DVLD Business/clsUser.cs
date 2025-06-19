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

        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;
        }

        private clsUser(int ID, int PersonID, string Username, string Password, bool IsActive)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.GetPersonByID(PersonID);
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsersData();
        }

        public static clsUser GetUserByID(int UserID)
        {
            int PersonID = -1;
            string Username = "",
                   Password = "";
            bool IsActive = false;


            if (!clsUsersData.GetUserByIDData(UserID, ref PersonID, ref Username, ref Password, ref IsActive))
            {
                return null;
            }

            return new clsUser(UserID, PersonID, Username, Password, IsActive);
        }

        public static clsUser GetUserByUsername(string Username)
        {
            int UserID = -1,
            PersonID = -1;
            string Password = "";
            bool IsActive = false;


            if (!clsUsersData.GetUserByUsernameData(Username, ref UserID, ref PersonID, ref Password, ref IsActive))
            {
                return null;
            }

            return new clsUser(UserID, PersonID, Username, Password, IsActive);
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            if (!clsUsersData.GetUserInfoByUsernameAndPasswordData(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return null;
            }

            return new clsUser(UserID, PersonID, UserName, Password, IsActive);
        }

        private bool _AddNewUser()
        {
            this.ID = clsUsersData.AddNewUserData(this.PersonID, this.Username, this.Password, this.IsActive);

            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUserData(this.PersonID, this.Username, this.Password, this.IsActive);
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

                    return false;

                case enMode.Update:

                    return _UpdateUser();

                default: return false;
            }

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUserData(UserID);
        }

        public static bool IsUserExists(int UserID)
        {
            return clsUsersData.IsUserExistData(UserID);
        }

        public static bool IsUserExists(string Username)
        {
            return clsUsersData.IsUserExistData(Username);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistForPersonIDData(PersonID);
        }


    }
}
