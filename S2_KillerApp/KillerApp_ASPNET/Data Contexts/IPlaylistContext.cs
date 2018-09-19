using System.Collections.Generic;
using System.Data;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    public interface IPlaylistContext
    {
        void InsertPlaylist(int userId, string title, string description, bool isPublic);
        List<Playlist> SelectAllUserPlaylists(int userId);
        List<Song> GetSongsInPlaylist(int playlistId);
        void AddToPlaylist(int songId, int playlistId);
        void Update(int playlistId, string playlistTitle, string playlistDescription);
        void RemoveFromPlaylist(int playlistSongId);
    }
}
