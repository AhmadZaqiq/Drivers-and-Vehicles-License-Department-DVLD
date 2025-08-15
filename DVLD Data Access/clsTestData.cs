using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsTestData
    {
        public static DataTable GetAllTestsData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  * 
                             FROM Tests";

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

        public static bool GetTestByIDData(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @"SELECT *
                             FROM Tests
                             WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static int AddNewTestData(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int TestID = -1;

            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); 
                             UPDATE TestAppointments 
                             SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            catch (Exception ex) { clsDVLDLogger.LogException(ex); }
            finally
            {
                connection.Close();
            }

            return TestID;
        }

        public static bool UpdateTestData(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE  Tests  
                             SET TestAppointmentID = @TestAppointmentID,
                                 TestResult=@TestResult,
                                 Notes = @Notes,
                                 CreatedByUserID=@CreatedByUserID
                                 WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static byte GetPassedTestCountData(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                             FROM Tests
                             INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						     WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID
                             AND
                             TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClassData(int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
                 ref int TestAppointmentID, ref bool TestResult,
                 ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 Tests.TestID, 
                             Tests.TestAppointmentID, Tests.TestResult, 
			                 Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                              FROM LocalDrivingLicenseApplications
                              INNER JOIN Tests
                              INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                              INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                              WHERE (Applications.ApplicantPersonID = @PersonID) 
                              AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                              AND ( TestAppointments.TestTypeID=@TestTypeID)
                              ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    Notes = (reader["Notes"] == DBNull.Value) ? "" : (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
