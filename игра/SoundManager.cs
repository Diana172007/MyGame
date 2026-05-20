using System.Media;

namespace игра
{
    public class SoundManager
    {
        private SoundPlayer backgroundMusic;
        private SoundPlayer dieSound;

        public SoundManager()
        {
            var musicPath = @"C:\Users\Account\Downloads\musicFon.wav";
            if (System.IO.File.Exists(musicPath))
                backgroundMusic = new SoundPlayer(musicPath);

            var diePath = @"C:\Users\Account\Downloads\die.wav";
            if (System.IO.File.Exists(diePath))
                dieSound = new SoundPlayer(diePath);
        }
        public void PlayBackground()
        {
            backgroundMusic?.PlayLooping();
        }
        public void StopBackground()
        {
            backgroundMusic?.Stop();
        }

        public void PlayDie()
        {
            dieSound?.Play();
        }
    }
}