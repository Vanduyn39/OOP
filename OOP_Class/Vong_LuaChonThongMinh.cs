using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Class
{

    public class Vong_LuaChonThongMinh : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_LuaChonThongMinh(int tienThuong, SanPhamList sanPhamList) : base( "LuaChonThongMinh",tienThuong)
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
        }


    }
}
