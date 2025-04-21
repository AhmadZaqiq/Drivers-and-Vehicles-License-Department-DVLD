using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(10);
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID,
                           DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
                           bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        public static DataTable GetAllLicensesForDriver(int DriverID)
        {
            return clsLicensesData.GetAllLicensesForDriverData(DriverID);
        }

        public static clsLicense GetLicenseByID(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicensesData.GetLicenseByIDData(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID,
                    IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, IssueReason, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicenseData(this.ApplicationID, this.DriverID, this.LicenseClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicenseData(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, this.IssueReason, this.CreatedByUserID);
        }

        public static bool IsLicenseExists(int LicenseID)
        {
            return clsLicensesData.IsLicenseExistsData(LicenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return clsLicensesData.GetLicenseIDByApplicationIDData(ApplicationID);
        }

        public static int GetPersonIDByLicenseID(int LicenseID)
        {
            return clsLicensesData.GetPersonIDByLicenseIDData(LicenseID);
        }

        public static bool DoesPersonHaveLicenseForLicenseClass(int ApplicationID, int LicenseClassID)
        {
            return clsLicensesData.DoesPersonHaveLicenseForLicenseClassData(ApplicationID, LicenseClassID);
        }

    }
}
