using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal Fees { get; set; }

        public clsLicenseClass()
        {
            this.ID = 0;
            this.Name = "";
            this.Description = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.Fees = 0;
        }

        private clsLicenseClass(int ID, string Name, string Description, byte MinimumAllowedAge, byte DefaultValidityLength, decimal Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClassesData();
        }

        public static clsLicenseClass GetLicenseClassByID(int LicenseClassID)
        {
            string Name = "";
            string Description = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal Fees = 0;

            if (!clsLicenseClassesData.GetLicenseClassDataByIDData(LicenseClassID, ref Name, ref Description, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees))
            {
                return null;
            }

            return new clsLicenseClass(LicenseClassID, Name, Description, MinimumAllowedAge, DefaultValidityLength, Fees);
        }


    }
}
