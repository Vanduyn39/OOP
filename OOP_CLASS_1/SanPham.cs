using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class SanPham : ISerializable
    {
        public string TenSP { get; set; }
        public decimal GiaSP { get; set; }
        public string Mota { get; set; }
        public string Anh { get; set; }
        public SanPham() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TenSP", TenSP); info.AddValue("GiaSP", GiaSP);
            info.AddValue("Mo ta", Mota); info.AddValue("Anh", Anh);
        }
        public SanPham(SerializationInfo info, StreamingContext context)
        {
            TenSP = info.GetString("TenSP");
            GiaSP = info.GetDecimal("GiaSP");
            Mota = info.GetString("Mo Ta");
            Anh = info.GetString("Anh");
        }
        override public string ToString()
        {
            return $"San Pham: Ten SP: {TenSP}, Gia SP: {GiaSP}, Mo ta: {Mota}, Anh: {Anh}";
        }

    }
}
