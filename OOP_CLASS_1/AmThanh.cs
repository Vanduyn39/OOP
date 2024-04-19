using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
namespace OOP_CLASS_1
{
    public class AmThanh
    {
        private SoundPlayer AmThanhGame;
        private SoundPlayer Nhac_trldung;
        private SoundPlayer Nhac_trlsai;
        private SoundPlayer Nhac_mogame;
        private SoundPlayer Nhac_background;
        private SoundPlayer Nhac_win;
        public static AmThanh amThanh;

        public AmThanh()
        {
            string Nhac = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            AmThanhGame = new SoundPlayer(Path.Combine(Nhac, @"Game.wav"));
            Nhac_trldung = new SoundPlayer(Path.Combine(Nhac, @"Correct.wav"));
            Nhac_trlsai = new SoundPlayer(Path.Combine(Nhac, @"Sai.wav"));
            Nhac_mogame = new SoundPlayer(Path.Combine(Nhac, @"Topic.wav"));
            Nhac_background = new SoundPlayer(Path.Combine(Nhac, @"Choi.wav"));
            Nhac_win = new SoundPlayer(Path.Combine(Nhac, @"Dung.wav"));
        }

        public void PlaySound()
        {
            AmThanhGame.Play();
        }

        public void StopSound()
        {
            AmThanhGame.Stop();
        }

        public void PlayCorrectSound()
        {
            Nhac_trldung.Play();
        }

        public void PlayIncorrectSound()
        {
            Nhac_trlsai.Play();
        }

        public void PlayMoGameSound()
        {
            Nhac_mogame.Play();
        }
        public void StopMoGameSound()
        {
            Nhac_mogame.Stop();
        }

        public void PlayBackgroundMusic()
        {
            Nhac_background.Play();
        }
        public void StopBackgroundMusic()
        {
            Nhac_background.Stop();
        }
        public void PlayWinMusic()
        {
            Nhac_win.Play();
        }
    }
}
