using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace designkhongmaco
{
    public class Program
    {
        private static SanPham sanPham;

        [STAThread]
        static void Main(string[] args)
        {
            // Khởi tạo và điền dữ liệu vào file JSON trước khi chạy ứng dụng
            SanPhamList sanPhamList = new SanPhamList();
            PlayerList playerList = new PlayerList();
            DieuKhien dieuKhien = new DieuKhien(playerList, sanPhamList);
            dieuKhien.AddSanPham(sanPhamList);
            // Chạy Form1 trước
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainKMC(sanPhamList, sanPham));
        }
    }
}
