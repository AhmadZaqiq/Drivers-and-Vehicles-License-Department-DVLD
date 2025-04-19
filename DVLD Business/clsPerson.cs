using System;
using System.Data;
using System.Data.SqlClient;
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
        public DateTime DateOfBirth { set; get; }
        public int Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                     string ThirdName, string LastName, DateTime DateOfBirth, int Gender, string Address, string Phone, string Email,
                     int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeopleData();
        }

        public static int GetPeopleCount()
        {
            return clsPeopleData.PeopleCountData();
        }

        public static clsPerson GetPersonByID(int PersonID)
        {

            string NationalNo = "",
                   FirstName = "",
                   SecondName = "",
                   ThirdName = "",
                   LastName = "";

            DateTime DateOfBirth = DateTime.Now;

            int Gender = -1;

            string Address = "",
                   Phone = "",
                   Email = "";

            int NationalityCountryID = -1;

            string ImagePath = "";

            if (clsPeopleData.GetPersonByIDData(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }

            return null;
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePersonData(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPersonData(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPeopleData.IsPersonExistsData(PersonID);
        }

        public static bool IsPersonExists(string NationalNo)
        {
            return clsPeopleData.IsPersonExistsData(NationalNo);
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

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePersonData(PersonID);
        }

        public static int GetPersonIDByNationalNO(string NationalNo)
        {
            return clsPeopleData.GetPersonIDByNationalNOData(NationalNo);
        }

        public static bool DoesPersonHaveLicenseForLicenseClass(int ApplicationID, int LicenseClassID)
        {
            return clsPeopleData.DoesPersonHaveLicenseForLicenseClassData(ApplicationID, LicenseClassID);
        }


    }
}
