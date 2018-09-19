using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp_Library.Domain_Classes
{
    public class Song
    {
        private int id;
        private string songname;
        private string genre;
        private int score;
        private bool isExplicit;

        public Song(int _id, string _songname, string _genre, int _score, bool _isExplicit)
        {
            this.id = _id;
            this.songname = _songname;
            this.genre = _genre;
            this.score = _score;
            this.isExplicit = _isExplicit;
        }

        public int GetSongId()
        {
            return id;
        }

        public string GetSongname()
        {
            return songname;
        }

        public string GetGenre()
        {
            return genre;
        }

        public int GetScore()
        {
            return score;
        }

        public bool GetExplicit()
        {
            return isExplicit;
        }
    }
}
