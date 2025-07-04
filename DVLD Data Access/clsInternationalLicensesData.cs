﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data_Access
{
    public class clsInternationalLicensesData
    {
        public static DataTable GetAllInternationalLicensesData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive
                             From InternationalLicenses;";

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

        public static DataTable GetAllInternationalLicensesForDriverData(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID,
                                    IssueDate, ExpirationDate, IsActive
                             FROM InternationalLicenses
                             WHERE DriverID = @DriverID
                             ORDER BY ExpirationDate desc;";

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
                Console.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetInternationalLicenseByIDData(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
            ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                    IssueDate, ExpirationDate, IsActive, CreatedByUserID
                             FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
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

        public static int AddNewInternationalLicenseData(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update InternationalLicenses 
                             SET IsActive=0
                             WHERE DriverID=@DriverID

                             INSERT INTO InternationalLicenses (
                                ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                             VALUES (
                                @ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,
                                @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error while adding international license: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return InternationalLicenseID;
        }

        public static bool UpdateInternationalLicenseData(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUserID)
        {
            bool UpdatedSuccessfully = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                             SET ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 IsActive = @IsActive,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE InternationalLicenseID = @InternationalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                UpdatedSuccessfully = (rowsAffected > 0);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error while updating international license: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static int GetActiveInternationalLicenseIDByDriverIDData(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 InternationalLicenseID
                             FROM InternationalLicenses 
                             WHERE DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                             ORDER BY ExpirationDate Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
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


            return InternationalLicenseID;
        }



    }
}
