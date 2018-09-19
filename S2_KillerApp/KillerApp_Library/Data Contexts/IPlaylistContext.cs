using System.Collections.Generic;
using System.Data;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    public interface IPlaylistContext
    {
        void InsertPlaylist(int userId, string title, string description, bool isPublic);
        List<Playlist> SelectAllUserPlaylists(int userId);
        List<Song> GetSongsInPlaylist(int playlistId);
        void DeletePlaylist(int id);
    }
}
