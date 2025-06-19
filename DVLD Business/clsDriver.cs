using System;
using System.Data;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.AddNew;
        }

        private clsDriver(int ID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDriversData();
        }

        public static clsDriver GetDriverByID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (!clsDriversData.GetDriverByIDData(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return null;
            }

            return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
        }

        private bool _AddNewDriver()
        {
            this.ID = clsDriversData.AddNewDriverData(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.ID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriverData(this.ID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
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

                default: return false;
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
