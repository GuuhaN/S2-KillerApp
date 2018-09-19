using System;
using KillerApp_Library.Data_Contexts;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Repositories
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
