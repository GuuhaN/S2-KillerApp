using KillerApp_Library.Data_Contexts;
using KillerApp_Library.Domain_Classes;
using KillerApp_Library.Repositories;

namespace KillerApp_Library.Controllers
{
    public class SongController
    {
        private static SongController instance;

        private SongRepository songRepository;
        private ISongContext songContext;

        public SongController()
        {
            songContext = new SongSQLContext();
            songRepository = new SongRepository(songContext);
        }

        public static SongController GetInstance()
        {
            if (instance == null)
                return new SongController();

            return instance;
        }

        public Song GetSongById(int songId)
        {
            return songRepository.GetSongById(songId);
        }

        public Song GetSongByArtist(string artistName)
        {
            return songRepository.GetSongByArtist(artistName);
        }
    }
}
