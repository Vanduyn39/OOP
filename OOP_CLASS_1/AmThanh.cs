using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
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

        public AmThanh()
        {
            string Nhac = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            AmThanhGame = new SoundPlayer(Path.Combine(Nhac, @"Game.wav"));
            Nhac_trldung = new SoundPlayer(Path.Combine(Nhac, @"Dung.wav"));
            Nhac_trlsai = new SoundPlayer(Path.Combine(Nhac, @"Sai.wav"));
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