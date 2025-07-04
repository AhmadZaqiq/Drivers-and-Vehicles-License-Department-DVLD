using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access;
using static System.Net.Mime.MediaTypeNames;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }     
        public clsPerson ApplicantPersonInfo { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
        public clsApplicationType TypeInfo { get; set; }
        public enApplicationStatus Status { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        private clsApplication(int ID, int ApplicantPersonID, DateTime Date,
            int TypeID, enApplicationStatus Status, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicantPersonInfo=clsPerson.GetPersonByID(ApplicantPersonID);
            this.Date = Date;
            this.TypeID = TypeID;
            this.TypeInfo = clsApplicationType.GetApplicationTypeByID(TypeID);
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.GetUserByID(CreatedByUserID);

            Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.Date = DateTime.Now;
            this.TypeID = -1;
            this.Status = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        public string StatusText
        {
            get
            {
                return Status.ToString();
            }
        }

        public string ApplicantFullName
        {
            get
            {
                return clsPerson.GetPersonByID(ApplicantPersonID).FullName;
            }
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplicationsData();
        }

        public static clsApplication GetApplicationByID(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime Date = DateTime.Now;
            int TypeID = -1;
            byte Status = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;

            if (!clsApplicationData.GetApplicationByIDData(ApplicationID, ref ApplicantPersonID, ref Date, ref TypeID,
             ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return null;
            }

            return new clsApplication(ApplicationID, ApplicantPersonID, Date, TypeID,
              (enApplicationStatus)Status, LastStatusDate, PaidFees, CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplicationData(this.ApplicantPersonID,
                 this.Date, this.TypeID, (byte)this.Status,
                 this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplicationData(this.ApplicationID,
                this.ApplicantPersonID, this.Date, this.TypeID,
                (byte)this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
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

        public bool Delete()
        {
            return clsApplicationData.DeleteApplicationData(this.ApplicationID);
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationData.DeleteApplicationData(ApplicationID);
        }

        public static int GetApplicationIDByApplicantPersonID(int ApplicantPersonID)
        {
            return clsApplicationData.GetApplicationIDByApplicantPersonIDData(ApplicantPersonID);
        }

        public bool Cancel()

        {
            return clsApplicationData.UpdateStatus(ApplicationID, (short)enApplicationStatus.Cancelled);
        }

        public bool SetComplete()

        {
            return clsApplicationData.UpdateStatus(ApplicationID, (short)enApplicationStatus.Completed);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public bool DoesPersonHaveActiveApplication(enApplicationType ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, (int)ApplicationTypeID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }


    }
}
