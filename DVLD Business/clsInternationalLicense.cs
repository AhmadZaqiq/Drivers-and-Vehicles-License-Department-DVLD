using System;
using System.Data;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
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

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
                         int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                    bool IsActive, int CreatedByUserID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus,
               DateTime LastStatusDate, decimal PaidFees)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.Date = ApplicationDate;
            base.TypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.Status = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;

            this.ID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.GetDriverByID(this.DriverID);
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


            if (!clsInternationalLicensesData.GetInternationalLicenseByIDData(
                InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate,
                ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return null;
            }

            clsApplication Application = clsApplication.GetApplicationByID(ApplicationID);

            return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID,
                Application.ApplicantPersonID, Application.Date, Application.Status,
                Application.LastStatusDate, Application.PaidFees);
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
            base.Mode = (clsApplication.enMode)Mode;

            if (!base.Save())
            {
                return false;
            }

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

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalLicensesData.GetActiveInternationalLicenseIDByDriverIDData(DriverID);

        }


    }
}
