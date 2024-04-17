using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OOP_CLASS_1;

namespace OOP_CLASS_1
{
    public class Program
    {
        private static Player player;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            //dieuKhien.AddVongChoi(new Vong_BanTayVang(sanPhamList));
            //dieuKhien.AddVongChoi(new Vong_LuaChonThongMinh(sanPhamList/*,player*/));
            //dieuKhien.AddVongChoi(new Vong_KhongMaCo(sanPhamList));
            dieuKhien.AddVongChoi(new Vong_DemNguoc(sanPhamList));
            dieuKhien.AddPlayer1(playerList);
            dieuKhien.DieuPhoi();
            dieuKhien.AddPlayer2(playerList);
            Console.ReadLine();
        }
    }
}
