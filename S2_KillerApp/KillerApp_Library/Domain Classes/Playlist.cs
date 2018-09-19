using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp_Library.Domain_Classes
{
    public class Playlist
    {
        private int id;
        private int user_id;
        private string title;
        private string description;
        private bool isPublic;
        private List<Song> songList;

        public Playlist(int _id, int _user_id, string _title, string _description, bool _isPublic, List<Song> _songList)
        {
            this.id = _id;
            this.user_id = _user_id;
            this.title = _title;
            this.description = _description;
            this.isPublic = _isPublic;
            this.songList = _songList;
        }

        public int GetPlaylistId()
        {
            return id;
        }

        public int GetPlaylistUserId()
        {
            return user_id;
        }

        public string GetPlaylistTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool GetPrivacy()
        {
            return isPublic;
        }

        public List<Song> GetSonglist()
        {
            return songList;
        }
    }
}
