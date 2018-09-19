using System.Collections.Generic;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Repositories
{
    public class PlaylistRepository
    {
        private IPlaylistContext playlistContext;
        public PlaylistRepository(IPlaylistContext _playlistContext)
        {
            playlistContext = _playlistContext;
        }

        public void InsertPlaylist(int userId, string title, string description, bool isPublic)
        {
            playlistContext.InsertPlaylist(userId, title, description, isPublic);
        }

        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            return playlistContext.GetSongsInPlaylist(playlistId);
        }

        public List<Playlist> GetPlaylists(int userId)
        {
            return playlistContext.SelectAllUserPlaylists(userId);
        }

        public void AddSongToPlaylist(int songId, int playlistId)
        {
            playlistContext.AddToPlaylist(songId, playlistId);
        }

        public void RemoveSongFromPlaylist(int playlistSongId)
        {
            playlistContext.RemoveFromPlaylist(playlistSongId);
        }

        public void UpdatePlaylist(int playlistId, string playlistTitle, string playlistDescription)
        {
            playlistContext.Update(playlistId, playlistTitle, playlistDescription);
        }

        public void RemovePlaylist(int playlistId)
        {
            playlistContext.RemoveFromPlaylist(playlistId);
        }
    }
}
