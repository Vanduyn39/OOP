using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrangChu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            ////dieuKhien.AddVongChoi(new Vong_BanTayVang(sanPhamList));
            ////dieuKhien.AddVongChoi(new Vong_DemNguoc(sanPhamList));
            ////dieuKhien.AddVongChoi(new Vong_KhongMaCo(sanPhamList));
            ////dieuKhien.AddVongChoi(new Vong_LuaChonThongMinh(sanPhamList));
            //dieuKhien.AddPlayer(playerList);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrangChu());
        }
    }
}
