using System.Collections.Generic;
using System.Data;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    public interface IUserContext
    {
        User SelectUser(string username, string password);
        bool AddUser(string username, string password, string email);
        bool DeleteUser(int id);
        bool UpdateStatus(int userId, int lastPlayedSong, bool isOnline);
    }
}
