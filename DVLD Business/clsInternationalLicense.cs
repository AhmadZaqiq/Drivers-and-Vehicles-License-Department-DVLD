using System;
using System.Data;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.IsActive = true;
            this.CreatedByUserID = -1;
        }

        private clsInternationalLicense(int ID, int ApplicationID, int DriverID,
                                        int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                                        bool IsActive, int CreatedByUserID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GetAllInternationalLicensesData();
        }

        public static DataTable GetAllInternationalLicensesForDriver(int DriverID)
        {
            return clsInternationalLicensesData.GetAllInternationalLicensesForDriverData(DriverID);
        }

        public static clsInternationalLicense GetInternationalLicenseByID(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true;
            int CreatedByUserID = -1;

            if (!clsInternationalLicensesData.GetInternationalLicenseByIDData(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return null;
            }

            return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        private bool _AddNewInternationalLicense()
        {
            this.ID = clsInternationalLicensesData.AddNewInternationalLicenseData(this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicensesData.UpdateInternationalLicenseData(this.ID, this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewInternationalLicense())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateInternationalLicense();

                default: return false;
            }
        }

        public static bool IsInternationalLicenseExists(int InternationalLicenseID)
        {
            return clsInternationalLicensesData.IsInternationalLicenseExistsData(InternationalLicenseID);
        }

        public static bool IsDriverHaveInternationalLicens(int DriverID)
        {
            return clsInternationalLicensesData.IsDriverHaveInternationalLicensData(DriverID);
        }

        public static clsInternationalLicense GetInternationalLicenseByDriverID(int DriverID)
        {
            int ID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true;
            int CreatedByUserID = -1;

            if (clsInternationalLicensesData.GetInternationalLicenseByDriverIDData(DriverID, ref ApplicationID, ref ID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(ID, ApplicationID, DriverID,
                    IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }

            return null;
        }


    }
}
