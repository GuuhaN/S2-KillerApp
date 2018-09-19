using System.Collections.Generic;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Controllers
{
    public class PlaylistController
    {
        private static PlaylistController instance;

        private Repositories.PlaylistRepository playlistRepository;
        private Data_Contexts.IPlaylistContext playlistContext;

        public PlaylistController()
        {
            playlistContext = new Data_Contexts.PlaylistSQLContext();
            playlistRepository = new Repositories.PlaylistRepository(playlistContext);
        }

        public static PlaylistController GetInstance()
        {
            if (instance == null)
                instance = new PlaylistController();

            return instance;
        }

        public void CreatePlaylist(string title, string description, bool isPublic)
        {
            if (UserController.GetInstance().User != null)
            {
                playlistRepository.InsertPlaylist(UserController.GetInstance().User.GetUserId(), title,
                    description, isPublic);
            }
        }

        public List<Playlist> GetAllPlaylists(int userId)
        {
            return playlistRepository.GetPlaylists(userId);
        }

        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            return playlistRepository.GetSongsInPlaylist(playlistId);
        }

        public void RemovePlaylist(int id)
        {
            playlistContext.DeletePlaylist(id);
        }
    }
}
