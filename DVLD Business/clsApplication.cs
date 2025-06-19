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

        public int ID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
        public byte Status { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        private clsApplication(int ID, int ApplicantPersonID, DateTime Date,
            int TypeID, byte Status, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)
        {
            this.ID = ID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.Date = Date;
            this.TypeID = TypeID;
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ID = -1;
            this.ApplicantPersonID = -1;
            this.Date = DateTime.Now;
            this.TypeID = -1;
            this.Status = 0;
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
            DateTime Date = DateTime.Now;
            int TypeID = -1;
            byte Status = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;

            if (!clsApplicationsData.GetApplicationByIDData(ApplicationID, ref ApplicantPersonID, ref Date, ref TypeID,
             ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return null;
            }

            return new clsApplication(ApplicationID, ApplicantPersonID, Date, TypeID,
              Status, LastStatusDate, PaidFees, CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ID = clsApplicationsData.AddNewApplicationData(this.ApplicantPersonID,
                 this.Date, this.TypeID, this.Status,
                 this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplicationData(this.ID,
                this.ApplicantPersonID, this.Date, this.TypeID,
                this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
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
