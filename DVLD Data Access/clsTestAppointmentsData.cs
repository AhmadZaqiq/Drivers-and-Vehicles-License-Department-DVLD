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
        public static DataTable GetAllTestAppointmentsData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM TestAppointments";

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

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();


                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    TestAppointmentsID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return TestAppointmentsID;
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

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return DeletedSuccessfully;
        }

        public static int GetTestsCountForPersonData(int ApplicantPersonID)
        {
            int Tests = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT COUNT(*) 
                              FROM TestAppointments	
                              JOIN LocalDrivingLicenseApplications
                                  ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                              JOIN Applications
                                  ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                              WHERE Applications.ApplicantPersonID = ApplicantPersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    Tests = Convert.ToInt32(result);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return Tests;
        }


    }
}
