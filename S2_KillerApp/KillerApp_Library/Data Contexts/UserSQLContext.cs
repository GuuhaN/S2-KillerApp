using System;
using System.Data.SqlClient;
using System.Data;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    // Stored Procedures <-- https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure 
    public class UserSQLContext : IUserContext
    {
        private readonly string connectionString =
            "Data Source=mssql.fhict.local;Initial Catalog = dbi387964; Integrated Security = False; User ID = dbi387964; Password=gratisserver;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User SelectUser(string username, string password)
        {
            User user = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand("SelectUser", sqlConnection) {CommandType = CommandType.StoredProcedure};

                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@username", username));
                sqlCommand.Parameters.Add(new SqlParameter("@password", password));

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    user = new User((int) sqlDataReader["Id"], sqlDataReader["Username"].ToString(),
                        sqlDataReader["Password"].ToString(),
                        sqlDataReader["Email"].ToString(), (int) sqlDataReader["LastPlayedSong"],
                        (bool) sqlDataReader["Status"]);
                }
                sqlConnection.Dispose();
                return user;
            }
        }

        public bool AddUser(string username, string password, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(
                    "INSERT INTO UserAccount(Username, Password, Email, LastPlayedSong, Status)" +
                    $" VALUES(@username, @password, @email , 0, 'false')", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@email", email);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM UserAccount WHERE Id = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Dispose();
                return true;
            }
        }

        public bool UpdateStatus(int userId, int lastPlayedSong, bool isOnline)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand($"UPDATE UserAccount SET LastPlayedSong = @lastPlayedSong, Status = @isOnline WHERE Id = @userId", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@lastPlayedSong", lastPlayedSong);
                sqlCommand.Parameters.AddWithValue("@isOnline", isOnline);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Dispose();
                return true;
            }
        }

        public void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
