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
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = -1;
        }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return  clsApplicationTypesData.ApplicationTypesData();
        }

        public static clsApplicationTypes GetApplicationByID(int ApplicationTypeID)
        {        
            string ApplicationTypeTitle = "";
            decimal ApplicationFees= 0;

            if (!clsApplicationTypesData.GetApplicationByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return null;

                return new clsApplicationTypes(ApplicationTypeID,ApplicationTypeTitle,ApplicationFees);
        }

        public bool UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationTypes(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypeFees);
        }




    }
}
