using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = 0;
            this.CountryName = "";
        }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.CountriesData();
        }

        public static clsCountry GetCountryByPersonID(int PersonID)
        {
            int CountryID = 0;
            string CountryName = "";

            if (clsCountriesData.FindCountryByPersonID(PersonID, ref CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }

            return null;
        }

    }
}
