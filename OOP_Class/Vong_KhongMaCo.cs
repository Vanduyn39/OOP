using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Class
{
    public class Vong_KhongMaCo : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_KhongMaCo(int tienThuong, SanPhamList sanPhamList) : base("Khong Ma Co", tienThuong)
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
        }

    }
}
