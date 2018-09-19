using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    // Stored Procedures <-- https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure
    public class SongSQLContext : ISongContext
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["SpotifyConnectionString"].ConnectionString;

        public Song GetById(int songId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(
                            $"SELECT Artist.Name, Song.* FROM Song INNER JOIN Artist ON Artist.Id = {songId}",
                            sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        return new Song(songId, sqlDataReader["Songname"].ToString(), sqlDataReader["Genre"].ToString(),
                            int.Parse(sqlDataReader["Score"].ToString()), (bool) sqlDataReader["Explicit"]);
                    }
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

            return null;
        }

        public Song GetByArtist(string artistName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(
                            $"SELECT Artist.Name, Song.* FROM Song INNER JOIN Artist ON Artist.Name LIKE '%{artistName}%'",
                            sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        return new Song(int.Parse(sqlDataReader["Id"].ToString()), sqlDataReader["Songname"].ToString(), sqlDataReader["Genre"].ToString(),
                            int.Parse(sqlDataReader["Score"].ToString()), (bool)sqlDataReader["Explicit"]);
                    }
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

            return null;
        }

        public List<Song> GetAllSongsByArtist(string artist)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetAllSongsbyGenre(string genre)
        {
            throw new NotImplementedException();
        }
    }
}
