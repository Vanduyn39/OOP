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
    public class Player : ISerializable, IComparable<Player>
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
        public int CompareTo(Player other)
        {
            return TienThuong.CompareTo(other.TienThuong);
        }
    }
}
