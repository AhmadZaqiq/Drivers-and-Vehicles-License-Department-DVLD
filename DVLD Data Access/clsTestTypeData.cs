using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsTestTypeData
    {
        public static DataTable GetAllTestTypesData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * 
                             FROM TestTypes";

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

        public static int AddTestTypeData(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                             VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return TestTypeID;
        }

        public static bool UpdateTestTypeData(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @TestTypeTitle,
                             TestTypeDescription=@TestTypeDescription,
                             TestTypeFees = @TestTypeFees  
                             WHERE TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();

                int RowAffected = command.ExecuteNonQuery();

                UpdatedSuccessfully = (RowAffected > 0);
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @" SELECT *
                              FROM TestTypes
                              WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];
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
