//using System;
//using System.IO;
//using System.Reflection;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Media;
//namespace OOP_Class
//{
//    public class AmThanh
//    {
//        private SoundPlayer AmThanhGame;
//        private SoundPlayer Nhac_trldung;
//        private SoundPlayer Nhac_trlsai;

//        public AmThanh()
//        {
//            AmThanhGame = new SoundPlayer("");
//            Nhac_trldung = new SoundPlayer("path/to/correct-sound.wav");
//            Nhac_trlsai = new SoundPlayer("");
//            AmThanhGame.PlayLooping();
//        }

//        public void PlayCorrectSound()
//        {
//            Nhac_trldung.Play();
//        }

//        public void PlayIncorrectSound()
//        {
//            Nhac_trlsai.Play();
//        }
//        public void PlaySound()
//        {
//            AmThanhGame.Play();
//        }

//        public void StopSound()
//        {
//            AmThanhGame.Stop();
//        }

//    }
//}
