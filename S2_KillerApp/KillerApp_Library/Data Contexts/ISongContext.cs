using System.Collections.Generic;
using KillerApp_Library.Domain_Classes;

namespace KillerApp_Library.Data_Contexts
{
    public interface ISongContext
    {
        Song GetById(int songId);
        Song GetByArtist(string artistName);
        List<Song> GetAllSongsByArtist(string artist);
        List<Song> GetAllSongsbyGenre(string genre);
    }
}
