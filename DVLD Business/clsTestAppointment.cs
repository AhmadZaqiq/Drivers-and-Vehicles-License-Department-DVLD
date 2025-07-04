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
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestAppInfo { set; get; }

        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees,
           int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.ID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.Date = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.GetApplicationByID(RetakeTestApplicationID);

            Mode = enMode.Update;
        }

        public clsTestAppointment()
        {
            this.ID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.Date = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
        }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        public static DataTable GetAllTestAppointmentsForLocalApp(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsForLocalAppData(LocalDrivingLicenseApplicationID, (int)TestTypeID);
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

            return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                Date, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointmentData(TestAppointmentID);
        }

        private bool _AddNewTestAppointment()
        {
            this.ID = clsTestAppointmentsData.AddNewTestAppointmentData((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.Date
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

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (!clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return null;
            }

            return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(ID);
        }


    }
}
