using System.Collections.Generic;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    public interface IUserContext
    {
        User SelectUser(string username, string password);
        User SelectUserById(int id);
        bool AddUser(string username, string password, string email);
        void DeleteUser(int id);
        void UpdateStatus(int userId, int lastPlayedSong, bool isOnline);
    }
}
