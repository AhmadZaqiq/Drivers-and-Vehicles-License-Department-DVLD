using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data_Access
{
    public class clsApplicationData
    {
        public static DataTable GetAllApplicationsData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Applications";

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

        public static bool GetApplicationByIDData(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus,
            ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool IsFound = false;

            string query = @" SELECT *
                              FROM Applications
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

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static int AddNewApplicationData(int ApplicantPersonID,
             DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus,
             DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int ApplicationID = -1;

            string query = @"INSERT INTO dbo.Applications 
                             (ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
                              ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) 
                             VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, 
                                     @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();


                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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

            return ApplicationID;
        }

        public static bool UpdateApplicationData(int ApplicationID,
             int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
             byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE dbo.Applications 
                     SET ApplicantPersonID = @ApplicantPersonID,
                         ApplicationDate = @ApplicationDate,
                         ApplicationTypeID = @ApplicationTypeID,
                         ApplicationStatus = @ApplicationStatus,
                         LastStatusDate = @LastStatusDate,
                         PaidFees = @PaidFees,
                         CreatedByUserID = @CreatedByUserID
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static bool DeleteApplicationData(int ApplicationID)
        {
            bool DeletedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Applications
                             WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static int GetApplicationIDByApplicantPersonIDData(int ApplicantPersonID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ApplicationID
                             FROM Applications
                             WHERE ApplicantPersonID=@ApplicantPersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    ApplicationID = Convert.ToInt32(result);
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

            return ApplicationID;
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1
                             FROM Applications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

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

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=ApplicationID
                             FROM Applications
                             WHERE ApplicantPersonID = @ApplicantPersonID
                             AND ApplicationTypeID=@ApplicationTypeID
                             AND ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
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

            return ActiveApplicationID;
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            //Incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            FROM Applications
                            INNER JOIN
                            LocalDrivingLicenseApplications
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            AND ApplicationTypeID=@ApplicationTypeID 
							AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            AND ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
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

            return ActiveApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Applications  
                             SET 
                             ApplicationStatus = @NewStatus, 
                             LastStatusDate = @LastStatusDate
                             WHERE ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }


    }
}
