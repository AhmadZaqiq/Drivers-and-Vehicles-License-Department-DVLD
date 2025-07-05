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
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int ClassID { get; set; }
        public clsLicenseClass ClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReasonID { get; set; }
        public int CreatedByUserID { get; set; }
        public enIssueReason IssueReason { set; get; }
        public clsDetainedLicense DetainedInfo { set; get; }

        public clsLicense()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.ClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(10);
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReasonID = 0;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID,
                           DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
                           bool IsActive, byte IssueReasonCode, int CreatedByUserID)
        {
            this.ID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.GetDriverByID(this.DriverID);
            this.ClassID = LicenseClassID;
            this.ClassInfo = clsLicenseClass.GetLicenseClass(this.ClassID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReasonID = IssueReasonCode;
            this.CreatedByUserID = CreatedByUserID;
            this.DetainedInfo = clsDetainedLicense.GetDetainedLicenseByLicenseID(this.ID);

            this.Mode = enMode.Update;
        }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.ID); }
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverLicensesData(DriverID);
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

            if (!clsLicensesData.GetLicenseByIDData(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return null;
            }

            return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees,
                IsActive, IssueReason, CreatedByUserID);
        }

        private bool _AddNewLicense()
        {
            this.ID = clsLicensesData.AddNewLicenseData(this.ApplicationID, this.DriverID, this.ClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, this.IssueReasonID, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicenseData(this.ID, this.ApplicationID, this.DriverID, this.ClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, this.IssueReasonID, this.CreatedByUserID);
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

                default: return false;
            }
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonIDData(PersonID, LicenseClassID);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public Boolean IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesData.DeactivateLicenseData(this.ID));
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime: return "First Time";

                case enIssueReason.Renew: return "Renew";

                case enIssueReason.DamagedReplacement: return "Replacement for Damaged";

                case enIssueReason.LostReplacement: return "Replacement for Lost";

                default: return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();

            detainedLicense.LicenseID = this.ID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = (decimal)FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {
                return -1;
            }

            return detainedLicense.ID;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;
            Application.TypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;
            Application.TypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetApplicationTypeByID((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.ClassID = this.ClassID;
            NewLicense.IssueDate = DateTime.Now;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.ClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.ClassInfo.Fees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;

            Application.TypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetApplicationTypeByID(Application.TypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.ClassID = this.ClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// No fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }
        

    }
}
