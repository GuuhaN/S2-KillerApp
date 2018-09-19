using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2_KillerApp_ASPNET.Models
{
    public class User
    {
        public int Id { get; }

        [Required]
        [StringLength(100)]
        public string Username { get; }

        [Required]
        [StringLength(100)]
        public string Password { get; }

        [Required]
        [StringLength(100), EmailAddress]
        public string Email { get; }


        public int LastPlayedSong { get; }

        public string Role { get; }

        public bool LoggedIn { get; }

        public User(int _id, string _username, string _password, string _email, int _lastPlayedSong, string _role, bool _loggedIn)
        {
            this.Id = _id;
            this.Username = _username;
            this.Password = _password;
            this.Email = _email;
            this.LastPlayedSong = _lastPlayedSong;
            this.Role = _role;
            this.LoggedIn = _loggedIn;
        }
    }
}
