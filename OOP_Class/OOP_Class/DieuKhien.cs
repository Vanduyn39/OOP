using Class_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Class
{
    internal class DieuKhien
    {
        private List<IVongChoi> vongChois = new List<IVongChoi>();
        private string filePathPlayer; // Đường dẫn đến file lưu thông tin người chơi

        public DieuKhien(string filePathPlayer)
        {
            this.filePathPlayer = filePathPlayer;
        }
        public void AddVongChoi(IVongChoi vongChoi)
        {
            vongChois.Add(vongChoi);
        }
        public void StartGame(PlayerList playerList)
        {
            Player player = new Player(); // Tạo một người chơi mới
            Console.WriteLine("Nhap ten ban: ");
            player.Ten = Console.ReadLine();
            for (int i = 0; i < vongChois.Count; i++)
            {
                Console.WriteLine($"\nBắt đầu vòng chơi: {vongChois[i].GetType().Name}");
                player.Vongchoidachoi = (VongChoi)vongChois[i];
                int tienThuong = vongChois[i].TienThuong;
                player.TienThuong += tienThuong;
                vongChois[i].Play();
                if (player.TienThuong == 0)
                {
                    Console.WriteLine("Bạn đã thua ở vòng này. Kết thúc chương trình!");
                    return; // Dừng chương trình nếu người chơi thua ở vòng này
                }
            }
            playerList.Add(player);
            Console.WriteLine(player);
            Console.WriteLine("Chúc mừng! Bạn đã hoàn thành tất cả các vòng chơi.");
        }
    }

}

