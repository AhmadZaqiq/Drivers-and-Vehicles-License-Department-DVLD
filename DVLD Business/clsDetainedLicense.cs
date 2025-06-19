using DVLD_Data_Access;
using System.Data;
using System;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            this.ID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
        }

        private clsDetainedLicense(int ID, int LicenseID, DateTime DetainDate, decimal FineFees,
                                    int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
                                    int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.ID = ID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            this.Mode = enMode.Update;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicensesData();
        }

        public static clsDetainedLicense GetDetainedLicenseByID(int DetainedLicenseID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (!clsDetainedLicensesData.GetDetainedLicenseByIDData(DetainedLicenseID, ref LicenseID, ref DetainDate,
                ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate,
                ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return null;
            }

            return new clsDetainedLicense(DetainedLicenseID, LicenseID, DetainDate, FineFees, CreatedByUserID,
              IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        private bool _AddNewDetainedLicense()
        {
            this.ID = clsDetainedLicensesData.AddNewDetainedLicenseData(this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

            return (this.ID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicenseData(this.ID, this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetainedData(LicenseID);
        }

        public static int GetDetainIDByLicenseID(int LicenseID)
        {
            return clsDetainedLicensesData.GetDetainIDByLicenseIDData(LicenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateDetainedLicense();

                default: return false;
            }
        }


    }
}
