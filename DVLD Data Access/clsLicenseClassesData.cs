using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsLicenseClassesData
    {
        public static DataTable GetAllLicenseClassesData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetLicenseClassByIDData(int LicenseClassID, ref string ClassName, ref string ClassDescription,
                                               ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @" SELECT *
                              FROM LicenseClasses
                              WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }

                reader.Close();
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
                                               ref string ClassDescription, ref byte MinimumAllowedAge,
                                               ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM LicenseClasses
                             WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }

                reader.Close();

            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }


    }
}
