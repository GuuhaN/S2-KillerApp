using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;
using S2_KillerApp_ASPNET.Repositories;

namespace S2_KillerApp_ASPNET.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class SideBarController : Controller
    {
        private PlaylistRepository playlistRepository;

        public SideBarController()
        {
            IPlaylistContext playlistContext = new PlaylistSQLContext();
            playlistRepository = new PlaylistRepository(playlistContext);
        }

        public IActionResult RenderSideBar()
        {
            IActionResult result = RedirectToAction("Index", "Home");
            UserViewModel _userViewModel = new UserViewModel();
            if (User.Identity.IsAuthenticated)
            {
                _userViewModel.UserPlaylists =
                    playlistRepository.GetPlaylists(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));

                if (_userViewModel.UserPlaylists.Count > 0)
                    _userViewModel.SelectedPlayList = _userViewModel.UserPlaylists[0].Id;

                for (int i = 0; i < _userViewModel.UserPlaylists.Count; i++)
                {
                    List<Song> playlistSongs =
                        playlistRepository.GetSongsInPlaylist(_userViewModel.UserPlaylists[i].Id);
                    for (int j = 0; j < playlistSongs.Count; j++)
                        _userViewModel.UserPlaylists[i].SongList.Add(playlistSongs[j]);
                }

                result = PartialView("_Sidebar", _userViewModel);
            }

            return result;
        }

        public IActionResult SideBarActions(string menuBtnVal)
        {
            IActionResult result = PartialView("_Sidebar");
            if (menuBtnVal.Contains("playlist"))
            {
                menuBtnVal = menuBtnVal.Replace("playlist", "");
                result = RedirectToAction("GetPlaylist", "Playlist", new {menuBtnVal = menuBtnVal});
            }

            if (menuBtnVal.Contains("browse"))
                result = RedirectToAction("Browse");

            return result;
        }

        [HttpGet]
        public IActionResult Browse()
        {
            return PartialView("../Search/_Browse", new List<SearchResult>());
        }
    }
}