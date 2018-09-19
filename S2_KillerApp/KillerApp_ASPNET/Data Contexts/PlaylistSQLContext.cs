using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    // Stored Procedures <-- https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure
    public class PlaylistSQLContext : IPlaylistContext
    {
        private readonly string connectionString =
            "Data Source=mssql.fhict.local;Initial Catalog = dbi387964; Integrated Security = False; User ID = dbi387964; Password=gratisserver;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertPlaylist(int userId, string title, string description, bool isPublic)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(
                    $"INSERT INTO [Playlist] (User_Id, Title, Description, Privacy)" +
                    $"VALUES (@userId, @title, @description, @isPublic)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@title", title);
                sqlCommand.Parameters.AddWithValue("@description", description);
                sqlCommand.Parameters.AddWithValue("@isPublic", isPublic);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();

                // Create query for playlist
                // - Foreign key for the user id that is linked to this playlist (User_Id)
                // - Playlist name (Title)
                // - Playlist description (Description)
                // - Playlist privacy 0 (private) or 1 (public) (Privacy)
            }
        }

        public List<Playlist> SelectAllUserPlaylists(int userId)
        {
            List<Playlist> allPlaylists = new List<Playlist>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Playlist.* " +
                                                       $"FROM Playlist WHERE User_Id = @userId", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    allPlaylists.Add(new Playlist((int) sqlDataReader["Id"], (int) sqlDataReader["User_Id"],
                        sqlDataReader["Title"].ToString(),
                        sqlDataReader["Description"].ToString(),
                        sqlDataReader["Playlist_Img"].ToString(),
                        (bool) sqlDataReader["Privacy"],
                        new List<Song>()));
                }

                sqlConnection.Dispose();
                return allPlaylists;

            }
        }

        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            List<Song> songsOfPlaylist = new List<Song>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand("GetSongsInPlaylist", sqlConnection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                sqlCommand.Parameters.AddWithValue("@playlistId", playlistId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    songsOfPlaylist.Add(new Song((int) sqlDataReader["Id"], sqlDataReader["Songname"].ToString(),
                        sqlDataReader["Name"].ToString(),
                        sqlDataReader["Genre"].ToString(), (int) sqlDataReader["Score"],
                        (bool) sqlDataReader["Explicit"]));
                }

                sqlCommand.Dispose();
                return songsOfPlaylist;
            }
        }

        public void AddToPlaylist(int songId, int playlistId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(
                            $"INSERT INTO Playlist_Song VALUES(@playlistId, @songId)",
                            sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@playlistId", playlistId);
                    sqlCommand.Parameters.AddWithValue("@songId", songId);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    sqlConnection.Dispose();
                }
            }
        }

        public void Update(int playlistId, string playlistTitle, string playlistDescription)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand()
                    {
                        CommandText = "UpdatePlaylist",
                        CommandType = System.Data.CommandType.StoredProcedure,
                        Connection = sqlConnection
                    };

                    sqlCommand.Parameters.AddWithValue("@playlistId", playlistId);
                    sqlCommand.Parameters.AddWithValue("@playlistTitle", playlistTitle);
                    sqlCommand.Parameters.AddWithValue("@playlistDescription", playlistDescription);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    sqlConnection.Dispose();
                }
            }
        }

        public void RemoveFromPlaylist(int playlistSongId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand =
                        new SqlCommand
                        {
                            CommandText = "DeletePlaylist",
                            CommandType = System.Data.CommandType.StoredProcedure,
                            Connection = sqlConnection
                        };

                    sqlCommand.Parameters.AddWithValue("@playlistId", playlistSongId);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    sqlConnection.Dispose();
                }
            }
        }
    }
}
