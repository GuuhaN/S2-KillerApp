using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;
using S2_KillerApp_ASPNET.Repositories;

namespace S2_KillerApp_ASPNET.Controllers
{
    public class TestController : Controller
    {
        private IPlaylistContext playlistContext;
        private PlaylistRepository playlistRepository;

        private List<Playlist> testPlaylist;


        public TestController()
        {
            playlistContext = new PlaylistSQLContext();
            playlistRepository = new PlaylistRepository(playlistContext);
        }

        public IActionResult Index()
        {
            List<Playlist> placeholderLists = new List<Playlist>()
            {
                new Playlist(0, 1, "dassda", "adsdsadas", "", true, new List<Song>())
            };
            return View(placeholderLists);
        }

        public IActionResult GetPlaylists(int uId)
        {
            var otherPlaylist = playlistRepository.GetPlaylists(1);
            return PartialView("_GetPlaylists", otherPlaylist);
        }
    }
}