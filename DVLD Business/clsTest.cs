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
        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        private clsTest(int ID, int TestAppointmentID, bool Result, string Notes, int CreatedByUserID)
        {
            this.ID = ID;
            this.TestAppointmentID = TestAppointmentID;
            this.Result = Result;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        public clsTest()
        {
            this.ID = -1;
            this.TestAppointmentID = -1;
            this.Result = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
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

        public bool AddNewTest()
        {
            this.ID = clsTestData.AddNewTestData(this.TestAppointmentID,
                this.Result, this.Notes, this.CreatedByUserID);

            return (this.ID != -1);
        }

        public static int GetTestAttemptsCountByTestType(int LocalDrivingLicenseApplicationID, int LicenseClassID, int TestTypeID, bool IsPassed)
        {
            return clsTestData.GetTestAttemptsCountByTestTypeData(LocalDrivingLicenseApplicationID, LicenseClassID, TestTypeID, IsPassed);
        }


    }
}
