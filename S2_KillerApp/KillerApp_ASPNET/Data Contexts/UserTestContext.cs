using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    class UserTestContext : IUserContext
    {
        SortedDictionary<string, string> users = new SortedDictionary<string, string>();

        public UserTestContext()
        {
            users.Add("admin", "admin");
            users.Add("test", "tester");
            users.Add("musiclover123", "mystery123");
            users.Add("realuser", "realpassword");
        }

        public User SelectUser(string username, string password)
        {
            IEnumerable<KeyValuePair<string, string>> filtedUsers = from user in users
                        where user.Key == username && user.Value == password
                        select user;

            throw new NotImplementedException();
        }

        public User SelectUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Playlist> SelectAllUserPlaylists(int userId)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int userId, int lastPlayedSong, bool isOnline)
        {
            throw new NotImplementedException();
        }
    }
}
