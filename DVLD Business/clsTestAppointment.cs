using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            Mode = enMode.Update;
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
        }

        public static DataTable GetAllTestAppointmentsForLocalApp(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsForLocalAppData(LocalDrivingLicenseApplicationID);
        }

        public static clsTestAppointment GetTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (!clsTestAppointmentsData.GetTestAppointmentByIDData(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return null;
            }

            return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointmentData(TestAppointmentID);
        }

        public static bool IsAppointmentScheduledForPerson(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentsData.IsAppointmentScheduledForPersonData(LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointmentData(this.TestAppointmentID, this.AppointmentDate,this.IsLocked,this.RetakeTestApplicationID);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointmentData(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate
                , this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        public static bool IsTestAppointmentExists(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsTestAppointmentExistsData(TestAppointmentID);
        }

        public static bool IsRetakeTestAppointmentExists(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentsData.IsRetakeTestAppointmentExistsData(LocalDrivingLicenseApplicationID,LicenseClassID);
        }

        public static int GetTestAppointmentIDByLocalApplicationID(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentsData.GetTestAppointmentIDByLocalApplicationIDData(LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

                default: return false;
            }
        }


    }
}
