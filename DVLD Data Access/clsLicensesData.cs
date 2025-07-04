using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access
{
    public class clsLicensesData
    {
        public static bool GetLicenseByIDData(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                             ApplicationID,
                             DriverID,
                             LicenseClass,
                             IssueDate,
                             ExpirationDate,
                             Notes,
                             PaidFees,
                             IsActive,
                             IssueReason,
                             CreatedByUserID
                          FROM 
                             Licenses 
                          WHERE 
                             LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
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

        public static DataTable GetDriverLicensesData(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT     
                             Licenses.LicenseID,
                             ApplicationID,
		                     LicenseClasses.ClassName, Licenses.IssueDate, 
		                     Licenses.ExpirationDate, Licenses.IsActive
                             FROM Licenses
                             INNER JOIN LicenseClasses
                             ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                             WHERE DriverID=@DriverID
                             ORDER BY IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

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
                Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddNewLicenseData(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int LicenseID = -1;

            string query = @"INSERT INTO Licenses (
                             ApplicationID, DriverID, LicenseClass, 
                              IssueDate, ExpirationDate, Notes, 
                              PaidFees, IsActive, IssueReason, CreatedByUserID
                              )
                              VALUES (
                                  @ApplicationID, @DriverID, @LicenseClass, 
                                  @IssueDate, @ExpirationDate, @Notes, 
                                  @PaidFees, @IsActive, @IssueReason, @CreatedByUserID
                              );
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding license: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool UpdateLicenseData(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE Licenses 
                     SET 
                         ApplicationID = @ApplicationID, 
                         DriverID = @DriverID, 
                         LicenseClass = @LicenseClass,
                         IssueDate = @IssueDate, 
                         ExpirationDate = @ExpirationDate, 
                         Notes = @Notes, 
                         PaidFees = @PaidFees, 
                         IsActive = @IsActive, 
                         IssueReason = @IssueReason, 
                         CreatedByUserID = @CreatedByUserID
                     WHERE 
                         LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                UpdatedSuccessfully = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating license: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static int GetActiveLicenseIDByPersonIDData(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Licenses.LicenseID
                             FROM Licenses
                             INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                             WHERE Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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

            return LicenseID;
        }

        public static bool DeactivateLicenseData(int LicenseID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Licenses
                             SET IsActive = 0
                             WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


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
