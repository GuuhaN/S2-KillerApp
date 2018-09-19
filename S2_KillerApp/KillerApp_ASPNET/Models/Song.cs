using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_KillerApp_ASPNET.Models
{
    public class Song
    {
        public int id { get; }
        public string songname { get; }
        public string artistName { get; }
        public string genre { get; }
        public int score { get; }
        public bool isExplicit { get; }

        public Song(int _id, string _songname, string _artistName, string _genre, int _score, bool _isExplicit)
        {
            this.id = _id;
            this.songname = _songname;
            this.artistName = _artistName;
            this.genre = _genre;
            this.score = _score;
            this.isExplicit = _isExplicit;
        }
    }
}
