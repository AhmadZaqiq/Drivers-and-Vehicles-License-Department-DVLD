using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsTestAppointmentsData
    {
        public static DataTable GetAllTestAppointmentsForLocalAppData(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TA.TestAppointmentID, TA.AppointmentDate, TA.PaidFees, TA.IsLocked
                             FROM TestAppointments TA
                             JOIN LocalDrivingLicenseApplications LDLA
                             ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                             WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TA.TestTypeID=@TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static bool GetTestAppointmentByIDData(int TestAppointmentID, ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate,
            ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @" SELECT *
                              FROM TestAppointments
                              WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1;

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

        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID,
            ref int TestAppointmentID, ref DateTime AppointmentDate,
            ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 *
                             FROM TestAppointments
                             WHERE (TestTypeID = @TestTypeID) 
                             AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                             ORDER BY TestAppointmentID Desc";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1;
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

        public static int AddNewTestAppointmentData(int TestTypeID,
             int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
             decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int TestAppointmentsID = -1;

            string query = @"INSERT INTO dbo.TestAppointments 
                             (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, 
                              PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) 
                             VALUES 
                             (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, 
                              @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID != -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();


                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    TestAppointmentsID = insertedID;
                }
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return TestAppointmentsID;
        }

        public static bool UpdateTestAppointmentData(int TestAppointmentID, DateTime AppointmentDate, bool IsLocked, int RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE dbo.TestAppointments
                             SET AppointmentDate = @AppointmentDate,
                                 IsLocked = @IsLocked,
                                 RetakeTestApplicationID = @RetakeTestApplicationID
                             WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID == -1 ? DBNull.Value : (object)RetakeTestApplicationID);

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

        public static bool DeleteTestAppointmentData(int TestAppointmentsID)
        {
            bool DeletedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM TestAppointments
                             WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentsID);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                DeletedSuccessfully = (rowsAffected > 0);
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return DeletedSuccessfully;
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                             FROM TestAppointments
                             WHERE  
                             (TestTypeID = @TestTypeID) 
                             AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                             ORDER BY TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TestID
                             FROM Tests
                             WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
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


    }
}
