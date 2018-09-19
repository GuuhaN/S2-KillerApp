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
    public class PlaylistController : Controller
    {
        private UserViewModel userViewModel;

        private IPlaylistContext playlistContext;
        private PlaylistRepository playlistRepository;

        public PlaylistController()
        {
            playlistContext = new PlaylistSQLContext();
            playlistRepository = new PlaylistRepository(playlistContext);
        }

        public IActionResult GetPlaylist(string menuBtnVal)
        {
            userViewModel = new UserViewModel();
            if (User.Identity.IsAuthenticated)
            {
                userViewModel.UserPlaylists =
                    playlistRepository.GetPlaylists(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                if (Convert.ToInt32(menuBtnVal) == 0)
                    userViewModel.SelectedPlayList = 1;
                else
                    userViewModel.SelectedPlayList = Convert.ToInt32(menuBtnVal);

                for (int i = 0; i < userViewModel.UserPlaylists.Count; i++)
                {
                    List<Song> playlistSongs =
                        playlistRepository.GetSongsInPlaylist(userViewModel.UserPlaylists[i].Id);
                    for (int j = 0; j < playlistSongs.Count; j++)
                        userViewModel.UserPlaylists[i].SongList.Add(playlistSongs[j]);
                }
            }

            return PartialView("_Playlist", userViewModel);
        }

        [HttpPost]
        public IActionResult CreatePlaylist(string playlistTitle, string playlistDescription, bool playlistPrivacy)
        {
            if (playlistDescription == null)
                playlistDescription = "";

            playlistRepository.InsertPlaylist(
                Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                playlistTitle, playlistDescription, playlistPrivacy);

            return RedirectToAction("GetPlaylist");
        }

        [HttpPost]
        public IActionResult AddSongToPlaylist(int songId, int playlistId)
        {
            playlistRepository.AddSongToPlaylist(songId, playlistId);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdatePlaylist(int playlistId, string playlistTitle, string playlistDescription)
        {
            playlistRepository.UpdatePlaylist(playlistId, playlistTitle, playlistDescription);
            return RedirectToAction("GetPlaylist");
        }

        [HttpPost]
        public IActionResult DeletePlaylist(int playlistId)
        {
            playlistRepository.RemovePlaylist(playlistId);
            return RedirectToAction("GetPlaylist");
        }

        public IActionResult ModalDetails(int playlistId, string modalType)
        {
            IActionResult result = NoContent();
            userViewModel = new UserViewModel();
            if (User.Identity.IsAuthenticated)
            {
                userViewModel.UserPlaylists =
                    playlistRepository.GetPlaylists(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                userViewModel.SelectedPlayList = playlistId;
            }

            if (modalType.Contains("create"))
                result = PartialView("_CreateModal", userViewModel);
            if (modalType.Contains("edit"))
                result = PartialView("_EditModal", userViewModel);
            if (modalType.Contains("delete"))
                result = PartialView("_DeleteModal", userViewModel);

            return result;
        }
    }
}