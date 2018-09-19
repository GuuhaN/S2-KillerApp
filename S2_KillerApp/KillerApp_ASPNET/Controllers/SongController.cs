using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Repositories;

namespace S2_KillerApp_ASPNET.Controllers
{
    public class SongController : Controller
    {
        private SongRepository songRepository;
        private ISongContext songContext;

        public SongController()
        {
            songContext = new SongSQLContext();
            songRepository = new SongRepository(songContext);
        }

    }
}