using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = -1;

            Mode = enMode.AddNew;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationFees;

            Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypesData();
        }

        public static clsApplicationType GetApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            if (!clsApplicationTypesData.GetApplicationTypeInfoByIDData(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return null;
            }

            return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationTypesData.AddApplicationTypeData(this.ApplicationTypeTitle, this.ApplicationTypeFees);

            return (this.ApplicationTypeID != -1);
        }

        public bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationTypeData(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateApplicationType();

                default: return false;
            }
        }


    }
}
