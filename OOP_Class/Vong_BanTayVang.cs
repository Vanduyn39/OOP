using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Class
{
    public class Vong_BanTayVang : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_BanTayVang(int tienThuong, SanPhamList sanPhamList) : base("Ban Tay Vang", tienThuong)
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
        }
    }
}
