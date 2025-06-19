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
        public int ID { get; set; }
        public string Name { get; set; }

        public clsCountry()
        {
            this.ID = 0;
            this.Name = "";
        }

        private clsCountry(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountriesData();
        }

        public static clsCountry GetCountry(int CountryID)
        {
            string Name = "";

            if (!clsCountriesData.GetCountryData(CountryID, ref Name))
            {
                return null;
            }

            return new clsCountry(CountryID, Name);
        }

        public static clsCountry GetCountry(string CountryName)
        {
            int ID = -1;

            if (!clsCountriesData.GetCountryData(CountryName, ref ID))
            {
                return null;
            }

            return new clsCountry(ID, CountryName);
        }
   

    }
}
