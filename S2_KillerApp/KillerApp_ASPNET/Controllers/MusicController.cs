using System;
using System.Collections.Generic;
using System.Linq;
using ParkSquare.Gracenote;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;
using S2_KillerApp_ASPNET.Repositories;

namespace S2_KillerApp_ASPNET.Controllers
{
        [Authorize(Roles = "User, Admin")]
        public class MusicController : Controller { 

        public UserViewModel UserViewModel
        {
            get { return _userViewModel; }
        }

        private static MusicController instance;

        private UserRepository userRepository;
        private PlaylistRepository playlistRepository;

        private IPlaylistContext playlistContext;
        private IUserContext userContext;

        private UserViewModel _userViewModel;

        public MusicController()
        {
            _userViewModel = new UserViewModel();

            playlistContext = new PlaylistSQLContext();
            userContext = new UserSQLContext();

            playlistRepository = new PlaylistRepository(playlistContext);
            userRepository = new UserRepository(userContext);
        }

        [HttpGet] // Main Get function
        public IActionResult Main()
        {
            IActionResult result = View("Main");
            _userViewModel.User =
                userRepository.GetUserById(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            userRepository.UpdateUser(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                _userViewModel.User.LastPlayedSong, true);
            _userViewModel.UserPlaylists = playlistRepository.GetPlaylists(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));

            if (_userViewModel?.User != null)
                result = View(_userViewModel);

            return result;
        }
    }
}