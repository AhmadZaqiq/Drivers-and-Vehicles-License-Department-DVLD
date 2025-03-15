using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drivers_and_Vehicles_License_Department__DVLD_.Global
{
    public class clsMessageBoxManager
    {
        private clsMessageBoxManager() { }

        public static void ShowMessageBox(string Message, string Title, MessageBoxButtons Button, MessageBoxIcon Icon)
        {
            MessageBox.Show(Message, Title, Button, Icon);
        }

        public static bool ShowConfirmActionBox(string Message, string Title, MessageBoxButtons Button, MessageBoxIcon Icon)
        {
            return MessageBox.Show(Message, Title, Button, Icon) == DialogResult.Yes;
        }


    }
}
