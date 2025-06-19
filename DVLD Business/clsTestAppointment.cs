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

        public int ID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        private clsTestAppointment(int ID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime Date, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.ID = ID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.Date = Date;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            Mode = enMode.Update;
        }

        public clsTestAppointment()
        {
            this.ID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.Date = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
        }

        public static DataTable GetAllTestAppointmentsForLocalApp(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsForLocalAppData(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static clsTestAppointment GetTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime Date = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (!clsTestAppointmentsData.GetTestAppointmentByIDData(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref Date, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return null;
            }

            return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                Date, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointmentData(TestAppointmentID);
        }

        public static bool IsAppointmentScheduledForPerson(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentsData.IsAppointmentScheduledForPersonData(LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        private bool _AddNewTestAppointment()
        {
            this.ID = clsTestAppointmentsData.AddNewTestAppointmentData(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.Date
                , this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.ID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointmentData(this.ID, this.Date, this.IsLocked, this.RetakeTestApplicationID);
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

                    return false;

                case enMode.Update:

                    return _UpdateTestAppointment();

                default: return false;
            }
        }

        public static bool IsTestAppointmentExists(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsTestAppointmentExistsData(TestAppointmentID);
        }

        public static bool IsRetakeTestAppointmentExists(int LocalDrivingLicenseApplicationID, int LicenseClassID, int TestTypeID)
        {
            return clsTestAppointmentsData.IsRetakeTestAppointmentExistsData(LocalDrivingLicenseApplicationID, LicenseClassID, TestTypeID);
        }

        public static int GetTestAppointmentIDByLocalApplicationID(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsTestAppointmentsData.GetTestAppointmentIDByLocalApplicationIDData(LocalDrivingLicenseApplicationID, LicenseClassID);
        }


    }
}
