using WMPLib;

namespace KillerApp_Library.Core
{
    public class Music_Player
    {
        private WindowsMediaPlayer windowsMediaPlayer;

        public bool isPaused
        {
            get { return windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying; }
        }

        public Music_Player()
        {
            windowsMediaPlayer = new WindowsMediaPlayer();
        }

        /// <summary>
        /// Main play function to load up automatically the song that is given through parameter.
        /// NOTE: Function already has the constant path to the songs what is available and only accepts .wav files.
        /// Might change in the future, splitted up in folders by artists and albums.
        /// </summary>
        public void Play(string wavFileName)
        {
            wavFileName += @"Post Malone - rockstar ft. 21 Savage";

            if (!wavFileName.EndsWith(".wav"))
                wavFileName += ".wav";

            windowsMediaPlayer.URL =
                @"C:\Users\nigel\OneDrive\Fontys\School Fontys\Leerjaar 1\S2\KillerApp\KillerApp Songs\" + wavFileName;
            if(windowsMediaPlayer.URL != null)
                windowsMediaPlayer.controls.play();
        }

        /// <summary>
        /// Pause and unpause the music, depending on its playstate ( Playing or Not Playing ).
        /// </summary>
        /// <returns></returns>
        public double Pause()
        {
            if (windowsMediaPlayer.URL != null)
            {
                if (windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    windowsMediaPlayer.controls.pause();
                    return windowsMediaPlayer.currentMedia.duration;
                }

                windowsMediaPlayer.controls.play();
                return windowsMediaPlayer.currentMedia.duration;
            }

            return 0;
        }

        public void Stop()
        {
            if(windowsMediaPlayer.URL != null)
                windowsMediaPlayer.controls.stop();
        }
    }
}
