using System;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_Data_Access
{
    public class clsDetainedLicensesData
    {
        public static DataTable GetAllDetainedLicensesData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                             DL.DetainID,
                             DL.LicenseID,
                             DL.DetainDate,
                             DL.IsReleased,
                             DL.FineFees,
                             DL.ReleaseDate,
                             P.NationalNo,
                             FullName = 
                                 ISNULL(P.FirstName, '') + ' ' + 
                                 ISNULL(P.SecondName, '') + ' ' + 
                                 ISNULL(P.ThirdName + ' ', '') + 
                                 ISNULL(P.LastName, ''),
                             DL.ReleaseApplicationID
                             FROM 
                             DetainedLicenses DL
                             LEFT JOIN 
                             Applications A ON DL.ReleaseApplicationID = A.ApplicationID
                             LEFT JOIN 
                             People P ON A.ApplicantPersonID = P.PersonID;";

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

        public static bool GetDetainedLicenseByIDData(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                             LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                             ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                             FROM 
                             DetainedLicenses 
                             WHERE 
                             DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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

        public static bool GetDetainedLicenseInfoByLicenseIDData(int TargetLicenseID, ref int DetainID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DetainID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                             ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                             FROM DetainedLicenses 
                             WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", TargetLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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

        public static int AddNewDetainedLicenseData(int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int DetainID = -1;

            string query = @"INSERT INTO DetainedLicenses (
                             LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                             ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                             )
                             VALUES (
                                 @LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, 
                                 @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID
                             );
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate == DateTime.MinValue ? DBNull.Value : (object)ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID == -1 ? DBNull.Value : (object)ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ? DBNull.Value : (object)ReleaseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error while adding detained license: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return DetainID;
        }

        public static bool UpdateDetainedLicenseData(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE DetainedLicenses 
                             SET 
                                 LicenseID = @LicenseID, 
                                 DetainDate = @DetainDate, 
                                 FineFees = @FineFees,
                                 CreatedByUserID = @CreatedByUserID, 
                                 IsReleased = @IsReleased, 
                                 ReleaseDate = @ReleaseDate, 
                                 ReleasedByUserID = @ReleasedByUserID, 
                                 ReleaseApplicationID = @ReleaseApplicationID
                             WHERE 
                                 DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate == DateTime.MinValue ? DBNull.Value : (object)ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID == -1 ? DBNull.Value : (object)ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ? DBNull.Value : (object)ReleaseApplicationID);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                UpdatedSuccessfully = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating detained license: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static bool IsLicenseDetainedData(int LicenseID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1
                             FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID
                             AND IsReleased=0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool ReleaseDetainedLicenseData(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID,
                              ReleasedByUserID = @ReleasedByUserID
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);

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
