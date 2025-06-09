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
            return clsCountriesData.GetAllCountriesData();
        }

        public static clsCountry GetCountry(int CountryID)
        {
            string CountryName = "";

            if (clsCountriesData.GetCountryData(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }

            return null;
        }

        public static clsCountry GetCountry(string CountryName)
        {
            int CountryID = -1;

            if (clsCountriesData.GetCountryData(CountryName, ref CountryID))
            {
                return new clsCountry(CountryID, CountryName);
            }

            return null;
        }


    }
}
