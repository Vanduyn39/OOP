//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Media;
//using System.Text;
//using System.Threading.Tasks;

//namespace giaodienhaychongiadung
//{
//    internal class SoundMusic
//    {
//        public static SoundMusic Plays { get; set; }
//        public static bool isPlaying { get; set;}
//        public static void PlayMusic(object music)
//        {
//            Plays = new SoundPlayer(Properties.Resources.nhacnen1);
//            Plays.Play();
//            IsPlaying = true;
//            // Dừng phát nhạc nếu đã có nhạc đang phát
//            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\nhacnen1.wav";
//            //StopMusic();
//            // Tạo đối tượng AudioFileReader từ filePath
//            using (var audioFileReader = new AudioFileReader(filePath))
//            {
//                // Khởi tạo đối tượng WaveOutEvent
//                waveOut = new WaveOutEvent();
//                waveOut.Init(audioFileReader);
//                // Bắt đầu phát nhạc
//                waveOut.Play();
//            }
//        }
//    }
//}
