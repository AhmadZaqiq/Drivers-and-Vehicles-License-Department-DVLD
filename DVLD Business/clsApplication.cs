using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access;


namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsData.GetAllApplicationsData();
        }

        public static clsApplication GetApplicationByID(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;

            if (!clsApplicationsData.GetApplicationByIDData(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
             ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return null;
            }

            return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
              ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplicationData(this.ApplicationID,
                this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplicationData(this.ApplicantPersonID,
                 this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus,
                 this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateApplication();

                default: return false;
            }
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplication.DeleteApplication(ApplicationID);
        }

        public static int GetApplicationIDByApplicantPersonID(int ApplicantPersonID)
        {
            return clsApplicationsData.GetApplicationIDByApplicantPersonIDData(ApplicantPersonID);
        }


    }
}
