using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { set; get; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.ID = -1;
            this.TestAppointmentID = -1;
            this.Result = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsTest(int ID, int TestAppointmentID, bool Result, string Notes, int CreatedByUserID)
        {
            this.ID = ID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.GetTestAppointmentByID(TestAppointmentID);
            this.Result = Result;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTestsData();
        }

        public static clsTest GetTestByID(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (!clsTestData.GetTestByIDData(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return null;
            }

            return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static clsTest FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (!clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClassData(PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
                                                                               ref TestAppointmentID, ref TestResult,
                                                                               ref Notes, ref CreatedByUserID))
            {
                return null;
            }

            return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        private bool _AddNewTest()
        {
            this.ID = clsTestData.AddNewTestData(this.TestAppointmentID,
                this.Result, this.Notes, this.CreatedByUserID);

            return (this.ID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTestData(this.ID, this.TestAppointmentID,
                this.Result, this.Notes, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateTest();

                default: return false;
            }
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCountData(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }


    }
}
