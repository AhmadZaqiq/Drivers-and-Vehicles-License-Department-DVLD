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
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = -1;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return  clsApplicationTypesData.GetAllApplicationTypesData();
        }

        public static clsApplicationType GetApplicationTypeByID(int ApplicationTypeID)
        {        
            string ApplicationTypeTitle = "";
            decimal ApplicationFees= 0;

            if (!clsApplicationTypesData.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return null;

                return new clsApplicationType(ApplicationTypeID,ApplicationTypeTitle,ApplicationFees);
        }

        public bool UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypeFees);
        }




    }
}
