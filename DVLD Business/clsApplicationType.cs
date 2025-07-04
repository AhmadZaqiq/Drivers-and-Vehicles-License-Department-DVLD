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

        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public clsApplicationType()
        {
            ID = -1;
            Title = "";
            Fees = -1;

            Mode = enMode.AddNew;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ID = ApplicationTypeID;
            this.Title = ApplicationTypeTitle;
            this.Fees = ApplicationFees;

            Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypesData();
        }

        public static clsApplicationType GetApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            if (!clsApplicationTypeData.GetApplicationTypeInfoByIDData(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return null;
            }

            return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }

        private bool _AddNewApplicationType()
        {
            this.ID = clsApplicationTypeData.AddApplicationTypeData(this.Title, this.Fees);

            return (this.ID != -1);
        }

        public bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationTypeData(this.ID, this.Title, this.Fees);
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
