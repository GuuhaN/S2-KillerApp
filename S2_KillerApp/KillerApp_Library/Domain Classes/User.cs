using System.Collections.Generic;

namespace KillerApp_Library.Domain_Classes
{
    enum Loginstatus
    {
        LoggedOut = 0,
        LoggedIn = 1
    }

    public class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private int lastPlayedSong;
        private bool loggedIn;
        private List<Playlist> userPlaylists = new List<Playlist>();

        public User(int _id, string _username, string _password, string _email, int _lastPlayedSong, bool _loggedIn)
        {
            this.id = _id;
            this.username = _username;
            this.password = _password;
            this.email = _email;
            this.lastPlayedSong = _lastPlayedSong;
            this.loggedIn = _loggedIn;
        }

        public int GetUserId()
        {
            return id;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetEmail()
        {
            return email;
        }

        public int GetLastPlayedSong()
        {
            return lastPlayedSong;
        }

        public bool GetLoginStatus()
        {
            return loggedIn;
        }

        public List<Playlist> GetPlaylists()
        {
            return userPlaylists;
        }

        public List<Playlist> SetPlaylists(List<Playlist> playlists)
        {
            userPlaylists.Clear();
            userPlaylists = playlists;
            return userPlaylists;
        }
    }
}
