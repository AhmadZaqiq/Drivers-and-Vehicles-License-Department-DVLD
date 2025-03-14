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
    public class clsApplicationsData
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Applications";

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

            }

            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus,
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
                    ApplicationStatus = (int)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }

            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewApplication(int ApplicantPersonID,
             DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus,
             DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int ApplicationID = -1;

            string query = "INSERT INTO dbo.Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, " +
                           "ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) " +
                           "VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, " +
                           "@LastStatusDate, @PaidFees, @CreatedByUserID); " +
                           "SELECT SCOPE_IDENTITY();";

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

            catch (Exception ex) { }

            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            bool DeletedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM dbo.Applications" +
                           " WHERE ApplicationID = @ApplicationID;";

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

            }

            finally
            {
                connection.Close();
            }

            return DeletedSuccessfully;
        }

        public static int GetApplicationIDByApplicantPersonID(int ApplicantPersonID)
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

            catch (Exception ex) { }

            finally { connection.Close(); }

            return ApplicationID;

        }

    }
}
