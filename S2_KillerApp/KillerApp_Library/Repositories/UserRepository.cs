using System.Collections.Generic;
using KillerApp_Library.Data_Contexts;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Repositories
{
    class UserRepository
    {
        IUserContext userContext;

        public UserRepository(IUserContext _userContext)
        {
            userContext = _userContext;
        }

        public User GetUserCredentials(string username, string password)
        {
            if(userContext.SelectUser(username, password) != null)
                return userContext.SelectUser(username, password);

            return null;
        }

        public void AddUser(string username, string password, string email)
        {
            if(userContext.SelectUser(username, password) != null)
                userContext.AddUser(username, password, email);
        }

        public bool UpdateUser(int userId, int lastPlayedSong, bool isOnline)
        {
            return userContext.UpdateStatus(userId, lastPlayedSong, isOnline);
        }

        public bool RemoveUser(int id)
        {
            return userContext.DeleteUser(id);
        }
    }
}
