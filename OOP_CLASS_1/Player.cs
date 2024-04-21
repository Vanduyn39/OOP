using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_CLASS_1
{
    public class Player : ISerializable
    {
        public string Ten { get; set; }
        public VongChoi Vongchoidachoi { get; set; }
        public int TienThuong { get; set; }
        public Player() { }
        public Player(string ten, VongChoi vongChoi, int tienthuong)
        {
            this.Ten = ten;
            this.Vongchoidachoi = vongChoi;
            this.TienThuong = tienthuong;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ten nguoi choi", Ten); info.AddValue("Vong choi da choi", Vongchoidachoi.GetType().Name); info.AddValue("Giai Thuong", TienThuong);
        }
        public Player(SerializationInfo info, StreamingContext context)
        {
            Ten = info.GetString("Ten nguoi choi");
            Vongchoidachoi = (VongChoi)info.GetValue("VongChoiDaChoi", typeof(VongChoi));
            TienThuong = info.GetInt32("Tien Thuong");
        }
        override public string ToString()
        {
            return $"Nguoi choi: Ten nguoi choi: {Ten},Vong Choi Da Choi: {Vongchoidachoi.GetType().Name}, Tien Thuong: {TienThuong}";
        }
        public string GetTen()
        { return Ten; }
        public VongChoi GetVongChoi()
        { return Vongchoidachoi; }
        public int GetTienThuong()
        { return TienThuong; }
        public delegate int CompareTienThuong(Player player1, Player player2);
        public static int CompareByTienThuong(Player player1, Player player2)
        {
            if (player1.GetTienThuong() > player2.GetTienThuong())
                return -1;
            else if (player1.GetTienThuong() == player2.GetTienThuong())
                return 0;
            else
                return 1;
        }
        private static void Swap(Player[] players, int i, int j)
        {
            Player player = players[i];
            players[i] = players[j];
            players[j] = player;
        }
        public static void Sort(Player[] players, CompareTienThuong compareTienThuong)
        {
            for (int i = 0; i < players.Length - 1; i++)
                for (int j = players.Length - 1; j > i; j--)
                    if (compareTienThuong(players[j], players[j - 1]) > 0)
                    {
                        Swap(players, j, j - 1);
                    }
        }
    }
}
