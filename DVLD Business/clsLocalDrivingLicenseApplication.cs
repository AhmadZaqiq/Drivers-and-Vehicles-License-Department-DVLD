﻿using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            Mode = enMode.Update;
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }

        public static DataTable GetAllLocalDrivingApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsData();
        }

        public static clsLocalDrivingLicenseApplication GetLocalDrivingApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (!clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByIDData(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
                return null;

            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        private bool _UpdateLocalDrivingApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationData
                (this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        private bool _AddNewLocalDrivingApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplicationData
                (this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public bool Save()
        {
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

        public static bool IsPersonDeniedForClass(int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.IsPersonDeniedForClassData(ApplicantPersonID, ApplicationTypeID, LicenseClassID);
        }

        public static bool DeleteLocalDrivingApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplicationData(LocalDrivingLicenseApplicationID);
        }

        public static bool CancelLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.CancelLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static int GetTestsCountForLocalApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID, bool IsPassed)
        {
            return clsLocalDrivingLicenseApplicationData.GetTestsCountForLocalApplicationData(LocalDrivingLicenseApplicationID, LicenseClassID, IsPassed);
        }


    }
}
