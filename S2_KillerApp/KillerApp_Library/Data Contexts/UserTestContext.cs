using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    class UserTestContext : IUserContext
    {
        private static int s_id;
        private List<User> users = new List<User>();


        public UserTestContext()
        {
            users.Add(new User(s_id, "admin", "admin", "admin@gmail.com", 0, false));
            s_id++;
        }

        public User SelectUser(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.GetUsername() == username && user.GetPassword() == password)
                    return user;
            }

            return null;
        }

        public bool AddUser(string username, string password, string email)
        {
            s_id++;
            users.Add(new User(s_id, username, password, email, 0, false));
            return true;
        }

        public bool DeleteUser(int id)
        {
            return users.Remove(users.Find(x => x.GetUserId() == id));
        }

        public bool UpdateStatus(int userId, int lastPlayedSong, bool isOnline)
        {
            User updatedUser = users.Find(x => x.GetUserId() == userId);
            users.Remove(updatedUser);
            users.Add(new User(updatedUser.GetUserId(), updatedUser.GetUsername(), updatedUser.GetPassword(),
                updatedUser.GetEmail(), lastPlayedSong, isOnline));
            return true;
        }
    }
}
