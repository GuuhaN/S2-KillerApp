using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
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
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO [Playlist] " +
                                                       $"VALUES ('{userId}', '{title}', '{description}', '{isPublic}')", sqlConnection);
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

                sqlCommand.Parameters.AddWithValue("userId", userId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    allPlaylists.Add(new Playlist((int)sqlDataReader["Id"], 
                        (int)sqlDataReader["User_Id"],
                        sqlDataReader["Title"].ToString(),
                        sqlDataReader["Description"].ToString(),
                        (bool)sqlDataReader["Privacy"],
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
                    new SqlCommand(
                        "SELECT Playlist.Id, Playlist.Title, Song.* FROM Playlist_Song" +
                        " JOIN Playlist ON Playlist.Id = Playlist_Id JOIN Song" +
                        $" ON Song.Id = Song_Id WHERE Playlist.Id = {playlistId}", sqlConnection);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    songsOfPlaylist.Add(new Song((int) sqlDataReader["Id"], sqlDataReader["Songname"].ToString(),
                        sqlDataReader["Genre"].ToString(), (int) sqlDataReader["Score"],
                        (bool) sqlDataReader["Explicit"]));
                }
                sqlCommand.Dispose();
                return songsOfPlaylist;
            }
        }

        public void DeletePlaylist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
