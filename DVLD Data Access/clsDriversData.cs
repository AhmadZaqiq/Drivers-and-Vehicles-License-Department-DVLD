using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data_Access
{
    public class clsDriversData
    {
        public static DataTable GetAllDriversData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                                   D.DriverID,
                                   D.PersonID,
                                   P.NationalNo,
                                   P.FirstName + ' ' + 
                                   P.SecondName + ' ' + 
                                   ISNULL(P.ThirdName + ' ', '') + 
                                   P.LastName AS FullName,
                                   MIN(L.IssueDate) AS Date,  -- أول رخصة (أقدم تاريخ)
                                   SUM(CASE WHEN L.IsActive = 1 THEN 1 ELSE 0 END) AS ActiveLicenseCount
                               FROM 
                                   Drivers D
                               JOIN 
                                   People P ON D.PersonID = P.PersonID
                               JOIN 
                                   Licenses L ON D.DriverID = L.DriverID
                               GROUP BY 
                                   D.DriverID, D.PersonID, P.NationalNo, P.FirstName, P.SecondName, P.ThirdName, P.LastName";

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

        public static bool GetDriverByIDData(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID, CreatedByUserID, CreatedDate
                             FROM Drivers
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GetDriverByPersonIDData(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Drivers
                             WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try 
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static int AddNewDriverData(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
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

            return DriverID;
        }

        public static bool UpdateDriverData(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            bool UpdatedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Drivers
                             SET PersonID = @PersonID,
                                 CreatedByUserID = @CreatedByUserID,
                                 CreatedDate = @CreatedDate
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                UpdatedSuccessfully = (rowsAffected > 0);
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

        public static bool DeleteDriverData(int DriverID)
        {
            bool DeletedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Drivers
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

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


    }
}
