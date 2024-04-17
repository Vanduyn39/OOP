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
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string soundFolderPath = Path.Combine(basePath, "Sounds");

            string amThanhGamePath = Path.Combine(soundFolderPath, "WinterFluteVersion-VA_4b4y5.wav");
            string nhacTrldungPath = Path.Combine(soundFolderPath, "Am-thanh-chuc-mung-chien-thang-www_tiengdong_com.wav");
            string nhacTrlsaiPath = Path.Combine(soundFolderPath, "trlsai.wav.wav");

            AmThanhGame = new SoundPlayer(amThanhGamePath);
            Nhac_trldung = new SoundPlayer(nhacTrldungPath);
            Nhac_trlsai = new SoundPlayer(nhacTrlsaiPath);
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
