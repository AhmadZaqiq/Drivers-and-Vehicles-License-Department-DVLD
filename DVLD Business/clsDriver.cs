using System;
using System.Data;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.AddNew;
        }

        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            this.DriverID = driverID;
            this.PersonID = personID;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;

            this.Mode = enMode.Update;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDriversData();
        }

        public static clsDriver GetDriverByID(int DriverID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriversData.GetDriverByIDData(DriverID, ref personID, ref createdByUserID, ref createdDate))
            {
                return new clsDriver(DriverID, personID, createdByUserID, createdDate);
            }

            return null;
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriverData(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriversData.AddNewDriverData(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.DriverID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewDriver())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateDriver();

                default:

                    return false;
            }
        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriversData.DeleteDriverData(DriverID);
        }

        public static bool IsDriverExists(int PersonID)
        {
            return clsDriversData.IsDriverExistsByPersonIDData(PersonID);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return clsDriversData.GetDriverIDByPersonIDData(PersonID);
        }
    }
}
