using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string CountryName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Gendor { set; get; }
        public string ImagePath { set; get; }

        public int CountryID { set; get; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.Gendor = "";
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryName = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
        }

        private clsPerson(int PersonID, string Gendor, string NationalNo, string FirstName, string SecondName,
                     string ThirdName, string LastName, string Address, string Phone, string Email,
                     string CountryName, DateTime DateOfBirth, string ImagePath)
        {
            this.PersonID = PersonID;
            this.Gendor = Gendor;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryName = CountryName;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.PeopleData();
        }

        public static int GetPeopleCount()
        {
            return clsPeopleData.PeopleCount();
        }

        public static clsPerson GetPersonByID(int PersonID)
        {

            string NationalNo = "",
                   FirstName = "",
                   SecondName = "",
                   ThirdName = "",
                   LastName = "",
                   Address = "",
                   Phone = "",
                   Email = "",
                   Gendor = "",
                   ImagePath = "",
                   CountryName = "";
            DateTime DateOfBirth = DateTime.MinValue;

            if (clsPeopleData.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref ImagePath, ref CountryName))
            {
                return new clsPerson(PersonID, Gendor, NationalNo, FirstName, SecondName, ThirdName, LastName, Address, Phone, Email, CountryName, DateOfBirth, ImagePath);
            }

            return null;
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, Convert.ToInt32(this.Gendor), this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, Convert.ToInt32(this.Gendor), this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPeopleData.IsPersonExists(PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

                default: return false;
            }
        }
    }
}
