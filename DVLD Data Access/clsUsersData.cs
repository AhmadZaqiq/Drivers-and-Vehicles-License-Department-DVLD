using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsUsersData
    {
        public static DataTable GetAllUsersData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT UserID, Users.PersonID, UserName, 
                              People.FirstName + ' ' + People.SecondName + ' ' + 
                              People.ThirdName + ' ' + People.LastName AS FullName,IsActive 
                             FROM Users 
                             JOIN People ON Users.PersonID = People.PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetUserByIDData(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select *
                             FROM Users
                             WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

                else
                {
                    IsFound = false;
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

        public static bool GetUserByUsernameData(string Username, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select *
                             FROM Users
                             WHERE Username =@Username";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

                else
                {
                    IsFound = false;
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

        public static bool GetUserInfoByUsernameAndPasswordData(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                             FROM Users
                             WHERE Username = @Username
                             and
                                   Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsUserExistForPersonIDData(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1
                             FROM Users
                WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) { clsDVLDLogger.LogException(ex); }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewUserData(int PersonID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int UserID = -1;

            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive) 
                             VALUES (@PersonID, @UserName, @Password, @IsActive); 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }

            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static bool UpdateUserData(int PersonID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = @"UPDATE Users
                             SET UserName = @UserName,
                                 Password = @Password,
                                 IsActive = @IsActive 
                             WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool IsUserExistData(int UserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1
                             FROM Users
                             WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsUserExistData(string Username)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1
                             FROM Users
                             WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) { clsDVLDLogger.LogException(ex); }

            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool DeleteUserData(int UserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Users
                             WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                IsFound = (rowsAffected > 0);

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









