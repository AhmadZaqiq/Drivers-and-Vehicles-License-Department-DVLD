using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsPeopleData
    {
        public static DataTable PeopleData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From People_View";

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

        public static int PeopleCount()
        {
            int CountofPeople = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Count(*) FROM People";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    CountofPeople = Convert.ToInt32(Result);
                }

            }

            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return CountofPeople;
        }

        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref string Gendor, ref string Address,
            ref string Phone, ref string Email, ref string ImagePath, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM PersonDetails_View WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (string)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    CountryName = (string)reader["CountryName"];

                    if (reader["ImagePath"] != null)
                    {

                        ImagePath = (string)reader["ImagePath"];
                    }

                    else
                    {
                        ImagePath = "";
                    }
                }

                else
                {
                    IsFound = false;
                }

                reader.Close();
            }

            catch (Exception ex) { }

            finally
            {

                connection.Close();
            }

            return IsFound;

        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int PersonID = -1;

            string query = "INSERT INTO dbo.People (NationalNo, FirstName, SecondName, ThirdName, LastName, " +
                "DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) " +
                "VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, " +
                "@Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("FirstName", SecondName);
            command.Parameters.AddWithValue("ThirdName", ThirdName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("Gendor", Gendor);
            command.Parameters.AddWithValue("Address", Address);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();


                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }

                else
                {

                }
            }

            catch (Exception ex) { }

            finally
            {
                connection.Close();
            }

            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
          string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address,
          string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            bool UpdatedSuccessfully = false;

            string query = "UPDATE dbo.People SET NationalNo = @NationalNo, FirstName = @FirstName," +
                " SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, DateOfBirth = @DateOfBirth" +
                ", Gendor = @Gendor, Address = @Address, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID," +
                " ImagePath = @ImagePath WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("FirstName", SecondName);
            command.Parameters.AddWithValue("ThirdName", ThirdName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("Gendor", Gendor);
            command.Parameters.AddWithValue("Address", Address);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    UpdatedSuccessfully = true;
                }
                else
                {

                }
            }

            catch (Exception ex) { }

            finally
            {
                connection.Close();
            }

            return UpdatedSuccessfully;
        }

        public static bool IsPersonExists(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

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



    }
}