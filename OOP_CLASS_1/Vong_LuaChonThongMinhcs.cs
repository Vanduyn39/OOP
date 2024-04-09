using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CLASS_1
{

    public class Vong_LuaChonThongMinh : VongChoi
    {
        private SanPhamList SanPhamList;
        public Vong_LuaChonThongMinh( SanPhamList sanPhamList) : base("LuaChonThongMinh")
        {
            SanPhamList = sanPhamList;
        }
        public override void Play()
        {
        }


    }
}
