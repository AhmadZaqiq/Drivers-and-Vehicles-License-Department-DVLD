using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsPeople
    {
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.PeopleData();
        }
    }
}
