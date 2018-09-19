using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Controllers
{
    public class UserController
    {
        private static UserController instance;

        private Repositories.UserRepository userRepository;
        private Repositories.PlaylistRepository playlistRepository;

        private readonly Data_Contexts.IUserContext userContext;
        private readonly Data_Contexts.IPlaylistContext playlistContext;

        private User user;

        public User User
        {
            get { return user; }
        }


        public UserController()
        {
#if DEBUG
            userContext = new Data_Contexts.UserTestContext();
            playlistContext = new Data_Contexts.PlaylistTestContext();
#elif (!DEBUG)
            userContext = new Data_Contexts.UserSQLContext();
            playlistContext = new Data_Contexts.PlaylistSQLContext();
#endif

            userRepository = new Repositories.UserRepository(userContext);

            playlistRepository = new Repositories.PlaylistRepository(playlistContext);
        }

        public static UserController GetInstance()
        {
            if (instance == null)
                instance = new UserController();

            return instance;
        }

        public bool Login(string username, string password)
        {
            user = userRepository.GetUserCredentials(username, password);
            try
            {
                if (user == null)
                    return false;

                //if (user.GetLoginStatus())
                //    return new Tuple<bool, string>(false, "User is already logged in !");

                if (user.GetUsername() == username &&
                    user.GetPassword() == password)
                {
                    userRepository.UpdateUser(user.GetUserId(), user.GetLastPlayedSong(), true);
                    LoadUserPlaylists(user.GetUserId());
                    return true;
                }
            }
            catch (DataException e)
            {
                return false;
            }

            return false;
        }

        public void LoadUserPlaylists(int userId)
        {
            List<Playlist> localPlaylists = playlistContext.SelectAllUserPlaylists(userId);
            for (int i = 0; i < localPlaylists.Count; i++)
            {
                for (int j = 0;
                    j < PlaylistController.GetInstance()
                        .GetSongsInPlaylist(localPlaylists[i].GetPlaylistId()).Count;
                    j++)
                {
                    localPlaylists[i].GetSonglist().Add(PlaylistController.GetInstance()
                        .GetSongsInPlaylist(localPlaylists[i].GetPlaylistId())[j]);
                }
            }

            user.SetPlaylists(localPlaylists);
        }

        public bool Logout(int userId)
        {
            if (user != null)
            {
                if(user.GetLoginStatus())
                    return userRepository.UpdateUser(userId, user.GetLastPlayedSong(), false);

                return false;
            }

            return false;
        }

        public bool Register(string username, string password, string email)
        {
            if (userRepository.GetUserCredentials(username, password) != null)
                return false;

            if (username.Length < 4)
                return false;

            if (password.Length < 4)
                return false;

            if (email.Length < 4)
                return false;

            userRepository.AddUser(username, password, email);
            Login(username, password);
            return true;
        }

        public bool Remove(int userId)
        {
            return userRepository.RemoveUser(userId);
        }
    }
}
