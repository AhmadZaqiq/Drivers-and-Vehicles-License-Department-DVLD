using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Global
{
    public class clsCurrentUser
    {
        private clsCurrentUser() { }

        public static clsUser CurrentUser { get;  set; }
    }
}


