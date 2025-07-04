using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Global
{
    internal class clsValidation
    {
        public static bool ValidateEmail(string EmailAddress)
        {
            string Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            Regex Regex = new Regex(Pattern);

            return Regex.IsMatch(EmailAddress);
        }

        public static bool ValidatePhone(string phoneNumber)
        {
            string Pattern = @"^\d{8,15}$";

            Regex Regex = new Regex(Pattern);

            return Regex.IsMatch(phoneNumber);
        }


    }
}
