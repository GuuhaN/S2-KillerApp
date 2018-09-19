using System.Collections.Generic;

namespace S2_KillerApp_ASPNET.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Playlist> UserPlaylists = new List<Playlist>();
        public int SelectedPlayList { get; set; }
    }
}
