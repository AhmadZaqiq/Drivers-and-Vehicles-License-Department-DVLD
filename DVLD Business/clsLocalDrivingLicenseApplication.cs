using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplication(int ID, int ApplicationID, int LicenseClassID, int ApplicantPersonID, DateTime Date,
            int TypeID, enApplicationStatus Status, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.GetLicenseClass(LicenseClassID);

            this.ApplicantPersonID = ApplicantPersonID;
            this.Date = Date;
            this.TypeID = TypeID;
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public string PersonFullName
        {
            get
            {
                return clsPerson.GetPersonByID(ApplicantPersonID).FullName;
            }
        }

        public static DataTable GetAllLocalDrivingApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsData();
        }

        public static clsLocalDrivingLicenseApplication GetLocalDrivingApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (!clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByIDData(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return null;
            }

            clsApplication Application = clsApplication.GetApplicationByID(ApplicationID);

            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID, Application.ApplicantPersonID, Application.Date,
                              Application.TypeID, (enApplicationStatus)Application.Status, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID);
        }

        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            if (!clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationIDData
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
            {
                return null;
            }

            clsApplication Application = clsApplication.GetApplicationByID(ApplicationID);

            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID, Application.ApplicantPersonID, Application.Date,
                              Application.TypeID, (enApplicationStatus)Application.Status, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID);
        }

        private bool _AddNewLocalDrivingApplication()
        {
            this.ID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplicationData
                (this.ApplicationID, this.LicenseClassID);

            return (this.ID != -1);
        }

        private bool _UpdateLocalDrivingApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationData
                (this.ID, this.ApplicationID, this.LicenseClassID);
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

                    if (_AddNewLocalDrivingApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateLocalDrivingApplication();

                default: return false;
            }
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestTypeData(this.ID, (int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestTypeData(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType CurrentTestType)
        {
            switch (CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest:

                    return true;

                case clsTestType.enTestType.WrittenTest:

                    return this.DoesPassTestType(clsTestType.enTestType.VisionTest);

                case clsTestType.enTestType.StreetTest:

                    return this.DoesPassTestType(clsTestType.enTestType.WrittenTest);

                default: return false;
            }
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestTypeData(this.ID, (int)TestTypeID);
        }

        public byte TotalAttemptsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalAttemptsPerTestData(this.ID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalAttemptsPerTestData(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool AttendedTest(clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalAttemptsPerTestData(this.ID, (int)TestTypeID) > 0;
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalAttemptsPerTestData(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTestData(this.ID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTestData(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.ID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.ID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            clsDriver Driver = clsDriver.GetDriverByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver
                {
                    PersonID = this.ApplicantPersonID,
                    CreatedByUserID = CreatedByUserID
                };

                if (!Driver.Save())

                {
                    return -1;
                }
            }

            int DriverID = Driver.ID;

            clsLicense License = new clsLicense
            {
                ApplicationID = this.ApplicationID,
                DriverID = DriverID,
                ClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength),
                Notes = Notes,
                PaidFees = this.LicenseClassInfo.Fees,
                IsActive = true,
                IssueReason = clsLicense.enIssueReason.FirstTime,
                CreatedByUserID = CreatedByUserID
            };

            if (!License.Save())
            {
                return -1;
            }

            this.SetComplete();

            return License.ID;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }


    }
}
