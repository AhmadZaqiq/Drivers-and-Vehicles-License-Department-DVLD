using System;
using System.Data;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsPerson
    {
        public int PersonID { set; get; }
        public int Gendor { set; get; }
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
        public string ImagePath { set; get; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.Gendor = -1;
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

        private clsPerson(int personID, int gendor, string nationalNo, string firstName, string secondName,
                     string thirdName, string lastName, string address, string phone, string email,
                     string countryName, DateTime dateOfBirth, string imagePath)
        {
            PersonID = personID;
            Gendor = gendor;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            CountryName = countryName;
            DateOfBirth = dateOfBirth;
            ImagePath = imagePath;
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
            int Gendor = 0;
            string NationalNo = "",
                   FirstName = "",
                   SecondName = "",
                   ThirdName = "",
                   LastName = "",
                   Address = "",
                   Phone = "",
                   Email = "",
                   ImagePath = "",
                   CountryName = "";
            DateTime DateOfBirth = DateTime.MinValue;

            if (clsPeopleData.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref ImagePath, ref CountryName))
            {
                return new clsPerson(PersonID, Gendor, NationalNo, FirstName, SecondName, ThirdName, LastName, Address, Phone, Email, CountryName, DateOfBirth, ImagePath);
            }

            return null;
        }
    }
}
