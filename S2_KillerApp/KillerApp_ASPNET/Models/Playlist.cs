using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_KillerApp_ASPNET.Models
{
    public class Playlist
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
        public string Description { get; }
        public string Playlist_Img { get; }
        public bool IsPublic { get; }
        public List<Song> SongList { get; }

        public Playlist(int _id, int _userId, string _title, string _description, string _playlist_Img, bool _isPublic, List<Song> _songList)
        {
            this.Id = _id;
            this.UserId = _userId;
            this.Title = _title;
            this.Description = _description;
            this.Playlist_Img = _playlist_Img;
            this.IsPublic = _isPublic;
            this.SongList = _songList;
        }
    }
}
