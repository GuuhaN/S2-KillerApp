using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    class PlaylistTestContext : IPlaylistContext
    {
        private static int s_Playlist_Id, s_Song_Id;

        private List<Playlist> playlists = new List<Playlist>();

        public PlaylistTestContext()
        {
            playlists.Add(new Playlist(s_Playlist_Id, 1, "Posty", "Post Malone playlist", false, new List<Song>()
            {
                new Song(1, "Too Young", "Hiphop", 69, true),
                new Song(2, "rockstar", "Hiphop", 69, true),
                new Song(3, "Mask Off", "Hiphop", 69, true),
            }));
            s_Song_Id = playlists.Count;
            s_Song_Id++;
            s_Playlist_Id++;
        }

        public void InsertPlaylist(int userId, string title, string description, bool isPublic)
        {
            playlists.Add(new Playlist(s_Playlist_Id, userId, title, description, isPublic, new List<Song>()));
            s_Playlist_Id++;
        }

        public List<Playlist> SelectAllUserPlaylists(int userId)
        {
            List<Playlist> userPlaylists = new List<Playlist>();

            foreach (Playlist playlist in playlists)
            {
                if (playlist.GetPlaylistUserId() == userId)
                    userPlaylists.Add(playlist);
            }

            return userPlaylists;
        }

        public List<Song> GetSongsInPlaylist(int playlistId)
        {
            Playlist selectedPlaylist = playlists.Find(x => x.GetPlaylistId() == playlistId);
            return selectedPlaylist.GetSonglist();
        }

        public void DeletePlaylist(int id)
        {
            playlists.Remove(playlists.Find(x => x.GetPlaylistId() == id));
        }
    }
}
