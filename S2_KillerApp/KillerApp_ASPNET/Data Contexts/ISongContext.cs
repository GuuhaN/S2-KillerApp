using System.Collections.Generic;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    public interface ISongContext
    {
        Song GetById(int songId);
        Song GetByArtist(string artistName);
        List<Song> GetAllSongsByArtist(string artist);
        List<Song> GetAllSongsbyGenre(string genre);
    }
}
