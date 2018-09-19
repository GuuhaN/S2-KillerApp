using System.Collections.Generic;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Repositories
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

        public User GetUserById(int id)
        {
            return userContext.SelectUserById(id);
        }

        public void AddUser(string username, string password, string email)
        {
            if(userContext.SelectUser(username, password) == null)
                userContext.AddUser(username, password, email);
        }

        public void UpdateUser(int userId, int lastPlayedSong, bool isOnline)
        {
            userContext.UpdateStatus(userId, lastPlayedSong, isOnline);
        }

        public void RemoveUser(int id)
        {

        }
    }
}
