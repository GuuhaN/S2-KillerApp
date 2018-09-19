using System.Collections.Generic;
using KillerApp_Library.Data_Contexts;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Repositories
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

        public List<Playlist> GetPlaylists(int userId)
        {
            return playlistContext.SelectAllUserPlaylists(userId);
        }

        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            return playlistContext.GetSongsInPlaylist(playlistId);
        }

        public void RemovePlaylist()
        {

        }
    }
}
