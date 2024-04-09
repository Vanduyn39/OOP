using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace OOP_CLASS_1
{
    public class AmThanh
    {
        private SoundPlayer AmThanhGame;
        private SoundPlayer Nhac_trldung;
        private SoundPlayer Nhac_trlsai;

        public AmThanh()
        {
            AmThanhGame = new SoundPlayer("\\NewFolder1\\WinterFluteVersion-VA_4b4y5.mp3");
            Nhac_trldung = new SoundPlayer("\\NewFolder1\\Am-thanh-chuc-mung-chien-thang-www_tiengdong_com");
            Nhac_trlsai = new SoundPlayer("\\NewFolder1\\trlsai.wav.wav");
        }

        public void PlayCorrectSound()
        {
            Nhac_trldung.Play();
        }

        public void PlayIncorrectSound()
        {
            Nhac_trlsai.Play();
        }
        public void PlaySound()
        {
            AmThanhGame.Play();
        }

        public void StopSound()
        {
            AmThanhGame.Stop();
        }

    }
}
