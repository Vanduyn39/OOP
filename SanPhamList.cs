using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class SanPhamList : ISerializable
    {
        private List<SanPham> sanPhams = new List<SanPham>();
        public List<SanPham> SanPhams { get => sanPhams; set => sanPhams = value; }
        public SanPhamList() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Students", SanPhams);
        }
        public SanPhamList(SerializationInfo info, StreamingContext context)
        {
            SanPhams = (List<SanPham>)info.GetValue("SanPhams", typeof(List<SanPham>));
        }
        public void Add(SanPham item)
        {
            SanPhams.Add(item);
        }
    }
}
