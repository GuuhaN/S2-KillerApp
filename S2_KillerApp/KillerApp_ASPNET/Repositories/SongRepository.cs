using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Repositories
{
    public class SongRepository
    {
        private ISongContext songContext;
        public SongRepository(ISongContext _songContext)
        {
            songContext = _songContext;
        }

        public Song GetSongById(int songId)
        {
            return songContext.GetById(songId);
        }

        public Song GetSongByArtist(string artistName)
        {
            return songContext.GetByArtist(artistName);
        }
    }
}
