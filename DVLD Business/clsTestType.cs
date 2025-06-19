using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;
using DVLD_Data_Access;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestType.enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestType()
        {
            ID = clsTestType.enTestType.VisionTest;
            Title = "";
            Description = "";
            Fees = -1;

            Mode = enMode.AddNew;
        }

        private clsTestType(clsTestType.enTestType ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;

            Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypesData();
        }

        public static clsTestType GetTestTypeByID(clsTestType.enTestType ID)
        {
            string Title = "";
            string Description = "";
            decimal Fees = -1;

            if (!clsTestTypeData.GetTestTypeByID((int)ID, ref Title, ref Description, ref Fees))
            {
                return null;
            }

            return new clsTestType(ID, Title, Description, Fees);
        }

        private bool _AddNewTestType()
        {
            this.ID = (clsTestType.enTestType)clsTestTypeData.AddTestTypeData(this.Title, this.Description, this.Fees);

            return (this.Title != "");
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestTypeData((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateTestType();

                default: return false;
            }
        }


    }
}
