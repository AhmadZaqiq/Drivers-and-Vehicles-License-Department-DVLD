using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllLocalDrivingLicenseApplicationsData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  
                             LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
                             LicenseClasses.ClassName, 
                             People.NationalNo, 
                             FullName = People.FirstName + ' ' + 
                                         People.SecondName + ' ' + 
                                         CASE 
                                             WHEN People.ThirdName IS NOT NULL THEN People.ThirdName + ' ' 
                                             ELSE '' 
                                         END + 
                                         People.LastName, 
                             Applications.ApplicationDate, 
                             PassedTests = (
                                 SELECT COUNT(*)
                                 FROM TESTS T
                                 JOIN TESTAPPOINTMENTS TA
                                     ON T.TESTAPPOINTMENTID = TA.TESTAPPOINTMENTID
                                 JOIN LOCALDRIVINGLICENSEAPPLICATIONS LDLA
                                     ON TA.LOCALDRIVINGLICENSEAPPLICATIONID = LDLA.LOCALDRIVINGLICENSEAPPLICATIONID
                                 WHERE T.TESTRESULT = 1
                                 AND LDLA.LOCALDRIVINGLICENSEAPPLICATIONID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             ), 
                             ApplicationStatus = CASE 
                                 WHEN Applications.ApplicationStatus = 1 THEN 'New'
                                 WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
                                 WHEN Applications.ApplicationStatus = 3 THEN 'Completed'
                                 ELSE 'Unknown' 
                             END
                         FROM LocalDrivingLicenseApplications
                         JOIN LicenseClasses 
                             ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                         JOIN Applications 
                             ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                         JOIN People  
                             ON Applications.ApplicantPersonID = People.PersonID";

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

        public static bool GetLocalDrivingLicenseApplicationByIDData(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @"SELECT *
                             FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationIDData(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM LocalDrivingLicenseApplications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewLocalDrivingLicenseApplicationData(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int LocalDrivingLicenseApplicationID = -1;

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) 
                             VALUES (@ApplicationID, @LicenseClassID);  
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();


                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
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

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplicationData(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE LocalDrivingLicenseApplications 
                             SET ApplicationID = @ApplicationID,
                                 LicenseClassID = @LicenseClassID 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                UpdatedSuccessfully = (RowsAffected > 0);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static bool IsPersonDeniedForClassData(int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID)
        {
            bool IsFound = false;

            const int CancelledStatus = 2;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1
                             FROM Applications A
                             JOIN LocalDrivingLicenseApplications L
                             ON A.ApplicationID = L.ApplicationID
                             WHERE A.ApplicantPersonID = @ApplicantPersonID
                             AND A.ApplicationTypeID = @ApplicationTypeID
                             AND L.LicenseClassID = @LicenseClassID
                             AND A.ApplicationStatus !=@CancelledStatus";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@CancelledStatus", CancelledStatus);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

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

        public static bool DeleteLocalDrivingLicenseApplicationData(int LocalDrivingLicenseApplicationID)
        {
            bool DeletedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        public static bool CancelLocalDrivingLicenseApplicationData(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            const int CancelledStatus = 2;

            bool CancelledSuccessfully = false;

            string query = @"UPDATE dbo.Applications 
                             SET ApplicationStatus = @CancelledStatus
                             WHERE ApplicationID = (
                                   SELECT ApplicationID FROM LocalDrivingLicenseApplications 
                                   WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID )";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@CancelledStatus", CancelledStatus);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                CancelledSuccessfully = (RowsAffected > 0);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return CancelledSuccessfully;
        }

        public static int GetTestsCountForLocalApplicationData(int LocalDrivingLicenseApplicationID, int LicenseClassID, bool IsPassed)
        {
            int TestsCount = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT(*)
                             FROM Tests T
                             JOIN TestAppointments TA
                                 ON T.TestAppointmentID = TA.TestAppointmentID
                             JOIN LocalDrivingLicenseApplications LDLA
                                 ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                             WHERE T.TestResult = @TestResult
                               AND LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND LDLA.LicenseClassID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestResult", IsPassed ? 1 : 0);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    TestsCount = Convert.ToInt32(result);
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

            return TestsCount;
        }

        public static bool DoesPassTestTypeData(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 TestResult
                             FROM LocalDrivingLicenseApplications
                             INNER JOIN
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE
                             (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                             AND(TestAppointments.TestTypeID = @TestTypeID)
                             ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return Result;
        }

        public static bool DoesAttendTestTypeData(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 Found=1
                             FROM LocalDrivingLicenseApplications
                             INNER JOIN
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE
                             (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                             AND(TestAppointments.TestTypeID = @TestTypeID)
                             ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsFound = (result != null);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static byte TotalAttemptsPerTestData(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TotalTrialsPerTest = count(TestID)
                             FROM LocalDrivingLicenseApplications
                             INNER JOIN
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE
                             (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                             AND(TestAppointments.TestTypeID = @TestTypeID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
        
        public static bool IsThereAnActiveScheduledTestData(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 Found=1
                             FROM LocalDrivingLicenseApplications
                             INNER JOIN
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                             WHERE
                             (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                             AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                             ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }


    }
}
