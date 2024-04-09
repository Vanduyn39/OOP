using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{
    public class Vong_BanTayVang : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_BanTayVang(SanPhamList sanPhamList) : base("Ban Tay Vang")
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
        }
    }
}
